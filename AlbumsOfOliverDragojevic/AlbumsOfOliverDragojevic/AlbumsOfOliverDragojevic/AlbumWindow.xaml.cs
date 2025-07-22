using AlbumsOfOliverDragojevic.Helpers;
using AlbumsOfOliverDragojevic.Models;
using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using static AlbumsOfOliverDragojevic.Enums.UserRole;

namespace AlbumsOfOliverDragojevic
{
    /// <summary>
    /// Interaction logic for AlbumWindow.xaml
    /// </summary>
    public partial class AlbumWindow : Window
    {
        private DataIO serializer = new DataIO();
        public ObservableCollection<Album> Albums { get; set; }
        private User user { get; set; }
        public AlbumWindow(User user)
        {
            InitializeComponent();

            this.user = user;

            if(user.UserRole.Equals(UserRoles.ADMIN))
            {
                CheckBoxDataGridTemplateColumn.Visibility = Visibility.Visible;
                AdminControlStackPanel.Visibility = Visibility.Visible;
            }

            Albums = serializer.DeSerializeObject<ObservableCollection<Album>>("AllRtfFiles.xml");

            if (Albums == null)
            {
                MessageBox.Show("Nothing has been read.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.DataContext = this;

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hyperlink = sender as Hyperlink;

            if(hyperlink?.DataContext is Album album)
            {
                if (user.UserRole.Equals(UserRoles.ADMIN))
                {
                    AdminWindow adminWindow = new AdminWindow(album);
                    adminWindow.Show();

                    AlbumsDataGrid.Items.Refresh();
                }
                else if (user.UserRole.Equals(UserRoles.VISITOR))
                {
                    VisitorWindow visitorWindow = new VisitorWindow(album);
                    visitorWindow.Show();
                }
            }

        }

        private void SelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var albums = AlbumsDataGrid.ItemsSource as ObservableCollection<Album>;
            if(albums == null) return;

            foreach (var album in albums)
            {
                album.IsSelected = true;
            }

            AlbumsDataGrid.Items.Refresh();
        }
        private void SelectAllCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
           if(Albums.Count > 0)
            {
                foreach (var album in Albums)
                {
                    album.IsSelected = false;
                }

                AlbumsDataGrid.Items.Refresh();
            }
        }

        private void AddNewAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            AddAlbumWindow addAlbumWindow = new AddAlbumWindow();

            addAlbumWindow.AlbumAdded += (newAlbum) =>
            {
                // Dodaj novi album u kolekciju i osveži prikaz
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Albums.Add(newAlbum);
                    AlbumsDataGrid.Items.Refresh();
                });
            };

            addAlbumWindow.Show();
        }

        private void DeleteAlbumButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to delete album?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if(messageBoxResult == MessageBoxResult.Yes)
            {
                var selected = Albums.Where(a => a.IsSelected).ToList();

                if (selected.Count > 0)
                {
             
                    foreach (var album in selected)
                    {
                        if(album.IsSelected)
                        {
                           Albums.Remove(album);
                           MessageBox.Show("The album was successfully deleted.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    AlbumsDataGrid.Items.Refresh(); 
                } else
                {
                    MessageBox.Show("An error occurred while deleting the album.",
                            "Error",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                }
            } else
            {
                MessageBox.Show("Album deletion has been canceled.", "Canceled", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExitFromAlbumsButton_Click(object sender, RoutedEventArgs e)
        {
            SaveDataAsXML();
            this.Close();      
        }

        private void SaveDataAsXML()
        {
            serializer.SerializeObject<ObservableCollection<Album>>(Albums, "AllRtfFiles.xml");
        }

        private void AlbumCheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if(checkBox.DataContext is Album album)
            {
                album.IsSelected = checkBox.IsChecked == true;
            } 
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
