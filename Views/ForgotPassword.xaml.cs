using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFAssignment.Models;

namespace WPFAssignment.Views
{

    public partial class ForgotPassword : Page
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void OnResetPasswordClick(object sender, RoutedEventArgs e)
        {
            var email = EmailInput.Text;
            var password = PasswordInput.Password;
            var confirmPassword = ConfirmPasswordInput.Password;

            if (password == confirmPassword)
            {
                UserRepository.ResetPassword(email, password);
                MessageBox.Show("Password has been reset successfully.");
                var loginPage = new Login();
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(loginPage);
            }
            else
            {
                MessageBox.Show("Passwords do not match.");
            }
        }
    }
}
