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

                this.md5Hash.setMd5HashFromFile(filePath);
                this.sha1Hash.setHashFromFile(filePath);

                Md5File.Text = this.md5Hash.md5File;
                Sha1File.Text = this.sha1Hash.fileHash;

                checkHashes();
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
            return this.md5Hash.isEquals() || this.sha1Hash.isEquals();
        }

        private void Md5Input_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            this.md5Hash.md5Input = Md5Input.Text;
            this.sha1Hash.inputHash = Sha1Input.Text;

            checkHashes();
        }
    }

}
