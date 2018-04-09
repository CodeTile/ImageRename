using System;
using System.IO;
using ExifLib;

namespace ImageRename.Core.Model
{
    public class ImageFileJpeg : IImageFile
    {
        public ImageFileJpeg(string path, bool suppressExifError=true)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            FileDetails = new FileInfo(path);
            ReadExif(suppressExifError);
        }

        private void ReadExif(bool suppressExifError = false)
        {
            try
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
            catch(ExifLibException)
            {
                if(!suppressExifError)
                {
                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FileInfo FileDetails { get; private set; }
        public DateTime? ImageCreated { get; private set; }
        public bool NeedsRenaming
        {
            get
            {
                return NewFileName!=null &&
                      NewFileName != FileDetails.Name.Replace($".{FileDetails.Extension}", string.Empty);
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
        public override string ToString()
        {
            return $"{NeedsRenaming} | {FileDetails.FullName}";
        }
    }
}
