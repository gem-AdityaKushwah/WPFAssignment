using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPFAssignment.Models;
using System.Windows.Navigation;

namespace WPFAssignment.Views
{
    public partial class Home : Page
    {
        private ObservableCollection<UserDetails> _allUsers = new ObservableCollection<UserDetails>();
        private ObservableCollection<UserDetails> _filteredUsers = new ObservableCollection<UserDetails>();

        public Home()
        {
            InitializeComponent();
            LoadUserList();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.SetNavigationUIVisibility(NavigationUIVisibility.Hidden);
        }

        // Load the user list
        private void LoadUserList()
        {
            // Retrieve all users from the UserRepository
            var usersFromRepo = UserRepository.GetAllUsers();
            foreach (var user in usersFromRepo)
            {
                _allUsers.Add(user);
            }
            _filteredUsers = new ObservableCollection<UserDetails>(_allUsers);

            // Bind the filtered list to the ListView
            UserList.ItemsSource = _filteredUsers;
        }

        // Event triggered when search text changes
        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBar.Text.ToLower();
            _filteredUsers.Clear();

            // Filter the users based on the search text
            var filtered = _allUsers.Where(user =>
                user.FirstName.ToLower().Contains(searchText) ||
                user.LastName.ToLower().Contains(searchText) ||
                user.Email.ToLower().Contains(searchText));

            foreach (var user in filtered)
            {
                _filteredUsers.Add(user);
            }
        }

        // Event handler for user selection
        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UserList.SelectedItem != null)
            {
                var selectedUser = (UserDetails)UserList.SelectedItem;
                MessageBox.Show($"Selected User: {selectedUser.FirstName} {selectedUser.LastName}");
            }
        }

        // Logout functionality
        private void OnLogoutClick(object sender, RoutedEventArgs e)
        {
            // Redirect back to the login page
            var loginPage = new Login();
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(loginPage);
            mainWindow.SetNavigationUIVisibility(NavigationUIVisibility.Visible);
        }
    }
}
