using System;
using System.Windows.Forms;
using SafeBox.Application.Services;
using SafeBox.Infrastructure.Repositories;
using SafeBox.Infrastructure.Services;
using SafeBox.Presentation;

namespace SafeBox
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            // Test database connection on startup
            TestDatabaseConnection();

            // Manual Dependency Injection Wiring
            var userRepository = new UserRepository();
            var cryptoService = new CryptoService();
            var authService = new AuthService(userRepository, cryptoService);

            // Run application with Login form
            System.Windows.Forms.Application.Run(new Login(authService));
        }

        /// <summary>
        /// Tests the database connection on application startup
        /// </summary>
        private static void TestDatabaseConnection()
        {
            try
            {
                // Ensure DatabaseConnectionService is updated and available
                bool connected = DatabaseConnectionService.TestConnection();
                if (!connected)
                {
                    System.Diagnostics.Debug.WriteLine("Warning: Database connection test failed on startup.");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Database connection successful on startup.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error testing database connection: {ex.Message}");
            }
        }
    }
}
