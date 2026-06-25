using System;
using System.Windows.Forms;
using SafeBox.Application.DTOs;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Domain.Entities;
using SafeBox.Infrastructure.Repositories;
using SafeBox.Infrastructure.Services;

namespace SafeBox.Presentation
{
    public partial class Login : Form
    {
        private readonly IAuthService _authService;

        public Login(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;

            this.txtLoginEmail.KeyDown += InputFields_KeyDown;
            this.txtLoginPass.KeyDown += InputFields_KeyDown;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = txtLoginEmail.Text.Trim();
            string password = txtLoginPass.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter Username and Password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Admin admin = _authService.AdminLogin(username, password);
                if (admin != null)
                {
                    SessionManager.CurrentAdmin = admin;

                    MessageBox.Show($"Login Successful! Welcome Admin {admin.AdminUsername}.", "Admin Access",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AdminDashboard adminForm = new AdminDashboard();
                    adminForm.Show();
                    this.Hide();
                    return;
                }
            }
            catch
            {
            }

            try
            {
                UserDto user = _authService.Login(username, password);

                SessionManager.CurrentUser = new User
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Email = user.Email,
                    Status = user.Status,
                    RoleId = user.RoleId,
                    PasswordHash = user.PasswordHash
                };

                MessageBox.Show($"Login Successful! Welcome {user.Username}.", "User Access",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var vaultService = new VaultService();
                var fileService = new FileService();
                var activityService = new ActivityService();
                var userService = new UserService();
                var cryptoService = new CryptoService();

                DashBoardMain dashboard = new DashBoardMain(
                    _authService, vaultService, fileService,
                    activityService, userService, cryptoService);
                dashboard.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblGoToRegister_Click(object sender, EventArgs e)
        {
            Registration regForm = new Registration(_authService);
            regForm.Show();
            this.Hide();
        }

        private void lblForgetPass_Click(object sender, EventArgs e)
        {
            ResetPass resetPass = new ResetPass();
            resetPass.Owner = this;
            resetPass.Show();
            this.Hide();
        }

        private void txtLoginEmail_Click(object sender, EventArgs e)
        {
        }

        private void InputFields_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSignIn_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
