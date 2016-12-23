using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows;

namespace HashChecker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Md5Hash md5Hash;

        public MainWindow()
        {
            this.md5Hash = new Md5Hash();
            InitializeComponent();
        }

        private void FileDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = files[0];

                this.md5Hash.setMd5HashFromFile(filePath);

                Md5File.Text = this.md5Hash.md5File;
                Sha1File.Text = createSha1Hash(filePath);

                checkHashes();
            }
        }

        private string createSha1Hash(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    return BitConverter.ToString(sha1.ComputeHash(stream)).Replace("-", "‌​").ToLower();
                }
            }
        }

        private void checkHashes()
        {
            if (isValid())
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

        private Boolean isValid()
        {
            return true;
        }
    }

}
