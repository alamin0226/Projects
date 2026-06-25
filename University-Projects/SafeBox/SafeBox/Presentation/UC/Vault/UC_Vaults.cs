using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;
using SafeBox.Presentation.UC.Dashboard;

namespace SafeBox.Presentation.UC.Vault
{
    public partial class UC_Vaults : UserControl
    {
        public event Action<int, string> OpenVaultContentRequested;

        private readonly IVaultService _vaultService;

        public UC_Vaults()
        {
            InitializeComponent();
            _vaultService = new VaultService(); // Default for designer
            if (cuiButton1 != null) cuiButton1.Click += BtnCreateVault_Click;
            if (!this.DesignMode) LoadVaults();
        }

        public UC_Vaults(IVaultService vaultService)
        {
            InitializeComponent();
            _vaultService = vaultService;
            if (cuiButton1 != null) cuiButton1.Click += BtnCreateVault_Click;
            LoadVaults();
        }

        private void LoadVaults()
        {
            try
            {
                int userId = SessionManager.CurrentUserId;
                if (userId == 0)
                {
                    MessageBox.Show("Please log in to view vaults.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                flowVaultsContainer.Controls.Clear();

                var vaults = _vaultService.GetVaultsByUserId(userId);

                if (!vaults.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No vaults yet. Click '+ Create Vault' to create your first vault.",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(20)
                    };
                    flowVaultsContainer.Controls.Add(lblEmpty);
                    return;
                }

                foreach (var vault in vaults)
                {
                    UC_VaultCard card = new UC_VaultCard();
                    card.SetService(_vaultService);
                    card.Margin = new Padding(15);

                    int fileCount = _vaultService.GetFileCount(vault.VaultId);
                    long totalSize = _vaultService.GetTotalSize(vault.VaultId);

                    card.SetVaultData(vault.VaultId, vault.VaultName, vault.Description ?? string.Empty,
                        fileCount, totalSize, vault.CreatedDate);

                    card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(250, 250, 250);
                    card.MouseLeave += (s, e) => card.BackColor = Color.White;
                    card.VaultClicked += OnVaultCardClicked;
                    card.VaultDeleted += OnVaultDeleted;

                    flowVaultsContainer.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading vaults: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCreateVault_Click(object sender, EventArgs e)
        {
            try
            {
                int userId = SessionManager.CurrentUserId;
                if (userId == 0)
                {
                    MessageBox.Show("Please log in to create a vault.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var dialog = new SimpleCreateVaultDialog())
                {
                    if (dialog.ShowDialog(this.ParentForm) == DialogResult.OK)
                    {
                        if (string.IsNullOrWhiteSpace(dialog.VaultName))
                        {
                            MessageBox.Show("Please enter a vault name.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _vaultService.CreateVault(dialog.VaultName, dialog.VaultDescription, userId);
                        LoadVaults();

                        MessageBox.Show($"Vault '{dialog.VaultName}' created successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create vault: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnVaultCardClicked(int vaultId, string vaultName)
        {
            OpenVaultContentRequested?.Invoke(vaultId, vaultName);
        }

        private void OnVaultDeleted(int vaultId)
        {
            try
            {
                int userId = SessionManager.CurrentUserId;
                _vaultService.DeleteVault(vaultId, userId);
                LoadVaults();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting vault: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshVaults()
        {
            LoadVaults();
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            BtnCreateVault_Click(sender, e);
        }
    }
}
