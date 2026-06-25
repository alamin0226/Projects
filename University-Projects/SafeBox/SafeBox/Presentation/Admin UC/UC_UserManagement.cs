using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Domain.Entities;

namespace SafeBox
{
    public partial class UC_UserManagement : UserControl
    {
        private readonly IUserService _userService;
        private readonly AuditService _auditService;

        public UC_UserManagement()
        {
            InitializeComponent();
            _userService = new UserService();
            _auditService = new AuditService();
            txtSearch.TextChanged += txtSearch_TextChanged;
            PopulateAdminUserList("");
        }

        private void PopulateAdminUserList(string searchText)
        {
            try
            {
                flowUserList.Controls.Clear();
                searchText = searchText?.ToLower() ?? "";

                IEnumerable<User> users;
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    users = _userService.GetAllUsers();
                }
                else
                {
                    users = _userService.SearchUsers(searchText);
                }

                if (!users.Any())
                {
                    Label lblEmpty = new Label
                    {
                        Text = "No users found",
                        Font = new Font("Segoe UI", 12F),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Padding = new Padding(20)
                    };
                    flowUserList.Controls.Add(lblEmpty);
                    return;
                }

                foreach (var user in users)
                {
                    ListItem_UserRow rowItem = new ListItem_UserRow();

                    string initial = user.Username.Length > 0 ? user.Username[0].ToString().ToUpper() : "U";
                    string role = user.RoleId == 1 ? "ADMIN" : "USER";
                    string lastLogin = user.LastLoginDate?.ToString("M/d/yyyy HH:mm") ?? "Never";
                    string createdDate = user.CreatedDate.ToString("M/d/yyyy");

                    rowItem.SetData(initial, user.Username, user.Email, role,
                        user.Status, lastLogin, createdDate, user.UserId);

                    rowItem.MouseEnter += (s, e) => rowItem.BackColor = Color.FromArgb(250, 250, 250);
                    rowItem.MouseLeave += (s, e) => rowItem.BackColor = Color.White;

                    rowItem.UserActivated += OnUserActivated;
                    rowItem.UserDeactivated += OnUserDeactivated;

                    rowItem.Width = flowUserList.Width - 25;
                    flowUserList.Controls.Add(rowItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUserActivated(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                string username = user != null ? user.Username : $"ID: {userId}";

                _userService.ActivateUser(userId);

                int adminId = SessionManager.CurrentAdminId > 0 ? SessionManager.CurrentAdminId : SessionManager.CurrentUserId;
                _auditService.LogAction(adminId, "User Activated", $"Activated user: {username}");

                RefreshUserList();

                MessageBox.Show("User activated/restored successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to activate user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnUserDeactivated(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                string username = user != null ? user.Username : $"ID: {userId}";

                _userService.DeactivateUser(userId);

                int adminId = SessionManager.CurrentAdminId > 0 ? SessionManager.CurrentAdminId : SessionManager.CurrentUserId;
                _auditService.LogAction(adminId, "User Deactivated", $"Deactivated user: {username}");

                RefreshUserList();

                MessageBox.Show("User deactivated/soft-deleted successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to deactivate user: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.Trim();
                PopulateAdminUserList(searchText);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Create User functionality will be implemented.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UC_UserManagement_Load(object sender, EventArgs e)
        {
            PopulateAdminUserList("");
        }

        public void RefreshUserList()
        {
            PopulateAdminUserList(txtSearch?.Text ?? "");
        }
    }
}
