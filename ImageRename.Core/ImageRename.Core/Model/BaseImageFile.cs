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

        public string NewFilePath
        {
            get
            {
                if (!NeedsRenaming ||
                    FileDetails == null ||
                      !File.Exists(FileDetails.FullName))
                {
                    return null;
                }
                var retval = Path.Combine(FileDetails.DirectoryName,
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
