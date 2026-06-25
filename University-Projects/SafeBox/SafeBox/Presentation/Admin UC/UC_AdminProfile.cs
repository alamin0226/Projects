using System;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Domain.Entities;
using SafeBox.Infrastructure.Repositories;
using SafeBox.Infrastructure.Services;

namespace SafeBox.Admin_UC
{
    public partial class UC_AdminProfile : UserControl
    {
        private readonly AuditService _auditService;
        private readonly UserRepository _userRepository;
        private readonly CryptoService _cryptoService;
        private Admin _currentAdmin;

        public UC_AdminProfile()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            _auditService = new AuditService();
            _cryptoService = new CryptoService();
            btnSaveChanges.Click += BtnSaveChanges_Click;
            LoadAdminProfile();
        }

        private void LoadAdminProfile()
        {
            try
            {
                _currentAdmin = SessionManager.CurrentAdmin;

                if (_currentAdmin == null)
                {
                    MessageBox.Show("Admin profile not found. Please login again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                materialTextBoxEdit1.Text = _currentAdmin.AdminUsername;
                materialTextBoxEdit1.ReadOnly = true;
                materialTextBoxEdit2.Text = _currentAdmin.Email;
                cuiLabel2.Content = _currentAdmin.AdminUsername;
                cuiLabel3.Content = _currentAdmin.Email;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentAdmin == null) return;

                bool emailUpdated = UpdateEmail();
                bool passwordUpdated = UpdatePassword();

                if (emailUpdated || passwordUpdated)
                {
                    string changes = "";
                    if (emailUpdated) changes += "Email updated. ";
                    if (passwordUpdated) changes += "Password updated.";

                    MessageBox.Show(changes.Trim(), "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No changes detected.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update profile: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UpdateEmail()
        {
            string newEmail = materialTextBoxEdit2.Text.Trim();

            if (string.IsNullOrWhiteSpace(newEmail) || !newEmail.Contains("@") || !newEmail.Contains("."))
            {
                return false;
            }

            if (newEmail.Equals(_currentAdmin.Email, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            _currentAdmin.Email = newEmail;
            _userRepository.UpdateAdminEmail(_currentAdmin.AdminId, newEmail);

            _auditService.LogAction(_currentAdmin.AdminId, "Admin Profile Updated", $"Updated email to: {newEmail}");

            cuiLabel3.Content = newEmail;
            SessionManager.CurrentAdmin = _currentAdmin;
            return true;
        }

        private bool UpdatePassword()
        {
            string currentPassword = materialTextBoxEdit4.Text;
            string newPassword = materialTextBoxEdit3.Text;

            if (string.IsNullOrWhiteSpace(currentPassword) && string.IsNullOrWhiteSpace(newPassword))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(currentPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Please fill both current and new password fields.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("New password must be at least 6 characters long.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_cryptoService.VerifyAdminPassword(currentPassword, _currentAdmin.PasswordHash))
            {
                MessageBox.Show("Current password is incorrect.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string newHash = _cryptoService.HashAdminPassword(newPassword);
            _userRepository.UpdateAdminPassword(_currentAdmin.AdminId, newHash);

            _currentAdmin.PasswordHash = newHash;
            SessionManager.CurrentAdmin = _currentAdmin;

            _auditService.LogAction(_currentAdmin.AdminId, "Password Changed", "Admin changed password");

            materialTextBoxEdit4.Text = "";
            materialTextBoxEdit3.Text = "";

            return true;
        }
    }
}
