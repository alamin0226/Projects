using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;
using SafeBox.Application.Interfaces;
using SafeBox.Domain.Contracts.Repositories;
using SafeBox.Domain.DTOs.Auth;
using SafeBox.Presentation;
using System;
using System.Windows.Forms;
using SafeBox.Infrastructure.Repositories;


namespace SafeBox.Presentation
{
    public partial class Registration : Form
    {
        private readonly IAuthService _authService;
        private readonly UserService _userService;


        public Registration(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            UserRepository userRepo = new UserRepository();
            ActivityLogRepository activityRepo = new ActivityLogRepository();
            
            _userService = new UserService(userRepo, activityRepo);
            
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            var req = new RegisterRequest
            {
                Username = txtUserName.Text,
                Email = txtEmail.Text,
                Password = txtPass.Text,
                ConfirmPassword = txtConfirmPass.Text
            };

            var result = _userService.Register(req);

            if (result.Success)
            {
                MessageBox.Show(result.Message, "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // চাইলে Login form ওপেন
                // new LoginForm().Show();
                // this.Hide();
            }
            else
            {
                MessageBox.Show(result.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(_authService);
            login.Show();
            this.Hide();
        }
    }
}
