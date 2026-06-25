using ReaLTaiizor.Controls;
using SafeBox.Presentation.UC.AllFiles;
using SafeBox.Presentation.UC.Dashboard;
using SafeBox.Presentation.UC.Vault;
using SafeBox.Presentation.UC.Search;
using SafeBox.Presentation.UC.ActivityLog;
using SafeBox.Presentation.UC;
using System;
using System.Drawing;
using System.Windows.Forms;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Services;
using SafeBox.Application.Interfaces;

namespace SafeBox.Presentation
{
    public partial class DashBoardMain : Form
    {
        private readonly IAuthService _authService;
        private readonly IVaultService _vaultService;
        private readonly IFileService _fileService;
        private readonly IActivityService _activityService;
        private readonly IUserService _userService;
        private readonly ICryptoService _cryptoService;

        public DashBoardMain(IAuthService authService, IVaultService vaultService, IFileService fileService, IActivityService activityService, IUserService userService, ICryptoService cryptoService)
        {
            InitializeComponent();
            _authService = authService;
            _vaultService = vaultService;
            _fileService = fileService;
            _activityService = activityService;
            _userService = userService;
            _cryptoService = cryptoService;

            // Load initial view (Dashboard)
            UC_Dashboard uc = CreateDashboardWithEvents();
            AddUserControl(uc);
            UpdateButtonStyles(Dashboard);
        }

        private void Tutorial_Load(object sender, EventArgs e)
        {
        }

        private void DashBoardMain_Load(object sender, EventArgs e)
        {
        }

        private UC_Dashboard CreateDashboardWithEvents()
        {
            UC_Dashboard uc = new UC_Dashboard(_vaultService, _fileService, _activityService, _userService);
            uc.OpenSearchRequested += OpenSearchFromDashboard;
            uc.OpenVaultsRequested += OpenVaultsFromDashboard;
            uc.OpenAllFilesRequested += OpenAllFilesFromDashboard;
            uc.OpenVaultContentRequested += OpenVaultContent;
            return uc;
        }

        private void OpenVaultsFromDashboard()
        {
            UC_Vaults vaultPage = new UC_Vaults(_vaultService);
            vaultPage.OpenVaultContentRequested += OpenVaultContent;
            AddUserControl(vaultPage);
            UpdateButtonStyles(vaults);
        }

        private void OpenAllFilesFromDashboard()
        {
            UC_AllFiles allFilesPage = new UC_AllFiles(_fileService, _vaultService);
            allFilesPage.OpenVaultContentRequested += OpenVaultContent;
            AddUserControl(allFilesPage);
            UpdateButtonStyles(Allfiles);
        }

        private void OpenSearchFromDashboard()
        {
            UC_Search searchPage = new UC_Search(_fileService, _vaultService);
            searchPage.OpenVaultContentRequested += OpenVaultContent;
            AddUserControl(searchPage);
            UpdateButtonStyles(Search);
        }

        private void OpenVaultContent(int vaultId, string vaultName)
        {
            UC_VaultContent contentPage = new UC_VaultContent(_fileService, _vaultService);
            contentPage.SetVault(vaultId, vaultName);
            contentPage.BackToVaultsRequested += OpenVaultsPage;
            AddUserControl(contentPage);
            // Keep current button active or clear? Usually Vaults or AllFiles is active.
            // For now, we simulate Vaults active if coming from there, but we might come from AllFiles.
            // Let's leave button state as is or set to Vaults?
            UpdateButtonStyles(vaults);
        }

        private void OpenVaultsPage()
        {
            UC_Vaults vaultPage = new UC_Vaults(_vaultService);
            vaultPage.OpenVaultContentRequested += OpenVaultContent;
            AddUserControl(vaultPage);
            UpdateButtonStyles(vaults);
        }

        private void AddUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        // Button Event Handlers (Linked from Designer)

        private void UC_Dashboard(object sender, EventArgs e)
        {
            UC_Dashboard uc = CreateDashboardWithEvents();
            AddUserControl(uc);
            UpdateButtonStyles(Dashboard);
        }

        private void UC_Vaults(object sender, EventArgs e)
        {
            UC_Vaults uc = new UC_Vaults(_vaultService);
            uc.OpenVaultContentRequested += OpenVaultContent;
            AddUserControl(uc);
            UpdateButtonStyles(vaults);
        }

        private void UC_Allfiles(object sender, EventArgs e)
        {
            UC_AllFiles uc = new UC_AllFiles(_fileService, _vaultService);
            uc.OpenVaultContentRequested += OpenVaultContent;
            AddUserControl(uc);
            UpdateButtonStyles(Allfiles);
        }

        private void UC_Search(object sender, EventArgs e)
        {
            UC_Search uc = new UC_Search(_fileService, _vaultService);
            uc.OpenVaultContentRequested += OpenVaultContent;
            AddUserControl(uc);
            UpdateButtonStyles(Search);
        }

        private void UC_ActivityLog(object sender, EventArgs e)
        {
            UC_ActivityLog uc = new UC_ActivityLog(_activityService);
            AddUserControl(uc);
            UpdateButtonStyles(ActivityLog);
        }

        private void UC_User(object sender, EventArgs e)
        {
            UC_Profile uc = new UC_Profile(_userService, _activityService, _cryptoService);
            AddUserControl(uc);
            UpdateButtonStyles(User);
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            SessionManager.ClearSession();
            Login loginForm = new Login(_authService);
            loginForm.Show();
            this.Hide();
            UpdateButtonStyles(Logout);
        }

        // Helper to update button visual state
        private void UpdateButtonStyles(Control activeButton)
        {
            ButtonOff();
            if (activeButton is ReaLTaiizor.Controls.MaterialButton mb) // Check if they are MaterialButton or cuiButton
            {
                // Not using MaterialButton here based on Designer.
            }
            // Based on Designer, they are CuoreUI.Controls.cuiButton
            if (activeButton is CuoreUI.Controls.cuiButton btn)
            {
                btn.NormalBackground = Color.FromArgb(213, 76, 12);
                btn.NormalForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void ButtonOff()
        {
            ResetButtonStyle(Dashboard);
            ResetButtonStyle(vaults);
            ResetButtonStyle(Allfiles);
            ResetButtonStyle(ActivityLog);
            ResetButtonStyle(User);
            ResetButtonStyle(Logout);
            ResetButtonStyle(Search);
        }

        private void ResetButtonStyle(CuoreUI.Controls.cuiButton btn)
        {
            if (btn == null) return;
            btn.NormalBackground = Color.Transparent;
            btn.NormalForeColor = Color.Black;
        }

        private void cuiPanelGradient1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TestDatabaseConnection_Click(object sender, EventArgs e)
        {
            DatabaseConnectionService.TestConnectionWithMessage();
        }
    }
}

