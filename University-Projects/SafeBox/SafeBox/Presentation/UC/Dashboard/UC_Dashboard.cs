using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories; // For default constructor if needed, or remove
using SafeBox.Presentation.UC;
using SafeBox.Presentation.UC.ActivityLog;
using SafeBox.Presentation.UC.Vault;
using SafeBox.Presentation.UC.AllFiles;

namespace SafeBox.Presentation.UC.Dashboard
{
    public partial class UC_Dashboard : UserControl
    {
        public event Action OpenSearchRequested;
        public event Action OpenVaultsRequested;
        public event Action OpenAllFilesRequested;
        public event Action<int, string> OpenVaultContentRequested;

        private readonly IVaultService _vaultService;
        private readonly IFileService _fileService;
        private readonly IActivityService _activityService;
        private readonly IUserService _userService;

        // Default constructor for Designer support
        public UC_Dashboard()
        {
            InitializeComponent();
            // Poor man's DI for designer
            _vaultService = new VaultService();
            _fileService = new FileService();
            _activityService = new ActivityService();
            _userService = new UserService();

            // Should we LoadDashboard here? Yes, as before.
            // But if dependencies are not fully set (e.g. they need other dependencies), this might fail.
            // VaultService etc now have parameterless constructors that do 'new Repository()'.
            // So this should work.
            if (!this.DesignMode)
            {
                LoadDashboard();
            }
        }

        public UC_Dashboard(IVaultService vaultService, IFileService fileService, IActivityService activityService, IUserService userService)
        {
            InitializeComponent();
            _vaultService = vaultService;
            _fileService = fileService;
            _activityService = activityService;
            _userService = userService;

            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                int userId = SessionManager.CurrentUserId;
                if (userId == 0)
                {
                    MessageBox.Show("Please log in to view dashboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadStatistics(userId);
                LoadRecentActivity(userId);
                LoadRecentVaults(userId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatistics(int userId)
        {
            try
            {
                int totalUsers = _userService.GetTotalUserCount();
                int activeUsers = _userService.GetActiveUserCount();
                int inactiveUsers = _userService.GetInactiveUserCount();

                long totalStorage = _fileService.GetTotalStorageSize(userId);
                int totalFiles = _fileService.GetAllFiles(userId).Count();
                int totalVaults = _vaultService.GetVaultCount(userId);

                if (label3 != null)
                    label3.Text = totalVaults.ToString();

                if (label4 != null)
                    label4.Text = totalFiles.ToString();

                if (label6 != null)
                    label6.Text = FormatFileSize(totalStorage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentActivity(int userId)
        {
            try
            {
                flowRecentActivity.Controls.Clear();

                var activities = _activityService.GetRecentActivities(userId, 5);

                if (!activities.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No recent activity",
                        Font = new Font("Segoe UI", 10F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(10)
                    };
                    flowRecentActivity.Controls.Add(lblEmpty);
                    return;
                }

                Color[] colors = {
                    Color.FromArgb(255, 240, 220),
                    Color.FromArgb(230, 240, 255),
                    Color.FromArgb(230, 255, 230),
                    Color.FromArgb(240, 230, 255),
                    Color.FromArgb(255, 230, 240)
                };
                int colorIndex = 0;

                foreach (var activity in activities)
                {
                    UC_RecentActivity row = new UC_RecentActivity();

                    row.SetData(activity.Action, activity.Description,
                        activity.Timestamp.ToString("MMM dd, HH:mm"),
                        colors[colorIndex % colors.Length]);

                    row.Width = flowRecentActivity.Width - 30;
                    row.Height = 65;
                    row.Margin = new Padding(0, 0, 0, 8);
                    flowRecentActivity.Controls.Add(row);
                    colorIndex++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recent activity: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentVaults(int userId)
        {
            try
            {
                flowRecentVaults.Controls.Clear();

                var vaults = _vaultService.GetVaultsByUserId(userId).Take(5);

                if (!vaults.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No vaults yet. Create your first vault!",
                        Font = new Font("Segoe UI", 10F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(10)
                    };
                    flowRecentVaults.Controls.Add(lblEmpty);
                    return;
                }

                foreach (var vault in vaults)
                {
                    UC_ActivityRow row = new UC_ActivityRow();

                    int fileCount = _vaultService.GetFileCount(vault.VaultId);
                    long totalSize = _vaultService.GetTotalSize(vault.VaultId);

                    row.SetVaultData(vault.VaultId, vault.VaultName, fileCount, totalSize);
                    row.VaultClicked += (vId, vName) => OpenVaultContentRequested?.Invoke(vId, vName);

                    row.Width = flowRecentVaults.Width - 25;
                    row.Margin = new Padding(0, 0, 0, 10);
                    flowRecentVaults.Controls.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recent vaults: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void panelCreateVault_Click(object sender, EventArgs e)
        {
            CreateNewVault();
        }

        private void CreateNewVault()
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
                            MessageBox.Show("Please enter a vault name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _vaultService.CreateVault(dialog.VaultName, dialog.VaultDescription, userId);
                        LoadDashboard();

                        MessageBox.Show($"Vault '{dialog.VaultName}' created successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create vault: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            OpenVaultsRequested?.Invoke();
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            OpenAllFilesRequested?.Invoke();
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            OpenSearchRequested?.Invoke();
        }

        private void panelCreateVault_Paint(object sender, PaintEventArgs e)
        {
        }

        public void RefreshDashboard()
        {
            LoadDashboard();
        }
    }

    internal class SimpleCreateVaultDialog : Form
    {
        public string VaultName { get { return txtName.Text; } }
        public string VaultDescription { get { return txtDescription.Text; } }

        private TextBox txtName;
        private TextBox txtDescription;
        private Button btnOk;
        private Button btnCancel;

        public SimpleCreateVaultDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            var lblName = new System.Windows.Forms.Label();
            var lblDesc = new System.Windows.Forms.Label();

            this.SuspendLayout();

            this.Size = new Size(400, 250);
            this.Text = "Create New Vault";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblName.Text = "Vault Name:";
            lblName.Location = new Point(20, 20);
            lblName.AutoSize = true;

            this.txtName.Location = new Point(20, 45);
            this.txtName.Size = new Size(340, 25);

            lblDesc.Text = "Description:";
            lblDesc.Location = new Point(20, 80);
            lblDesc.AutoSize = true;

            this.txtDescription.Location = new Point(20, 105);
            this.txtDescription.Size = new Size(340, 25);

            this.btnOk.Text = "Create";
            this.btnOk.DialogResult = DialogResult.OK;
            this.btnOk.Location = new Point(180, 160);
            this.btnOk.Size = new Size(80, 30);

            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(280, 160);
            this.btnCancel.Size = new Size(80, 30);

            this.Controls.Add(lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(lblDesc);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);

            this.AcceptButton = this.btnOk;
            this.CancelButton = this.btnCancel;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
