using System;
using ExifLib;

namespace ImageRename.Standard.Model
{
    public class ImageFileJpg : BaseImageFile, IImageFile
    {
        public ImageFileJpg(string path, string processedPath = null) : base(path, processedPath)
        {

        }
        public override void GetCreationDate()
        {
            try
            {
                using (var reader = new ExifReader(SourceFileInfo.FullName))
                {
                    // Extract the tag data using the ExifTags enumeration
                    if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized,
                                                    out var datePictureTaken))
                    {
                        ImageCreated = datePictureTaken;
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //Suppress errors
            }
        }
    }
}