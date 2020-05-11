using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ExifLibrary;
using Geocoding;

using Geocoding.Microsoft;
using ImageRename.Standard.Model;
using Microsoft.Extensions.Configuration;

namespace ImageRename.Standard
{
    public class ProcessFolder
    {
        public ProcessFolder(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ObservableCollection<IImageDetails> _images;
        private readonly IConfiguration Configuration;
        private IGeocoder _BingGeoCoder;
        private List<ContinentDescription> _continents;
        private bool? _hasInternet;
        public bool DebugDontRenameFile { get; set; } = false;
        public ExifLibrary.ImageFile ExifFileDetails { get; set; }

        //public bool FindOnly { get; set; }

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

        //public object MoveToprocessed { get; set; }
        //public bool MoveToProcessedByYear { get; set; }
        public ProcessParameters Parameters { get; set; }
        //public string ProcessedPath { get; set; }
        //public string SourcePath { get; set; }
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
            if (Parameters.SortByYear && !string.IsNullOrEmpty(Parameters.ProcessedPath))
            {
                Parameters.ProcessedPath = Path.GetFullPath(Parameters.ProcessedPath);
                if (!Directory.Exists(Parameters.ProcessedPath))
                {
                    Directory.CreateDirectory(Parameters.ProcessedPath);
                }
            }

            foreach (var file in Directory.GetFiles(root, "*", SearchOption.AllDirectories))
            {
                var processed = ProcessFile(file);
                if (processed != null)
                {
                    if (Parameters.OnlyShowfilesToChange)
                    {
                        if (processed.NeedsRenaming || processed.HasNewKeywords)
                        {
                            _images.Add(processed);
                        }
                    }
                    else
                    {
                        _images.Add(processed);
                    }
                }
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
                        keyWords = $"{a.CountryRegion};{GetContinent(a.CountryRegion)};{a.Locality};{a.AdminDistrict};{a.AdminDistrict2};".Replace(";Capital;", ";").Replace($";Stadt {a.AdminDistrict};", ";");
                        break;

                    default:
                        break;
                }

                if (!string.IsNullOrEmpty(keyWords))
                {
                    break;
                }
            }
            return keyWords?.Replace(";;", ";").Replace(";;", ";").Replace(";;", ";").Replace(";;", ";").Replace(";;", "");
        }
        public void Process(ProcessParameters parameters)
        {
            Parameters = parameters;
            if (!Directory.Exists(parameters.SourcePath))
            {
                throw new DirectoryNotFoundException($"\r\nFolder to process has not been found.\r\n\t{parameters.SourcePath}");
            }

            if (parameters.WriteReverseGeotag)
            {
                GetBingGeoCoder();
            }


            _images = new ObservableCollection<IImageDetails>();
            _images.CollectionChanged += _images_CollectionChanged;
            FindFiles(parameters.SourcePath);
            RenameFiles();
            DeleteEmptySourceFolders(parameters.SourcePath);
        }

        public IImageDetails ProcessFile(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException(filename);
            }
            string[] sFilter = "jpg;jpeg;cr2;nef;mov;m4a;mp4".Split(';');
            IImageDetails image = null;
            var fileExtention = filename.Split('.').Last().ToLower();
            if (sFilter.Contains(fileExtention))
            {
                switch (fileExtention)
                {
                    case "nef":
                        image = new ImageDetailsNef(filename, Parameters.ProcessedPath) { HasInternet = HasInternet };
                        break;

                    case "mov":
                        image = new VideoFile(filename, Parameters.ProcessedPath) { HasInternet = HasInternet };
                        break;

                    default:
                        image = new ImageDetails(filename, Parameters.ProcessedPath) { HasInternet = HasInternet };
                        break;
                }

                ReverseGeocode(image);
            }
            return image;
        }

        public void ReverseGeocode(IImageDetails image)
        {
            if (!image.HasInternet || image.GPS == null)
            {
                return;
            }
            image.ReverseGeoCodeKeyWords = GetKeywordsFromLocation(image.GPS);
            var keywords = image.KeyWords + ";" + image.ReverseGeoCodeKeyWords;
            var newKeywords = (String.Join(";", keywords.Split(';').Distinct().ToList()) + ";").Replace(";;", ";");
            if (newKeywords.StartsWith(";"))
            {
                newKeywords = newKeywords.Substring(1);
            }
            image.KeyWords = newKeywords;
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

        private string GetContinent(string countryRegion)
        {
            if (_continents == null)
            {
                ReadContinetsFromFile();
            }
            return _continents.Single(s => s.Country.Equals(countryRegion, StringComparison.CurrentCultureIgnoreCase)).Continent + ";";
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

        private void ReadContinetsFromFile()
        {
            if (_continents != null && !_continents.Any())
            {
                return;
            }
            var filename = "countries.csv";
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException(filename);
            }
            _continents = new List<ContinentDescription>();
            foreach (var line in File.ReadAllLines(filename))
            {
                var fields = line.Split(',');
                var cd = new ContinentDescription()
                {
                    Country = fields[0],
                    Region1 = fields[1],
                    Continent = fields[2]
                };
                _continents.Add(cd);
            }
        }

        private void RenameFile(IImageDetails item)
        {
            var sourceFile = item.SourceFileInfo.FullName;
            SetKeywordsInFile(item);
            var destinationFile = item.DestinationFilePath;
            if (File.Exists(destinationFile))
            {
                ReportRenamingProgress($"{sourceFile.Replace(Parameters.SourcePath, string.Empty),30} ############# File Exists");
                if (AreFilesTheSame(sourceFile, destinationFile))
                {
                    _ = destinationFile.Replace(item.SourceFileInfo.Extension, $"(Duplicate){item.SourceFileInfo.Extension}");
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

            ReportRenamingProgress($"{sourceFile.Replace(Parameters.SourcePath, string.Empty),30} ==> {destinationFile.Replace(Parameters.SourcePath, string.Empty)}");
        }

        private void RenameFiles()
        {
            if (Parameters.FindOnly == true || _images == null || !_images.Any(a => a.NeedsRenaming || a.NeedsMoving))
            {
                return;
            }

            foreach (var item in _images.Where(w => w.NeedsRenaming == true || w.NeedsMoving || w.KeyWords != w.OriginalKeywords))
            {
                try
                {
                    RenameFile(item);
                }
                catch (Exception ex)
                {
                    ReportRenamingProgress($"\r\n##############Error\r\n{item.SourceFileInfo.FullName.Replace(Parameters.SourcePath, string.Empty)}r\n{ex.Message}\r\n####################\n\n");
                }
            }
        }

        private void ReportFindFileProgress()
        {
            var e = new ReportFindFilesProgressEventArgs();
            if (_images != null)
            {
                e.TotalFileCount = _images.Count();
                e.FilesToRename = _images.Count(c => c != null && c.NeedsRenaming == true);
                //e.Images = _images;
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

        private void SetKeywordsInFile(IImageDetails image)
        {
            if (Parameters.WriteReverseGeotag || image.OriginalKeywords == image.KeyWords)
            {
                return;
            }

            var file = ExifLibrary.ImageFile.FromFile(image.SourceFileInfo.FullName);
            file.Properties.Set(ExifTag.WindowsKeywords, image.KeyWords);
            file.Save(image.SourceFileInfo.FullName);
        }
    }
}