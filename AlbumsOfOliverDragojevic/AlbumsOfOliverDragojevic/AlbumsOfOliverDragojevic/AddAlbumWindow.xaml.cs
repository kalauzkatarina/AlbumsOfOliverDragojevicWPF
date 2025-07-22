using AlbumsOfOliverDragojevic.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace AlbumsOfOliverDragojevic
{
    /// <summary>
    /// Interaction logic for AddAlbumWindow.xaml
    /// </summary>
    public partial class AddAlbumWindow : Window, INotifyPropertyChanged
    {
        public class NamedBrush
        {
            public string Name { get; set; }
            public Brush Brush { get; set; }
        }
        public event Action<Album> AlbumAdded;

        private string _selectedImagePath;
        private string SelectedImagePath
        {   get => _selectedImagePath;
            set
            {
                _selectedImagePath = value;
                OnPropertyChanged(nameof(SelectedImagePath));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private string currentDateTime;
        private string _albumNamePlaceholder = "Enter album name";
        private string _publishedYearPlaceholder = "Enter published year";
        public AddAlbumWindow()
        {
            InitializeComponent();

            FontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            var systemColors = typeof(Colors)
                    .GetProperties()
                    .Select(p => new NamedBrush
                    {
                        Name = p.Name,
                        Brush = new SolidColorBrush((Color)p.GetValue(null))
                    })
                    .ToList();

            FontColorComboBox.ItemsSource = systemColors;

            currentDateTime = DateTime.Now.ToString("dd/MM/yyyy");
            DateAddedTextBox.Text = currentDateTime;

            this.DataContext = this;

            if (string.IsNullOrWhiteSpace(AlbumNameTextBox.Text))
            {
                AlbumNameTextBox.Text = _albumNamePlaceholder;
                AlbumNameTextBox.Foreground = Brushes.LightSlateGray;
            }

            if (string.IsNullOrWhiteSpace(PublishedYearTextBox.Text))
            {
                PublishedYearTextBox.Text = _publishedYearPlaceholder;
                PublishedYearTextBox.Foreground = Brushes.LightSlateGray;
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void ChooseImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*png;*.jpg;*jpeg";

            if (dialog.ShowDialog() == true)
            {
                SelectedImagePath = dialog.FileName;
                ImagePreview.Source = new BitmapImage(new Uri(SelectedImagePath));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateFormData())
            {
                string albumName = AlbumNameTextBox.Text;
                if(string.IsNullOrWhiteSpace(AlbumNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PublishedYearTextBox.Text) ||
                    string.IsNullOrWhiteSpace(DateAddedTextBox.Text) ||
                    SelectedImagePath == null)
                {
                    MessageBox.Show("All files must be filled!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string rtfFileName = $"{albumName.Replace(" ", "")}.rtf";
                string rtfFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RtfFiles");
                Directory.CreateDirectory(rtfFolder);
                string rtfPath = System.IO.Path.Combine(rtfFolder, rtfFileName);

                using (FileStream fs = new FileStream(rtfPath, FileMode.Create))
                {
                    TextRange range = new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd);
                    range.Save(fs, DataFormats.Rtf);
                }

                string relativeRtfPath = $"RtfFiles/{rtfFileName}";

                Album newAlbum = new Album
                {
                    AlbumName = albumName,
                    PublishedYear = int.Parse(PublishedYearTextBox.Text),
                    DateAdded = currentDateTime,
                    PathToImage = ImagePreview.Source.ToString(),
                    PathToRTFFile = relativeRtfPath,
                    IsSelected = false
                };

                AlbumAdded?.Invoke(newAlbum);
                MessageBox.Show("Successfully added the album.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            } else
            {
                MessageBox.Show("Album could not be added. Please check all fields and try again.",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyComboBox.SelectedItem != null && !EditorRichTextBox.Selection.IsEmpty)
            {
                EditorRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, FontFamilyComboBox.SelectedItem);
            }
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeComboBox.SelectedItem is ComboBoxItem selectedItem &&
                 double.TryParse(selectedItem.Content.ToString(), out double size) &&
                 !EditorRichTextBox.Selection.IsEmpty)
            {
                EditorRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, size);
            }
        }

        private void FontColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontColorComboBox.SelectedItem is NamedBrush selectedBrush && !EditorRichTextBox.Selection.IsEmpty)
            {
                EditorRichTextBox.Selection.ApplyPropertyValue(Inline.ForegroundProperty, selectedBrush.Brush);
            }
        }

        private void EditorRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object fontWeight = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            BoldToggleButton.IsChecked = (fontWeight != DependencyProperty.UnsetValue) && (fontWeight.Equals(FontWeights.Bold));

            object fontStyle = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            ItalicToggleButton.IsChecked = (fontStyle != DependencyProperty.UnsetValue) && (fontStyle.Equals(FontStyles.Italic));

            object textDecorations = EditorRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            UnderlineToggleButton.IsChecked = (textDecorations != DependencyProperty.UnsetValue) &&
                                              (textDecorations.Equals(TextDecorations.Underline));

            object fontFamily = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            FontFamilyComboBox.SelectedItem = fontFamily;


            object fontSize = EditorRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty);
            if (fontSize != DependencyProperty.UnsetValue)
            {
                string size = fontSize.ToString();
                foreach (ComboBoxItem item in FontSizeComboBox.Items)
                {
                    if (item.Content.ToString() == size)
                    {
                        FontSizeComboBox.SelectedItem = item;
                        break;
                    }
                }
            }
            UpdateWordCount();
        }

        private void UpdateWordCount()
        {
            TextRange range = new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd);
            string text = range.Text.Trim();
            int wordCount = string.IsNullOrWhiteSpace(text) ? 0 : text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            WordCountTextBlock.Text = $"Words: {wordCount}";
        }

        private bool ValidateFormData()
        {
            bool isValid = true;

            if(AlbumNameTextBox.Text.Trim().Equals(string.Empty) || AlbumNameTextBox.Text.Trim().Equals(_albumNamePlaceholder))
            {
                isValid = false;
                AlbumNameErrorLabel.Content = "Form field cannot be left empty!";
                AlbumNameTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                AlbumNameErrorLabel.Content = string.Empty;
                AlbumNameTextBox.BorderBrush = Brushes.Gray;
            }
          
            if(PublishedYearTextBox.Text.Trim().Equals(string.Empty) || PublishedYearTextBox.Text.Trim().Equals(_publishedYearPlaceholder))
            {
                isValid = false;
                PublishedYearErrorLabel.Content = "Form field cannot be left empty!";
                PublishedYearTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                PublishedYearErrorLabel.Content = string.Empty;
                PublishedYearTextBox.BorderBrush = Brushes.Gray;
            }

            TextRange textRange = new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd);
            string richText = textRange.Text.Trim();

            if (string.IsNullOrEmpty(richText))
            {
                isValid = false;
                RichTextBoxErrorLabel.Content = "RichTextBox content cannot be empty!";
                EditorRichTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                RichTextBoxErrorLabel.Content = string.Empty;
                EditorRichTextBox.BorderBrush = Brushes.Gray;
            }

            return isValid;
        }

        private void AlbumNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (AlbumNameTextBox.Text.Trim().Equals(_albumNamePlaceholder))
            {
                AlbumNameTextBox.Text = string.Empty;
                AlbumNameTextBox.Foreground = Brushes.Black;
            }
        }

        private void AlbumNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (AlbumNameTextBox.Text.Trim().Equals(string.Empty))
            {
                AlbumNameTextBox.Text = _albumNamePlaceholder;
                AlbumNameTextBox.Foreground = Brushes.LightSlateGray;
            }
        }

        private void PublishedYearTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (PublishedYearTextBox.Text.Trim().Equals(_publishedYearPlaceholder))
            {
                PublishedYearTextBox.Text = string.Empty;
                PublishedYearTextBox.Foreground = Brushes.Black;
            }
        }

        private void PublishedYearTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PublishedYearTextBox.Text.Trim().Equals(string.Empty))
            {
                PublishedYearTextBox.Text = _publishedYearPlaceholder;
                PublishedYearTextBox.Foreground = Brushes.LightSlateGray;
            }
        }

        private void EditorRichTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            RichTextBoxPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void EditorRichTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextRange textRange = new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd);
            string text = textRange.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                RichTextBoxPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                RichTextBoxPlaceholder.Visibility = Visibility.Collapsed;
            }
        }

        private void EditorRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange textRange = new TextRange(EditorRichTextBox.Document.ContentStart, EditorRichTextBox.Document.ContentEnd);
            string text = textRange.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                if (!EditorRichTextBox.IsFocused)
                    RichTextBoxPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                RichTextBoxPlaceholder.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
