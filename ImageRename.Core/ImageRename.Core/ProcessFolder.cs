using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using ImageRename.Core.Model;

namespace ImageRename.Core
{
    public class ProcessFolder
    {

        public bool DebugDontRenameFile { get; set; } = false;
        public bool MoveToProcessedByYear { get; set; }
        public string ProcessedPath { get; set; }

        public ObservableCollection<IImageFile> Images;
        private string _rootFolder;

        #region RenameProgressEvent
        public event EventHandler<ReportRenameProgressEventArgs> ReportRenameProgress;
        protected virtual void OnReportRenaimingProgress(ReportRenameProgressEventArgs e)
        {
            ReportRenameProgress?.Invoke(this, e);
        }
        #endregion

        #region FindFileProgressEvent
        public event EventHandler<ReportFindFilesProgressEventArgs> ReportFoundFileProgress;
        protected virtual void OnReportFilesFoundProgress(ReportFindFilesProgressEventArgs e)
        {
            ReportFoundFileProgress?.Invoke(this, e);
        }
        #endregion

        private void ReportRenamingProgress(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
            var e = new ReportRenameProgressEventArgs()
            { Message = message };

            OnReportRenaimingProgress(e);
        }

        private void ReportFindFileProgress()
        {

            var e = new ReportFindFilesProgressEventArgs();
            if (Images != null)
            {
                e.TotalFileCount = Images.Count();
                e.FilesToRename = Images.Count(c => c.NeedsRenaming);
            }

            OnReportFilesFoundProgress(e);
        }

        public void Process(string root)
        {
            if (!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException(root);
            }
            _rootFolder = root;
            Images = new ObservableCollection<IImageFile>();
            Images.CollectionChanged += _images_CollectionChanged;
            FindFiles(root);
            RenameFiles();
        }

        private void _images_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ReportFindFileProgress();
        }

        private void RenameFiles()
        {
            if (Images == null || !Images.Any(a => a.NeedsRenaming == true))
            {
                return;
            }

            foreach (var item in Images.Where(w => w.NeedsRenaming ))
            {
                RenameFile(item);
            }
            foreach (var item in Images.Where(w=>w.NeedsMoving))
            {
                if(!File.Exists(item.FileDetails.FullName))
                {
                    continue;
                }
                File.Move(item.FileDetails.FullName, item.ProcessedFullName);
            }
        }

        private void RenameFile(IImageFile item)
        {
            var sourceFile = item.FileDetails.FullName;
            var destinationFile = item.ProcessedFullName;
            if (!DebugDontRenameFile)
            {
                if (!File.Exists(item.FileDetails.FullName))
                {
                    throw new FileNotFoundException(item.FileDetails.FullName);
                }
                Helper.CreateDirectory(item.ProcessedDirectory, true);
                File.Move(sourceFile, destinationFile);
            }
            item.FileDetails = new FileInfo(destinationFile);
            ReportFindFileProgress();

            ReportRenamingProgress($"{sourceFile.Replace(_rootFolder, string.Empty).PadRight(30)} ==> {destinationFile.Replace(_rootFolder, string.Empty)}");
        }


        private void FindFiles(string root)
        {
            if (MoveToProcessedByYear && !string.IsNullOrEmpty(ProcessedPath))
            {
                if (!Directory.Exists(ProcessedPath))
                {
                    Directory.CreateDirectory(ProcessedPath);
                }
            }
            string[] sFilter = "jpg;jpeg;cr2;nef;mov;m4a;mp4".Split(';');
            foreach (var file in Directory.EnumerateFileSystemEntries(root, "*", SearchOption.AllDirectories))

            {
                var fileExtention = file.Split('.').Last().ToLower();
                if (sFilter.Contains(fileExtention))
                {
                    switch (fileExtention)
                    {
                        case "jpg":
                        case "jpeg":
                        case "cr2":
                            Images.Add(new ImageFile(file, ProcessedPath));
                            break;
                        case "mov":
                        case "mp4":
                        case "m4a":
                            Images.Add(new VideoFile(file, ProcessedPath));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}