using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageRename.Base.Model;

namespace ImageRename.Base
{
    public class ReportProgressEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
    public class ProcessFolder
    {

        public bool DebugDontRenameFile { get; set; } = false;
        private List<IImageFile> _images;
        private string _rootFolder;

        #region ProgressEvent
        public event EventHandler<ReportProgressEventArgs> ReportProgress;
        protected virtual void OnReportProgress(ReportProgressEventArgs e)
        {
            var handler = ReportProgress;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        private void ReportProgressLog(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
            var e = new ReportProgressEventArgs()
            { Message = message };

            OnReportProgress(e);
        }

        public void Process(string root)
        {
            if (!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException(root);
            }
            _rootFolder = root;
            _images = new List<IImageFile>();
            FindFiles(root);
            RenameFiles();
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

            ReportProgressLog($"{sourceFile.Replace(_rootFolder, string.Empty).PadRight(30)} ==> {destinationFile.Replace(_rootFolder, string.Empty)}");
        }


        private void FindFiles(string root)
        {
            string[] sFilter = "jpg;jpeg;cr2;nef;mov;m4a".Split(';');
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