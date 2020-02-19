using System;
using System.Collections.Generic;
using System.Linq;
using MetadataExtractor;

namespace ImageRename.Standard.Model
{
    public class VideoFile : BaseImageFile, IImageDetails
    {
        public VideoFile(string path, string processedPath = null) : base(path, processedPath)
        {

        }
        public override void GetExifData()
        {
            try
            {
                string dateTaken;
                IEnumerable<MetadataExtractor.Directory> directories = ImageMetadataReader.ReadMetadata(SourceFileInfo.FullName);
                var subIfdDirectory = directories.FirstOrDefault(f => f.Name.Equals("QuickTime Movie Header"));

                dateTaken = subIfdDirectory?.Tags.FirstOrDefault(f => f.Name.Equals("Created", StringComparison.CurrentCultureIgnoreCase)).Description;



                var mySplit = dateTaken.Trim().Split(' ');
                var timeSplit = mySplit[3].Split(':');
                var month = Convert.ToDateTime(mySplit[1] + " 01, 1900").Month;
                var date = new DateTime(Convert.ToInt32(mySplit[4]), month, Convert.ToInt32(mySplit[2]),
                                      Convert.ToInt32(timeSplit[0]), Convert.ToInt32(timeSplit[1]), Convert.ToInt32(timeSplit[2]));
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