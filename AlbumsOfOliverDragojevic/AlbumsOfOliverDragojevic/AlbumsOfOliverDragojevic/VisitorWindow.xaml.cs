using AlbumsOfOliverDragojevic.Models;
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
using System.IO;

namespace AlbumsOfOliverDragojevic
{
    /// <summary>
    /// Interaction logic for VisitorWindow.xaml
    /// </summary>
    public partial class VisitorWindow : Window
    {
        private Album album {  get; set; }
        public VisitorWindow(Album album)
        {
            InitializeComponent();

            this.album = album;
            this.DataContext = album;

            LoadRtfContent(album.PathToRTFFile);
        }

        private void LoadRtfContent(string path)
        {
            try
            {

                if (File.Exists(path))
                {
                    using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        TextRange textRange = new TextRange(rtfPreview.Document.ContentStart, rtfPreview.Document.ContentEnd);
                        textRange.Load(fileStream, DataFormats.Rtf);
                    }
                } else
                {
                    MessageBox.Show("RTF fajl has not been found", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error while loading RTF content", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
