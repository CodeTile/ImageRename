using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using ImageRename.Core.Model;

namespace ImageRename.Core
{

    public class ProcessFolder
    {

        public bool DebugDontRenameFile { get; set; } = false;
        private ObservableCollection<IImageFile> _images;
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
            if (_images != null)
            {
                e.TotalFileCount = _images.Count();
                e.FilesToRename = _images.Count(c => c.NeedsRenaming);
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
            _images = new ObservableCollection<IImageFile>();
            _images.CollectionChanged += _images_CollectionChanged;
            FindFiles(root);
            RenameFiles();
        }

        private void _images_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ReportFindFileProgress();
        }

        private void RenameFiles()
        {
            if (_images == null || !_images.Any(a => a.NeedsRenaming == true))
            {
                return;
            }

            foreach (var item in _images.Where(w => w.NeedsRenaming == true))
            {
                RenameFile(item);
            }
        }

        private void RenameFile(IImageFile item)
        {
            var sourceFile = item.FileDetails.FullName;
            var destinationFile = item.NewFilePath;
            if (!DebugDontRenameFile)
            {
                File.Move(sourceFile, destinationFile);
            }
            item.FileDetails = new FileInfo(destinationFile);
            ReportFindFileProgress();

            ReportRenamingProgress($"{sourceFile.Replace(_rootFolder, string.Empty).PadRight(30)} ==> {destinationFile.Replace(_rootFolder, string.Empty)}");
        }


        private void FindFiles(string root)
        {
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
                            _images.Add(new ImageFile(file));
                            break;
                        case "mov":
                        case "mp4":
                        case "m4a":
                            _images.Add(new VideoFile(file));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}