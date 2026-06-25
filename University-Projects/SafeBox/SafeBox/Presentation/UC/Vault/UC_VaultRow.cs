using System;
using System.Drawing;
using System.Windows.Forms;

namespace SafeBox.Presentation.UC.Vault
{
    public partial class UC_VaultRow : UserControl
    {
        public UC_VaultRow()
        {
            InitializeComponent();
            this.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Sets vault data for display
        /// </summary>
        public void SetVaultData(int vaultId, string vaultName, string description, int fileCount, long totalSize, DateTime createdDate)
        {
            // Update labels if they exist in the Designer
            // You may need to adjust these based on your actual Designer controls
            // For now, this is a placeholder that can be customized
        }

        /// <summary>
        /// Formats file size
        /// </summary>
        private string FormatFileSize(long bytes)
        {
            if (bytes < 1024)
                return $"{bytes} B";
            else if (bytes < 1024 * 1024)
                return $"{bytes / 1024.0:F1} KB";
            else if (bytes < 1024 * 1024 * 1024)
                return $"{bytes / (1024.0 * 1024.0):F1} MB";
            else
                return $"{bytes / (1024.0 * 1024.0 * 1024.0):F1} GB";
        }
    }
}
