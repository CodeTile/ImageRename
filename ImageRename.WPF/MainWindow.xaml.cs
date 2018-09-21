using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace ImageRename.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFindPath_Click(object sender, RoutedEventArgs e)
        {
            txtPath.Text = ShowDialog(txtPath.Text);
        }

        private void btnProcessedBrowse_Click(object sender, RoutedEventArgs e)
        {
            txtProcessedPath.Text = ShowDialog(txtProcessedPath.Text);
        }

        private string ShowDialog( string originalPath)
        {
            var dialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                SelectedPath = originalPath                
            };

            var result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK &&
                Directory.Exists(dialog.SelectedPath))
            {
                return dialog.SelectedPath;
            }
            else
            {
                return originalPath;
            }
        }
    }
}