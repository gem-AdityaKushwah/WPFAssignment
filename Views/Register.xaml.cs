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

    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            // Collect data and register user
            var user = new UserDetails
            {
                FirstName = FirstNameInput.Text,
                LastName = LastNameInput.Text,
                DOB = DOBInput.SelectedDate.GetValueOrDefault(),
                Email = EmailInput.Text,
                Password = PasswordInput.Password
            };

            UserRepository.AddUser(user);
            MessageBox.Show("Registration complete!");

            // Redirect back to the login page
            var loginPage = new Login();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(loginPage);
        }
    }
}

