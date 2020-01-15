using System;
using System.Collections.Generic;
using System.Linq;
using MetadataExtractor;

namespace ImageRename.Standard.Model
{
    public class ImageFileNEF : BaseImageFile, IImageFile
    {
        public ImageFileNEF(string path, string processedPath = null) : base(path, processedPath)
        {
        }

        public override void GetExifData()
        {
            try
            {
                string dateTaken;
                IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(SourceFileInfo.FullName);
                var subIfdDirectory = directories.FirstOrDefault(f => f.Name.Equals("Exif IFD0"));

                dateTaken = subIfdDirectory?.Tags.FirstOrDefault(f => f.Name.Equals("Date/Time", StringComparison.CurrentCultureIgnoreCase)).Description;

                var mySplit = dateTaken.Trim().Split(' ');
                var dateSplit = mySplit[0].Split(':');
                var timeSplit = mySplit[1].Split(':');
                var seconds = Convert.ToInt32(timeSplit[2]);
                if(seconds<0 || seconds>59)
                {
                    seconds = 0;
                }
                var date = new DateTime(Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]), Convert.ToInt32(dateSplit[2]),
                                        Convert.ToInt32(timeSplit[0]), Convert.ToInt32(timeSplit[1]), seconds);
                
                ImageCreated = date;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n\t{SourceFileInfo?.FullName}");
                //Suppress errors
            }
        }
    }
}
