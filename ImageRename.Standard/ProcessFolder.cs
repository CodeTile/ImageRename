using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Geocoding;

using Geocoding.Microsoft;
using ImageRename.Standard.Model;
using Microsoft.Extensions.Configuration;

namespace ImageRename.Standard
{
    public class ProcessFolder
    {
        private readonly IConfiguration Configuration;
        private IGeocoder _BingGeoCoder;
        private bool? _hasInternet;
        private IGeocoder _MapQuestGeoCoder;
        public ObservableCollection<IImageFile> _images;

        public ProcessFolder(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public bool DebugDontRenameFile { get; set; } = false;
        public ExifLibrary.ImageFile ExifFileDetails { get; set; }

        public bool HasInternet
        {
            get
            {
                if (_hasInternet == null)
                {
                    HasInternet = CheckForInternetConnection();
                }
                return (bool)_hasInternet;
            }
            set

            { _hasInternet = value; }
        }

        public bool MoveToProcessedByYear { get; set; }
        public string ProcessedPath { get; set; }
        public string SourcePath { get; set; }

        #region RenameProgressEvent

        public event EventHandler<ReportRenameProgressEventArgs> ReportRenameProgress;

        /// <summary>
        /// Rename file event
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnReportRenaimingProgress(ReportRenameProgressEventArgs e)
        {
            ReportRenameProgress?.Invoke(this, e);
        }

        #endregion RenameProgressEvent

        #region FindFileProgressEvent

        public event EventHandler<ReportFindFilesProgressEventArgs> ReportFoundFileProgress;

        /// <summary>
        /// Event for a file has been found.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnReportFilesFoundProgress(ReportFindFilesProgressEventArgs e)
        {
            ReportFoundFileProgress?.Invoke(this, e);
        }

        #endregion FindFileProgressEvent

        private void _images_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ReportFindFileProgress();
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

        private IGeocoder GetBingGeoCoder()
        {
            if (_BingGeoCoder == null && !string.IsNullOrEmpty(Configuration["MapKeys:Bing"]) && HasInternet)
            {
                _BingGeoCoder = new BingMapsGeocoder(Configuration["MapKeys:Bing"])
                { IncludeNeighborhood = true };
            }
            return _BingGeoCoder;
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

        private void RenameFile(IImageFile item)
        {
            var sourceFile = item.SourceFileInfo.FullName;
            var destinationFile = item.DestinationFilePath;
            if (File.Exists(destinationFile))
            {
                ReportRenamingProgress($"{sourceFile.Replace(SourcePath, string.Empty).PadRight(30)} ############# File Exists");
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

            ReportRenamingProgress($"{sourceFile.Replace(SourcePath, string.Empty).PadRight(30)} ==> {destinationFile.Replace(SourcePath, string.Empty)}");
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
                    ReportRenamingProgress($"\r\n##############Error\r\n{item.SourceFileInfo.FullName.Replace(SourcePath, string.Empty)}r\n{ex.Message}\r\n####################\n\n");
                }
            }
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

        private void ReportRenamingProgress(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
            var e = new ReportRenameProgressEventArgs()
            { Message = message };

            OnReportRenaimingProgress(e);
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

        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead(Configuration["InternetConnectionTestURL"]))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public void FindFiles(string root)
        {
            if (MoveToProcessedByYear && !string.IsNullOrEmpty(ProcessedPath))
            {
                ProcessedPath = Path.GetFullPath(ProcessedPath);
                if (!Directory.Exists(ProcessedPath))
                {
                    Directory.CreateDirectory(ProcessedPath);
                }
            }

            foreach (var file in Directory.GetFiles(root, "*", SearchOption.AllDirectories))
            {
                _images.Add(ProcessFile(file));
            }
        }

        public string GetKeywordsFromLocation(IGPSCoridates gps)
        {
            var location = new Location(gps.DegreesLatitude, gps.DegreesLongitude);
            IGeocoder geocoder;
            string keyWords = null;
            var priorities = Configuration["MapKeys:Priority"].Split(',');
            foreach (var geocoderKey in priorities)
            {
                Address address = null;

                #region get the GeoCoder object

                switch (geocoderKey.ToUpper())
                {
                    case "BING":
                        geocoder = GetBingGeoCoder();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(geocoderKey);
                }

                #endregion get the GeoCoder object

                if (geocoder == null)
                {
                    continue;
                }
                var addresses = Task.Run(async () => await geocoder.ReverseGeocodeAsync(location));
                if (addresses != null && addresses.Result.Any())
                {
                    address = addresses.Result?.First();
                }
                else
                {
                    continue;
                }
                switch (address.Provider.ToUpper())
                {
                    case "BING":
                        BingAddress a = (BingAddress)address;
                        keyWords = a.CountryRegion;
                        break;

                    default:
                        break;
                }
                if (!string.IsNullOrEmpty(keyWords))
                {
                    break;
                }
            }
            return keyWords;
        }

        public void Process(string root)
        {
            if (!Directory.Exists(root))
            {
                throw new DirectoryNotFoundException($"\r\nFolder to process has not been found.\r\n\t{root}");
            }

            GetBingGeoCoder();

            SourcePath = root;
            _images = new ObservableCollection<IImageFile>();
            _images.CollectionChanged += _images_CollectionChanged;
            FindFiles(root);
            RenameFiles();
            DeleteEmptySourceFolders(SourcePath);
        }

        public IImageFile ProcessFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException(filename);
            }
            string[] sFilter = "jpg;jpeg;cr2;nef;mov;m4a;mp4".Split(';');
            IImageFile image = null;
            var fileExtention = filename.Split('.').Last().ToLower();
            if (sFilter.Contains(fileExtention))
            {
                switch (fileExtention)
                {
                    case "nef":
                        image = new ImageFileNEF(filename, ProcessedPath);
                        break;

                    case "mov":
                        image = new VideoFile(filename, ProcessedPath);
                        break;

                    default:
                        image = new ImageFile(filename, ProcessedPath);
                        break;
                }

                ReverseGeocode(image);
            }
            return image;
        }

        public void ReverseGeocode(IImageFile image)
        {
            if (!HasInternet || image.GPS == null)
            {
                return;
            }
            var keywords = image.KeyWords + ";" + GetKeywordsFromLocation(image.GPS);
            var newKeywords = (String.Join(";", keywords.Split(';').Distinct().ToList()) + ";").Replace(";;", ";");
            if (newKeywords.StartsWith(";"))
            {
                newKeywords = newKeywords.Substring(1);
            }
            image.KeyWords = newKeywords;
        }
    }
}