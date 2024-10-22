using Microsoft.Win32;
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
using System.Windows.Shapes;
using WPFAssignment.Models;

namespace WPFAssignment.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            var email = EmailInput.Text;
            var password = PasswordInput.Password;

            if (UserRepository.ValidateUser(email, password))
            {
                // Navigate to the Home page
                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.MainFrame.Navigate(new Home());
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            // Navigate to the Register page
            var registerPage = new Register();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(registerPage);
        }

        private void OnForgotPasswordClick(object sender, RoutedEventArgs e)
        {
            // Navigate to the Forgot Password page
            var forgotPasswordPage = new ForgotPassword();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(forgotPasswordPage);
        }
    }
}
