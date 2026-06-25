using System;
using System.Drawing;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;

namespace SafeBox.Presentation.UC.Vault
{
    public partial class UC_VaultCard : UserControl
    {
        // Events to notify parent
        public event Action<int, string> VaultClicked; // vaultId, vaultName
        public event Action<int> VaultDeleted; // vaultId

        // Vault data
        private int _vaultId;
        private string _vaultName;
        private IVaultService _vaultService;

        public UC_VaultCard()
        {
            InitializeComponent();
            _vaultService = new VaultService(); // Default

            // Set cursor to hand for clickable appearance
            this.Cursor = Cursors.Hand;

            // Connect click events for all controls
            this.Click += OnCardClick;
            lblVaultName.Click += OnCardClick;
            lblDesc.Click += OnCardClick;
            lblFileCount.Click += OnCardClick;
            lblSize.Click += OnCardClick;
            lblDate.Click += OnCardClick;
            materialCard1.Click += OnCardClick;

            // The menu button click is handled separately
            btnOpen_Click.Click -= Dashboard_Click;
            btnOpen_Click.Click += BtnMenu_Click;
        }

        public void SetService(IVaultService vaultService)
        {
            _vaultService = vaultService;
        }

        /// <summary>
        /// Sets the vault data from database entity
        /// </summary>
        public void SetVaultData(int vaultId, string vaultName, string description, int fileCount, long totalSize, DateTime createdDate)
        {
            _vaultId = vaultId;
            _vaultName = vaultName;

            lblVaultName.Content = vaultName;
            lblDesc.Content = description;
            lblFileCount.Content = $"{fileCount} files";
            lblSize.Content = FormatFileSize(totalSize);
            lblDate.Content = createdDate.ToString("M/d/yyyy");
        }

        /// <summary>
        /// Legacy method for backward compatibility
        /// </summary>
        public void SetData(string name, string desc, string files, string size, string date)
        {
            lblVaultName.Content = name;
            lblDesc.Content = desc;
            lblFileCount.Content = files;
            lblSize.Content = size;
            lblDate.Content = date;
        }

        /// <summary>
        /// Gets the vault ID
        /// </summary>
        public int VaultId => _vaultId;

        /// <summary>
        /// Gets the vault name
        /// </summary>
        public string VaultName => _vaultName;

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

        /// <summary>
        /// Handles card click - opens vault content
        /// </summary>
        private void OnCardClick(object sender, EventArgs e)
        {
            if (_vaultId > 0)
            {
                VaultClicked?.Invoke(_vaultId, _vaultName);
            }
        }

        /// <summary>
        /// Handles menu button click - shows context menu
        /// </summary>
        private void BtnMenu_Click(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            // Open vault
            ToolStripMenuItem openItem = new ToolStripMenuItem("Open Vault");
            openItem.Click += (s, args) => VaultClicked?.Invoke(_vaultId, _vaultName);
            menu.Items.Add(openItem);

            menu.Items.Add(new ToolStripSeparator());

            // Delete vault
            ToolStripMenuItem deleteItem = new ToolStripMenuItem("Delete Vault");
            deleteItem.ForeColor = Color.Red;
            deleteItem.Click += DeleteVault_Click;
            menu.Items.Add(deleteItem);

            // Show menu at button location
            menu.Show(btnOpen_Click, new Point(0, btnOpen_Click.Height));
        }

        /// <summary>
        /// Handles delete vault click
        /// </summary>
        private void DeleteVault_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure you want to delete vault '{_vaultName}'?\n\nThis will permanently delete all files in this vault.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int userId = SessionManager.CurrentUserId;
                    _vaultService.DeleteVault(_vaultId, userId);
                    VaultDeleted?.Invoke(_vaultId);
                    MessageBox.Show("Vault deleted successfully.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to delete vault: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Legacy click handler (kept for designer compatibility)
        /// </summary>
        private void Dashboard_Click(object sender, EventArgs e)
        {
            OnCardClick(sender, e);
        }

        /// <summary>
        /// Legacy click handler
        /// </summary>
        private void Vault_Click(object sender, EventArgs e)
        {
            OnCardClick(sender, e);
        }
    }
}
