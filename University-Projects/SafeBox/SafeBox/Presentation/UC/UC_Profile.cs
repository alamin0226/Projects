using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;
using SafeBox.Domain.Entities;

namespace SafeBox.Presentation.UC
{
    public partial class UC_Profile : UserControl
    {
        private readonly IUserService _userService;
        private readonly IActivityService _activityService;
        private readonly ICryptoService _cryptoService;
        private User _currentUser;

        public UC_Profile()
        {
            InitializeComponent();
            _userService = new UserService(); // Default
            _activityService = new ActivityService(); // Default
            // _cryptoService? Cannot instantiate interface easily without implementation.
            // But we need default constructor for Designer.
            // We can leave it null and check? Or use simple implementation?
            // Designer might fail if LoadUserProfile is called.
            // LoadUserProfile is called in constructor.
            // I'll wrap LoadUserProfile in !DesignMode check.
            if (!this.DesignMode) LoadUserProfile();
        }

        public UC_Profile(IUserService userService, IActivityService activityService, ICryptoService cryptoService)
        {
            InitializeComponent();
            _userService = userService;
            _activityService = activityService;
            _cryptoService = cryptoService;
            LoadUserProfile();
        }

        /// <summary>
        /// Loads current user profile data
        /// </summary>
        private void LoadUserProfile()
        {
            try
            {
                int userId = SessionManager.CurrentUserId;
                if (userId == 0)
                {
                    MessageBox.Show("Please log in to view profile.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _currentUser = _userService.GetUserById(userId);
                if (_currentUser == null)
                {
                    MessageBox.Show("User not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Populate form fields from database
                cuiLabel2.Content = _currentUser.Username;
                cuiLabel3.Content = _currentUser.Email;
                cuiLabel4.Content = _currentUser.Status.ToUpper();

                materialTextBoxEdit1.Text = _currentUser.Username;
                materialTextBoxEdit2.Text = _currentUser.Email;

                // Clear password fields
                materialTextBoxEdit4.Text = "";
                materialTextBoxEdit3.Text = "";

                // Wire up save button if not already wired in designer
                btnSaveChanges.Click -= BtnSaveChanges_Click; // Prevent double wiring
                btnSaveChanges.Click += BtnSaveChanges_Click;
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
                string newName = materialTextBoxEdit1.Text.Trim();
                string newEmail = materialTextBoxEdit2.Text.Trim();
                string currentPassword = materialTextBoxEdit4.Text;
                string newPassword = materialTextBoxEdit3.Text;

                if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newEmail))
                {
                    MessageBox.Show("Name and Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isChanged = false;

                // Update Name/Email
                if (newName != _currentUser.Username || newEmail != _currentUser.Email)
                {
                    _currentUser.Username = newName;
                    _currentUser.Email = newEmail;
                    isChanged = true;
                }

                // Update Password if provided
                if (!string.IsNullOrEmpty(newPassword))
                {
                    if (string.IsNullOrEmpty(currentPassword))
                    {
                        MessageBox.Show("Please enter current password to change to a new one.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (_cryptoService == null)
                    {
                        MessageBox.Show("Crypto service not available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!_cryptoService.VerifyPassword(currentPassword, _currentUser.PasswordHash))
                    {
                        MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _currentUser.PasswordHash = _cryptoService.HashPassword(newPassword);
                    isChanged = true;
                    // We need to update password separately if using IUserService.UpdatePassword?
                    // Or UpdateUser handles it?
                    // IUserService.UpdateUser(User user) might update everything including password hash if it just saves the entity.
                    // Assuming UpdateUser updates the whole entity.
                }

                if (isChanged)
                {
                    _userService.UpdateUser(_currentUser);

                    // Log the activity
                    _activityService.LogActivity(_currentUser.UserId, "Profile Update", "User updated account details");

                    // Refresh UI
                    LoadUserProfile();
                    MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No changes detected.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save changes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Fix for Designer errors
        private void cuiLabel4_Load(object sender, EventArgs e) { }
        private void cuiLabel3_Load(object sender, EventArgs e) { }
        private void cuiLabel2_Load(object sender, EventArgs e) { }
        private void materialTextBoxEdit3_Click(object sender, EventArgs e) { }

    }
}

