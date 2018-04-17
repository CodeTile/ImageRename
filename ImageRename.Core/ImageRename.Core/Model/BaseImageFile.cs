using System;
using System.IO;
using System.Linq;

namespace ImageRename.Core.Model
{
    public abstract class BaseImageFile : IImageFile
    {
        private string _processedDirectory = null;
        public BaseImageFile(string path, string processedPath = null)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            _processedDirectory = processedPath;
            FileDetails = new FileInfo(path);
        }
        public FileInfo FileDetails { get; set; }
        public DateTime? ImageCreated { get; internal set; }

        public string ProcessedFileName
        {
            get
            {
                if (ImageCreated == null)
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

        public bool NeedsRenaming
        {
            get
            {
                var originalExtension = FileDetails.Name.Split('.').Last();
                var originalFileName = FileDetails.Name.Split('\\').Last().Replace($".{originalExtension}", string.Empty);
                return ProcessedFileName != null &&
                      ProcessedFileName != originalFileName;
            }
        }

        public string GetQuarter
        {
            get
            {
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

        public string ProcessedFullName
        {
            get
            {
                string processedPath = _processedDirectory;
                if (string.IsNullOrEmpty(processedPath))
                {
                    processedPath = FileDetails.DirectoryName;
                }
                else
                {
                    processedPath = Path.Combine(processedPath,
                                                ((DateTime)ImageCreated).Year.ToString(),
                                                GetQuarter);
                }

                if (!NeedsRenaming ||
                    FileDetails == null ||
                      !File.Exists(FileDetails.FullName))
                {
                    return null;
                }

                var retval = Path.Combine(processedPath,
                                           ProcessedFileName + FileDetails.Extension);
                return retval;
            }
        }


        public string ProcessedDirectory
        {
            get
            {
                string retval = null;
                if (!string.IsNullOrEmpty(ProcessedFullName))
                {
                    var fn = ProcessedFullName.Split('\\').Last();
                    retval = ProcessedFullName.Replace(fn, string.Empty);
                }
                return retval;
            }
        }

        public bool NeedsMoving
        {
            get
            {
                bool retval = !string.IsNullOrEmpty(ProcessedDirectory)
                            && !FileDetails.DirectoryName.Equals(ProcessedDirectory);
                return retval;
            }
        }


        public override string ToString()
        {
            string move = string.Empty;
            string rename = string.Empty;
            if(NeedsRenaming)
            {
                rename = "Rename";
            }
            if (NeedsMoving)
            {
                move = "Move";
            }
            return $"{rename.PadRight(7)} | {move.PadRight(7)} |  {FileDetails.FullName}";
        }
    }
}