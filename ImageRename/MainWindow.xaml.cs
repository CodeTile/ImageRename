using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using ImageRename.Standard;
using ImageRename.Standard.Model;

namespace ImageRename
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

        private BackgroundWorker _backgroundWorker;
        private ProcessFolder _processor;

        public ObservableCollection<IImageDetails> ImagesFound { get; private set; }

        private enum ProgressReporting
        {
            PassImageObject = -1,
            FileCountProgress = 10,
            RenameProgress = 20
        }

        private void _processor_ReportFoundFileProgress(object sender, ReportFindFilesProgressEventArgs e)
        {
            string msg = $"{e.FilesToRename}/ {e.TotalFileCount}";
            _backgroundWorker.ReportProgress((int)ProgressReporting.FileCountProgress, msg);
            //_backgroundWorker.ReportProgress(-1, e.Images);
        }



        private void _processor_ReportRenameProgress(object sender, ReportRenameProgressEventArgs e)
        {
            var msg = e.Message.ToString();
            _backgroundWorker.ReportProgress((int)ProgressReporting.RenameProgress, msg);

        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var parameters = (ProcessParameters)e.Argument;
            _processor = new ProcessFolder(Helper.GetConfiguration());

            //_processor.DebugDontRenameFile = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["DebugDontRenameFile"]);
            //_processor.MoveToProcessedByYear = parameters.SortByYear;
            //_processor.ProcessedPath = parameters.ProcessedPath;
            //_processor.MoveToprocessed = parameters.MoveToProcessed;
            //_processor.FindOnly = parameters.FindOnly;
            _processor.ReportRenameProgress += _processor_ReportRenameProgress;
            _processor.ReportFoundFileProgress += _processor_ReportFoundFileProgress;
            _backgroundWorker.ReportProgress(0, "Starting");
            //_processor.Process(parameters.SourcePath);
            _processor.Process(parameters);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //if(e.ProgressPercentage == (int)ProgressReporting.PassImageObject)
            //{
            //    ImagesFound = (ObservableCollection < IImageDetails > )e.UserState;
            //    lvFoundfiles.ItemsSource = ImagesFound;
            //}
            // else
            if (e.ProgressPercentage == (int)ProgressReporting.FileCountProgress)
            {
                txtFileSummary.Content = e.UserState.ToString();
            }
            else
            {
                txtProgress.AppendText($"{e.UserState}\r\n");
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtProgress.AppendText("#######################################\r\n");
            txtProgress.AppendText("###          Finished               ###\r\n");
            txtProgress.AppendText("#######################################\r\n");
            btnProcess.IsEnabled = false;

            lvFoundfiles.ItemsSource = _processor._images;
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            StartProcessing(true);
        }

        private void btnFindPath_Click(object sender, RoutedEventArgs e)
        {
            txtPath.Text = ShowDialog(txtPath.Text);
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            StartProcessing(false);
        }

        private void btnProcessedBrowse_Click(object sender, RoutedEventArgs e)
        {
            txtProcessedPath.Text = ShowDialog(txtProcessedPath.Text);
        }

        private void SetDefaultProcessedPath()
        {
            if (txtProcessedPath == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(txtPath.Text))
            {
                txtProcessedPath.Clear();
            }
            else
            {
                txtProcessedPath.Text = Path.GetFullPath(Path.Combine(txtPath.Text, "..\\ProcessedPhotos"));
            }
        }

        private string ShowDialog(string originalPath)
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

        private void StartProcessing(bool findOnly)
        {
            if (!Directory.Exists(txtPath.Text))
                return;
            txtProgress.Text = string.Empty;
            txtFileSummary.Content = string.Empty;
            Settings.Default.SourceFolder = txtPath.Text;
            Settings.Default.DestinationFolder = txtProcessedPath.Text;
            Settings.Default.Save();
            var processParams = new ProcessParameters()
            {
                ProcessedPath = txtProcessedPath.Text,
                SourcePath = txtPath.Text,
                SortByYear = (bool)chkMoveToProcessedByYear.IsChecked,
                FindOnly = findOnly,
                WriteReverseGeotag = (bool)chkReverseGeotag.IsChecked,
            };
            if ((bool)chkMoveToProcessedFolder.IsChecked)
            {
                processParams.SortByYear = false;
                processParams.ProcessedPath = string.Empty;
            }
            _backgroundWorker.RunWorkerAsync(processParams);
        }

        private void txtPath_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SetDefaultProcessedPath();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtPath.Text = Settings.Default.SourceFolder;
            txtProcessedPath.Text = Settings.Default.DestinationFolder;
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.DoWork += backgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

    }
}