using System.Windows;

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
        }

        private void btnProcessedBrowse_Click(object sender, RoutedEventArgs e)
        {
        }

        //private void ShowDialog(string description, string originalPath)
        //{
        //    var dialog = new FolderBrowserDialog
        //    {
        //        ShowNewFolderButton = false
        //    };

        //    var result = dialog.ShowDialog();
        //    if (result == System.Windows.Forms.DialogResult.OK &&
        //        Directory.Exists(dialog.SelectedPath))
        //    {
        //        txtPath.Text = dialog.SelectedPath;
        //    }
        //}
    }
}