using System;
using System.Windows;

namespace HashChecker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Md5Hash md5Hash;
        private Sha1Hash sha1Hash;

        public MainWindow()
        {
            this.md5Hash = new Md5Hash();
            this.sha1Hash = new Sha1Hash();
            InitializeComponent();
        }

        private void FileDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = files[0];

                this.md5Hash.SetMd5HashFromFile(filePath);
                this.sha1Hash.SetHashFromFile(filePath);

                Md5File.Text = this.md5Hash.Md5File;
                Sha1File.Text = this.sha1Hash.FileHash;

                CheckHashes();
            }
        }

        private void CheckHashes()
        {
            if (IsValid())
            {
                ValidIcon.Visibility = Visibility.Visible;
                InvalidIcon.Visibility = Visibility.Hidden;
            }
            else
            {
                ValidIcon.Visibility = Visibility.Hidden;
                InvalidIcon.Visibility = Visibility.Visible;
            }
        }

        private Boolean IsValid()
        {
            return this.md5Hash.IsEquals() || this.sha1Hash.IsEquals();
        }

        private void HashChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Md5Input.Text = Md5Input.Text.Trim();
            Sha1Input.Text = Sha1Input.Text.Trim();
            this.md5Hash.Md5Input = Md5Input.Text;
            this.sha1Hash.InputHash = Sha1Input.Text;

            CheckHashes();
        }
    }

}
