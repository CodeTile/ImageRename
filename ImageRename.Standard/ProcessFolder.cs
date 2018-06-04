using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using ImageRename.Standard.Model;
using System.Security.Cryptography;

namespace ImageRename.Standard
{

    public class ProcessFolder
    {

        public bool DebugDontRenameFile { get; set; } = false;
        public bool MoveToProcessedByYear { get; set; }
        public string ProcessedPath { get; set; }

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
                throw new DirectoryNotFoundException($"\r\nFolder to process has not been found.\r\n\t{root}");
            }
            _rootFolder = root;
            _images = new ObservableCollection<IImageFile>();
            _images.CollectionChanged += _images_CollectionChanged;
            FindFiles(root);
            RenameFiles();
            DeleteEmptySourceFolders(_rootFolder);
        }

        private void DeleteEmptySourceFolders(string root)
        {
            foreach (var directory in Directory.GetDirectories(root))
            {
                DeleteEmptySourceFolders(directory);
                if (!Directory.GetFiles(directory).Any() &&
                    !Directory.GetDirectories(directory).Any())
                {
                    Directory.Delete(directory, false);
                }
            }
        }

        private void _images_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ReportFindFileProgress();
        }

        private void RenameFiles()
        {
            if (_images == null || !_images.Any(a => a.NeedsRenaming || a.NeedsMoving))
            {
                return;
            }

            foreach (var item in _images.Where(w => w.NeedsRenaming == true || w.NeedsMoving))
            {
                try
                {
                    RenameFile(item);

                }
                catch (Exception ex)
                {
                    ReportRenamingProgress($"\r\n##############Error\r\n{item.SourceFileInfo.FullName.Replace(_rootFolder, string.Empty)}r\n{ex.Message}\r\n####################\n\n");
                }
            }
        }

        private void RenameFile(IImageFile item)
        {
            var sourceFile = item.SourceFileInfo.FullName;
            var destinationFile = item.DestinationFilePath;
            if (File.Exists(destinationFile))
            {
                ReportRenamingProgress($"{sourceFile.Replace(_rootFolder, string.Empty).PadRight(30)} ############# File Exists");
                if (AreFilesTheSame(sourceFile, destinationFile))
                {
                    destinationFile = destinationFile.Replace(item.SourceFileInfo.Extension, $"(Duplicate){item.SourceFileInfo.Extension}");
                }
                destinationFile = GetSequenceFilename(item.DestinationFileInfo);
            }

            if (!DebugDontRenameFile && !File.Exists(destinationFile))
            {
                Helper.CreateDirectory(item.DestinationFileInfo.DirectoryName);
                File.Move(sourceFile, destinationFile);
            }

            item.SourceFileInfo = new FileInfo(destinationFile);
            ReportFindFileProgress();

            ReportRenamingProgress($"{sourceFile.Replace(_rootFolder, string.Empty).PadRight(30)} ==> {destinationFile.Replace(_rootFolder, string.Empty)}");

        }

        private string GetSequenceFilename(FileInfo file)
        {
            var sequenceId = 2;
            var template = file.FullName.Replace(file.Extension, "_{0}" + file.Extension);

            while (File.Exists(string.Format(template, sequenceId)))
            {
                sequenceId++;
            }
            var retval = string.Format(template, sequenceId);
            return retval;
        }

        internal bool AreFilesTheSame(string sourceFile, string destinationFile)
        {
            bool retval = false;

            if (GetMD5(sourceFile) != GetMD5(destinationFile))
            {
                retval = false;
            }

            return retval;
        }

        internal string GetMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
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
                        case "nef":
                            _images.Add(new ImageFileNEF(file, ProcessedPath));
                            break;
                        case "mov":
                            _images.Add(new VideoFile(file, ProcessedPath));
                            break;
                        default:
                            _images.Add(new ImageFile(file, ProcessedPath));
                            break; ;
                    }
                }
            }
        }
    }
}