using ExifLibrary;
using System;
using System.IO;

namespace ImageRename.Standard.Model
{
    public abstract partial class BaseImageFile : IImageDetails
    {
        public BaseImageFile(string path, string processedPath = null)
        {
            if (!File.Exists(path) && !path.StartsWith("<<DEBUG>>"))
            {
                throw new FileNotFoundException(path);
            }

            _sourceFileInfo = new FileInfo(path);
            if (!string.IsNullOrEmpty(processedPath)
                && !processedPath.Equals(_processedRoot?.FullName, StringComparison.CurrentCultureIgnoreCase))
            {
                _processedRoot = new DirectoryInfo(processedPath);
            }
            GetExifData();
        }

        private readonly DirectoryInfo _processedRoot;
        private DateTime? _imageCreated;
        private FileInfo _sourceFileInfo;

        /// <summary>
        /// Get/Set the Destination FileInfo
        /// </summary>
        public FileInfo DestinationFileInfo { get; private set; }

        /// <summary>
        /// Returns the destination filename
        /// </summary>
        public string DestinationFileName
        {
            get
            {
                if (ImageCreated == null || SourceFileInfo == null)
                {
                    return null;
                }

                DateTime imageDate = (DateTime)ImageCreated;
                if (GPS?.GpsDateTime != null)
                {
                    imageDate = (DateTime)GPS.GpsDateTime;
                }

                return string.Format("{0}{1}{2}_{3}{4}{5}",
                                        imageDate.Year.ToString("0000"),
                                        imageDate.Month.ToString("00"),
                                        imageDate.Day.ToString("00"),
                                        imageDate.Hour.ToString("00"),
                                        imageDate.Minute.ToString("00"),
                                        imageDate.Second.ToString("00"));
            }
        }

        /// <summary>
        /// The full destination file path
        /// </summary>
        public string DestinationFilePath
        {
            get
            {
                if ((!NeedsMoving && !NeedsRenaming) || DestinationFileInfo == null)
                {
                    return null;
                }
                return DestinationFileInfo.FullName;
            }
        }

        /// <summary>
        /// Get the Quarter the image was taken in.
        /// </summary>
        public string GetQuarter
        {
            get
            {
                if (ImageCreated == null)
                {
                    return null;
                }
                string retval = null;
                var date = (DateTime)ImageCreated;
                if (date.Month < 4)
                {
                    retval = "Q1";
                }
                else if (date.Month > 3 && date.Month < 7)
                {
                    retval = "Q2";
                }
                else if (date.Month > 6 && date.Month < 10)
                {
                    retval = "Q3";
                }
                else if (date.Month > 9)
                {
                    retval = "Q4";
                }
                return retval;
            }
        }

        public virtual IGPSCoridates GPS { get; set; }

        public bool HasInternet { get; set; }

        /// <summary>
        /// Get/set for image created.
        /// </summary>
        public DateTime? ImageCreated
        {
            get => _imageCreated;
            set
            {
                _imageCreated = value;
                OnInputParameterChanged();
            }
        }

        public virtual DateTime? ImageCreatedOriginal { get; set; }

        public virtual string KeyWords { get; set; }

        /// <summary>
        /// Does the file need moving
        /// </summary>
        public bool NeedsMoving
        {
            get
            {
                var retval = false;
                if (!string.IsNullOrEmpty(_processedRoot?.FullName)
                    && !SourceFileInfo.Directory.FullName.Equals(_processedRoot.FullName, StringComparison.CurrentCultureIgnoreCase)
                    && ImageCreated != null)
                {
                    retval = true;
                }
                return retval;
            }
        }

        /// <summary>
        /// Does the file need renaming
        /// </summary>
        public bool NeedsRenaming
        {
            get
            {
                var retval = DestinationFileName != null &&
                      SourceFileInfo != null &&
                     FullDestinationFileName != SourceFileInfo.Name;
                return retval;
            }
        }

        public string OriginalKeywords { get; set; }

        /// <summary>
        /// Get/Set the source FileInfo
        /// </summary>
        public virtual FileInfo SourceFileInfo
        {
            get => _sourceFileInfo;
            set
            {
                if (value.Exists)
                {
                    _sourceFileInfo = value;
                }
                else
                {
                    _sourceFileInfo = null;
                }
                OnInputParameterChanged();
            }
        }

        /// <summary>
        /// Return the destination FilenameIncluding the extenstion
        /// </summary>
        private string FullDestinationFileName
        {
            get
            {
                if (DestinationFileName == null)
                {
                    return null;
                }
                return $"{DestinationFileName}{SourceFileInfo?.Extension}";
            }
        }

        /// <summary>
        /// Get the creation date of the file.
        /// </summary>
        public virtual void GetExifData()
        {
            try
            {
                if (SourceFileInfo.FullName.Contains("<<DEBUG>>"))
                {
                    return;
                }
                if (!SourceFileInfo.Exists)
                {
                    throw new FileNotFoundException(SourceFileInfo.FullName);
                }
                var file = ExifLibrary.ImageFile.FromFile(SourceFileInfo.FullName);
                OriginalKeywords = GetExifValueAsString(file, ExifTag.WindowsKeywords);
                KeyWords = OriginalKeywords;
                ImageCreated = Convert.ToDateTime(GetExifTag(file, ExifTag.DateTime).Value);
                ImageCreatedOriginal = Convert.ToDateTime(GetExifTag(file, ExifTag.DateTimeOriginal).Value);

                var latTag = GetExifGpsCoridianates(file, ExifTag.GPSLatitude);
                if (latTag != null)
                {
                    var longTag = GetExifGpsCoridianates(file, ExifTag.GPSLongitude);
                    var longRefTag = GetExifValueAsString(file, ExifTag.GPSLongitudeRef)?.Substring(0, 1);
                    var latRefTag = GetExifValueAsString(file, ExifTag.GPSLatitudeRef)?.Substring(0, 1);
                    GPS = new GPSCoridates()
                    {
                        Longitude = $"{longTag} {longRefTag}",
                        Latitude = $"{latTag} {latRefTag}"
                    };
                    var gDate = GetExifTag(file, ExifTag.GPSDateStamp);
                    if (gDate != null && gDate.Value != null)
                    {
                        var gpsDate = Convert.ToDateTime(file.Properties.Get(ExifTag.GPSDateStamp).Value).ToString("dd MMMM yyyy");
                        var gpsTime = (GPSTimeStamp)file.Properties.Get(ExifTag.GPSTimeStamp);
                        ImageCreated = Convert.ToDateTime($"{gpsDate} {gpsTime.Hour.Numerator}:{gpsTime.Minute.Numerator}:{gpsTime.Second.Numerator}");
                        GPS.GpsDateTime = ImageCreated;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n\t{SourceFileInfo?.FullName}");
                throw;
            }
        }

        private object GetExifGpsCoridianates(ImageFile file, ExifTag tag)
        {
            string retval;
            try
            {
                retval = file.Properties.Get<GPSLatitudeLongitude>(tag)?.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\r\n\t{nameof(tag)} = tag");
                throw new Exception("${ex.Message}\r\n\t{nameof(tag)} = tag", ex);
            }

            return retval;
        }

        private ExifProperty GetExifTag(ImageFile file, ExifTag tag)
        {
            ExifProperty retval = null;
            try
            {
                retval = file.Properties.Get(tag);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\r\n\tTag = {nameof(tag)}");
            }

            return retval;
        }

        private string GetExifValueAsString(ImageFile file, ExifTag tag)
        {
            string retval;
            try
            {
                var exif = GetExifTag(file, tag);
                retval = exif?.Value?.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\r\n\t{nameof(tag)} = tag");
                throw new Exception("${ex.Message}\r\n\t{nameof(tag)} = tag", ex);
            }

            return retval;
        }

        /// <summary>
        /// Event for changed input parameter
        /// </summary>
        private void OnInputParameterChanged()
        {
            if (FullDestinationFileName == null)
            {
                DestinationFileInfo = null;
                return;
            }
            string newPath;
            if (!string.IsNullOrEmpty(_processedRoot?.FullName))
            {
                newPath = Path.Combine(_processedRoot.FullName,
                                       $"{ ((DateTime)ImageCreated).Year}"
                                       , GetQuarter
                                       , FullDestinationFileName);
            }
            else
            {
                newPath = Path.Combine(SourceFileInfo.DirectoryName,
                                             FullDestinationFileName);
            }
            DestinationFileInfo = new FileInfo(newPath);
        }
    }
}