using System;
using System.IO;
using ExifLib;

namespace ImageRename.Core.Model
{
    public class ImageFile : IImageFile
    {
        public ImageFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            FileDetails = new FileInfo(path);
            ReadExif();
        }

        private void ReadExif()
        {
            using (var reader = new ExifReader(FileDetails.FullName))
            {
                // Extract the tag data using the ExifTags enumeration
                if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized,
                                                out DateTime datePictureTaken))
                {
                    ImageCreated = datePictureTaken;
                }
            }
        }

        public FileInfo FileDetails { get; private set; }
        public DateTime? ImageCreated { get; private set; }
        public bool NeedsRenaming
        {
            get
            {
                return NewFileName != FileDetails.Name.Replace($".{FileDetails.Extension}", string.Empty);
            }
        }
        public string NewFilePath
        {
            get
            {
                if (FileDetails == null ||
                      !File.Exists(FileDetails.FullName))
                {
                    return null;
                }
                var retval = Path.Combine(FileDetails.DirectoryName,
                                           NewFileName + FileDetails.Extension);
                return retval;
            }
        }
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
    }
}
