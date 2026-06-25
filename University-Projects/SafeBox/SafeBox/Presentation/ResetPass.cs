using System;
using System.Windows.Forms;
using SafeBox.Application.Interfaces;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;
using SafeBox.Infrastructure.Services;
using SafeBox.Presentation;

namespace SafeBox
{
    public partial class ResetPass : Form
    {
        public ResetPass()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // Create services and show login form
            var userRepository = new UserRepository();
            var cryptoService = new CryptoService();
            IAuthService authService = new AuthService(userRepository, cryptoService);

            Login loginForm = new Login(authService);
            loginForm.Show();
            this.Hide();
        }
    }
}
