using SafeBox.Admin_UC;
using SafeBox.Application.Services;
using SafeBox.Application.Interfaces;
using SafeBox.Infrastructure.Repositories;
using SafeBox.Infrastructure.Services;
using SafeBox.Presentation;
using System;
using System.Windows.Forms;

namespace SafeBox
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();

            // Home loading
            UC_AdminHome adminHome = new UC_AdminHome();

            // ✅ UC_AdminHome events hook করা
            adminHome.OpenUserManagementRequested += OpenUserManagementPage;
            adminHome.OpenRolesPermissionsRequested += OpenRolesPermissionsPage;
            adminHome.OpenAuditLogsRequested += OpenAuditLogsPage;

            LoadAdminScreen(adminHome);
        }

        // --- Load screen method ---
        private void LoadAdminScreen(UserControl adminPage)
        {
            adminPage.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(adminPage);
            adminPage.BringToFront();
        }

        // =========================
        // Pages open methods
        // =========================

        // ✅ User Management
        private void OpenUserManagementPage()
        {
            UC_UserManagement userMgmtPage = new UC_UserManagement();
            LoadAdminScreen(userMgmtPage);
        }

        // ✅ Roles & Permissions
        private void OpenRolesPermissionsPage()
        {
            UC_Roles rolesPage = new UC_Roles();
            LoadAdminScreen(rolesPage);
        }

        // ✅ Audit Logs
        private void OpenAuditLogsPage()
        {
            UC_AuditLog auditPage = new UC_AuditLog();
            LoadAdminScreen(auditPage);
        }

        // =========================
        // Sidebar buttons
        // =========================

        // --- 1. Dashboard Button ---
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UC_AdminHome homePage = new UC_AdminHome();

            // 🔁 Home reload হলে event আবার hook করতে হবে
            homePage.OpenUserManagementRequested += OpenUserManagementPage;
            homePage.OpenRolesPermissionsRequested += OpenRolesPermissionsPage;
            homePage.OpenAuditLogsRequested += OpenAuditLogsPage;

            LoadAdminScreen(homePage);
        }

        // --- 2. User Management Button ---
        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            OpenUserManagementPage();
        }

        // --- 3. Roles and Permission Button ---
        private void btnRoles_Click(object sender, EventArgs e)
        {
            OpenRolesPermissionsPage();
        }

        // --- 4. Activity Log Button ---
        private void btnActivityLog_Click(object sender, EventArgs e)
        {
            OpenAuditLogsPage();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Environment.Exit(0);
            // Clear session
            SessionManager.ClearSession();

            // Create services and show login form
            var userRepository = new UserRepository();
            var cryptoService = new CryptoService();
            IAuthService authService = new AuthService(userRepository, cryptoService);

            Login loginForm = new Login(authService);
            loginForm.Show();
            this.Hide();
        }


        private void Admin_Click(object sender, EventArgs e)
        {
            UC_AdminProfile adminProfilePage = new UC_AdminProfile();
            LoadAdminScreen(adminProfilePage);
        }
    }
}
