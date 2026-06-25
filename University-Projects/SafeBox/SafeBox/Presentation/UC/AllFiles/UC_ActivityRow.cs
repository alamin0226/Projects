using System;
using System.Drawing;
using System.Windows.Forms;

namespace SafeBox.Presentation.UC.AllFiles
{
    public partial class UC_ActivityRow : UserControl
    {
        private int _vaultId;
        private string _vaultName;
        public event Action<int, string> VaultClicked;

        public UC_ActivityRow()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;

            // Wire up click events for the control and its children
            this.Click += Row_Click;
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += Row_Click;
                foreach (Control child in ctrl.Controls)
                {
                    child.Click += Row_Click;
                }
            }
        }

        private void Row_Click(object sender, EventArgs e)
        {
            VaultClicked?.Invoke(_vaultId, _vaultName);
        }

        /// <summary>
        /// Sets vault data for display
        /// </summary>
        public void SetVaultData(int vaultId, string vaultName, int fileCount, long totalSize)
        {
            _vaultId = vaultId;
            _vaultName = vaultName;

            lblFilename.Content = vaultName;
            lblFilesAMT.Content = $"{fileCount} Files";
            lvlFileMB.Content = FormatFileSize(totalSize);

            // Optional: Set a description or date in cuiLabel1 if needed
            cuiLabel1.Content = "Storage Vault";
        }

        private string FormatFileSize(long bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            if (bytes < 1024 * 1024 * 1024) return $"{bytes / (1024.0 * 1024.0):F1} MB";
            return $"{bytes / (1024.0 * 1024.0 * 1024.0):F1} GB";
        }

        private void lblFilename_Load(object sender, EventArgs e) { }
        private void cuiLabel1_Load(object sender, EventArgs e) { }
        private void lblFilesAMT_Load(object sender, EventArgs e) { }
        private void lvlFileMB_Load(object sender, EventArgs e) { }
    }
}
