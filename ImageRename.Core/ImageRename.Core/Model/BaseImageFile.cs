using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImageRename.Core.Model
{
    public abstract class BaseImageFile
    {
        public FileInfo FileDetails { get; set; }
        public DateTime? ImageCreated { get; internal set; }
        public string ProcessedPath { get; set; } = null;
        public string NewFileName
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
                return NewFileName != null &&
                      NewFileName != originalFileName;
            }
        }

        public string GetQuarter
        {
            get
            {
                string retval = null;
                var date = (DateTime)ImageCreated;
                if (date.Month<4)
                {
                    retval = "Q1";
                }
                else if(date.Month>3 && date.Month <7)
                {
                    retval = "Q2";
                }
                else if(date.Month>6 && date.Month <10)
                {
                    retval = "Q3";
                }
                else if(date.Month >9)
                {
                    retval = "Q4";
                }
                return retval;
            }
        }
        public string NewFilePath
        {
            get
            {
                string processedPath = ProcessedPath;
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
                                           NewFileName + FileDetails.Extension);
                return retval;
            }
        }

        public override string ToString()
        {
            return $"{NeedsRenaming} | {FileDetails.FullName}";
        }
    }
}
