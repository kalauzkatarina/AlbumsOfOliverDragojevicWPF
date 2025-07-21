using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AlbumsOfOliverDragojevic.Enums;
using AlbumsOfOliverDragojevic.Helpers;
using AlbumsOfOliverDragojevic.Models;
using Notification.Wpf;
using static AlbumsOfOliverDragojevic.Enums.UserRole;

namespace AlbumsOfOliverDragojevic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataIO serializer = new DataIO(); 
        public ObservableCollection<User> Users;
        public MainWindow()
        {
            InitializeComponent();

            UserRoleComboBox.ItemsSource = Enum.GetValues(typeof(UserRole.UserRoles));

            Users = serializer.DeSerializeObject<ObservableCollection<User>>("UserRepository.xml");
        }

        private void LogInCompleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateFormData())
            {

                bool isLoggedIn = false;
                foreach (var user in Users)
                {
                    if(UsernameTextBox.Text == user.Username && PasswordBox.Password == user.Password && UserRoleComboBox.SelectedItem.Equals(user.UserRole))
                    {
                        isLoggedIn = true;

                        AlbumWindow albumWindow = new AlbumWindow(user);
                        albumWindow.Show();

                        //MessageBox.Show("Successfully logged in.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                if (!isLoggedIn)
                {
                    MessageBox.Show($"User ({UsernameTextBox.Text}) not found in the repository.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Please check all fields and try again.",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsernamePlaceholder.Visibility = string.IsNullOrEmpty(UsernameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UsernamePlaceholder.Visibility = Visibility.Collapsed;
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
                UsernamePlaceholder.Visibility = Visibility.Visible;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = string.IsNullOrEmpty(PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
                PasswordPlaceholder.Visibility = Visibility.Visible;
        }

        private bool ValidateFormData()
        {
            bool IsValid = true;

            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                IsValid = false;
                UsernameErrorLabel.Content = "Form field cannot be left empty!";
                UsernameTextBox.BorderBrush = Brushes.Red;
            }else
            {
                UsernameErrorLabel.Content = string.Empty;
                UsernameTextBox.BorderBrush= Brushes.Gray;
            }

            if (string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                IsValid = false;
                PasswordErrorLabel.Content = "Password cannot be empty!";
                PasswordBox.BorderBrush = Brushes.Red;
            }
            else
            {
                PasswordErrorLabel.Content = string.Empty;
                PasswordBox.BorderBrush = Brushes.Gray;
            }


            if (UserRoleComboBox.SelectedItem == null)
            {
                IsValid = false;
                UserRoleErrorLabel.Content = "Please select a user role.";
                UserRoleComboBox.Tag = "error";
            }
            else
            {
                UserRoleErrorLabel.Content = string.Empty;
                UserRoleComboBox.Tag = null;
            }

            return IsValid;
        }
    }
}
