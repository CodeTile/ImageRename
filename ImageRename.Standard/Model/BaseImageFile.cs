using System;
using System.IO;
using System.Linq;

namespace ImageRename.Standard.Model
{
    public abstract class BaseImageFile
    {
        private FileInfo _sourceFileInfo;
        private DateTime? _imageCreated;
        private DirectoryInfo _processedRoot;

        public BaseImageFile(string path, string processedPath = null)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }

            _sourceFileInfo = new FileInfo(path);
            if (!string.IsNullOrEmpty(processedPath)
                && !processedPath.Equals(_processedRoot?.FullName, StringComparison.CurrentCultureIgnoreCase))
            {
                _processedRoot = new DirectoryInfo(processedPath);
            }
            GetCreationDate();
        }

        /// <summary>
        /// Get the creation date of the file.
        /// </summary>
        public virtual void GetCreationDate()
        {
            try
            {
                string dateTaken;
                var directories = ImageMetadataReader.ReadMetadata(SourceFileInfo.FullName);
                var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();

                dateTaken = subIfdDirectory?.GetDescription(ExifDirectoryBase.TagDateTimeOriginal);

                var mySplit = dateTaken.Trim().Split(' ');
                var dateSplit = mySplit[0].Split(':');
                var timeSplit = mySplit[1].Split(':');
                var date = new DateTime(Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]), Convert.ToInt32(dateSplit[2]),
                                      Convert.ToInt32(timeSplit[0]), Convert.ToInt32(timeSplit[1]), Convert.ToInt32(timeSplit[2]));
                ImageCreated = date;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n\t{SourceFileInfo?.FullName}");
                //Suppress errors
            }
        }

        /// <summary>
        /// Get/Set the Destination FileInfo
        /// </summary>
        public FileInfo DestinationFileInfo { get; private set; }

        /// <summary>
        /// Get/Set the source FileInfo
        /// </summary>
        public FileInfo SourceFileInfo
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
        /// Get/set for image created.
        /// </summary>
        public DateTime? ImageCreated
        {
            get => _imageCreated;
            internal set
            {
                _imageCreated = value;
                OnInputParameterChanged();
            }
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
        /// Does the file need renaming
        /// </summary>
        public bool NeedsRenaming
        {
            get
            {
                var retval = false;
                retval = DestinationFileName != null &&
                      SourceFileInfo != null &&
                     FullDestinationFileName != SourceFileInfo.Name;
                return retval;
            }
        }

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
    }
}