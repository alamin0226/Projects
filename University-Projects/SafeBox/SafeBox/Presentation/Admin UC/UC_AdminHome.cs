using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Domain.Entities;

namespace SafeBox
{
    public partial class UC_AdminHome : UserControl
    {
        public event Action OpenUserManagementRequested;
        public event Action OpenRolesPermissionsRequested;
        public event Action OpenAuditLogsRequested;

        private readonly IUserService _userService;
        private readonly AuditService _auditService;

        public UC_AdminHome()
        {
            InitializeComponent();
            _userService = new UserService();
            _auditService = new AuditService();

            LoadStatistics();
            LoadRecentUsers();
            LoadRecentActions();
        }

        private void LoadStatistics()
        {
            try
            {
                int totalUsers = _userService.GetTotalUserCount();
                int activeUsers = _userService.GetActiveUserCount();
                int inactiveUsers = _userService.GetInactiveUserCount();

                if (lblTotalUsers != null) lblTotalUsers.Text = totalUsers.ToString();
                if (lblActiveUsers != null) lblActiveUsers.Text = activeUsers.ToString();
                if (lblInactiveUsers != null) lblInactiveUsers.Text = inactiveUsers.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentUsers()
        {
            try
            {
                flowRecentUsers.Controls.Clear();

                var users = _userService.GetRecentUsers(5);

                if (!users.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No users found",
                        Font = new Font("Segoe UI", 10F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(10)
                    };
                    flowRecentUsers.Controls.Add(lblEmpty);
                    return;
                }

                foreach (var user in users)
                {
                    ListItem_User item = new ListItem_User();
                    string initial = user.Username.Length > 0 ? user.Username[0].ToString().ToUpper() : "U";
                    item.SetData(initial, user.Username, user.Email, user.Status);

                    item.MouseEnter += (s, e) => item.BackColor = Color.FromArgb(250, 250, 250);
                    item.MouseLeave += (s, e) => item.BackColor = Color.White;

                    flowRecentUsers.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recent users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentActions()
        {
            try
            {
                flowRecentActions.Controls.Clear();

                var auditLogs = _auditService.GetRecentAuditLogs(10);

                if (!auditLogs.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No admin actions found",
                        Font = new Font("Segoe UI", 10F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(10)
                    };
                    flowRecentActions.Controls.Add(lblEmpty);
                    return;
                }

                foreach (var log in auditLogs)
                {
                    ListItem_ActivityRow row = new ListItem_ActivityRow();
                    row.SetData(log.Action, log.Description ?? string.Empty,
                        log.Timestamp.ToString("M/d/yyyy"));

                    flowRecentActions.Controls.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading recent actions: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            OpenUserManagementRequested?.Invoke();
        }

        private void btnRolesPermissions_Click(object sender, EventArgs e)
        {
            OpenRolesPermissionsRequested?.Invoke();
        }

        private void btnAuditLogs_Click(object sender, EventArgs e)
        {
            OpenAuditLogsRequested?.Invoke();
        }

        public void RefreshDashboard()
        {
            LoadStatistics();
            LoadRecentUsers();
            LoadRecentActions();
        }

        private void flowRecentActions_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
