using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace AlbumsOfOliverDragojevic.Models
{
    [Serializable]
    public class Album : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _publishedYear = 0;
        public int PublishedYear
        {
            get => _publishedYear;

            set
            {
                _publishedYear = value;
                OnPropertyChanged(nameof(PublishedYear));
            }
        }

        private string _albumName = string.Empty;
        public string AlbumName
        {
            get => _albumName;
            set
            {
                _albumName = value;
                OnPropertyChanged(nameof(AlbumName));
            }
        }

        private string _pathToImage = string.Empty;
        public string PathToImage
        {
            get => _pathToImage;
            set
            {
                _pathToImage = value;
                OnPropertyChanged(nameof(PathToImage));
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        public BitmapImage ImageSource
        {
            get
            {
                try
                {
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string fullPath = Path.Combine(baseDir, PathToImage.TrimStart('/'));
                    if (File.Exists(fullPath))
                    {
                        return new BitmapImage(new Uri(fullPath, UriKind.Absolute));
                    }
                }
                catch
                {

                }
                return null;
            }
        }


        public string _pathToRTFFile = string.Empty;
        public string PathToRTFFile 
        { 
            get => _pathToRTFFile;
            set
            {
                _pathToRTFFile = value;
                OnPropertyChanged(nameof(PathToRTFFile));
            } 
        }

        private string _dateAdded = string.Empty; // dd/mm/yyyy 

        public string DateAdded
        {
            get => _dateAdded;
            set
            {
                _dateAdded = value;
                OnPropertyChanged(nameof(DateAdded));
            }
        }
        public bool IsSelected { get; set; }

        public Album()
        {
            IsSelected = false;
        }

        public Album(int publishedYear, string albumName, string pathToImage, string pathToRTFFile, string dateAdded, bool isSelected)
        {
            PublishedYear = publishedYear;
            AlbumName = albumName;
            PathToImage = pathToImage;
            PathToRTFFile = pathToRTFFile;
            DateAdded = dateAdded;
            IsSelected = isSelected;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
