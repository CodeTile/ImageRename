using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using MetadataExtractor;

namespace ImageRename.Standard.Model
{
    public sealed class ImageFileCR2 : BaseImageFile, IImageFile
    {
        public ImageFileCR2(string path, string processedPath = null) : base(path, processedPath)
        {

        }

        public override void GetCreationDate()
        {
            string dateTaken;
            IEnumerable<Directory> directories = ImageMetadataReader.ReadMetadata(SourceFileInfo.FullName);

            dateTaken = directories.SingleOrDefault(d => d.Name.Equals("Exif SubIFD", StringComparison.CurrentCultureIgnoreCase))
                              .Tags.SingleOrDefault(t => t.Name.Equals("Date/Time Original", StringComparison.CurrentCultureIgnoreCase))
                              .Description;

            if (string.IsNullOrEmpty(dateTaken))
            {
                foreach (var directory in directories)
                {
                    foreach (var tag in directory.Tags.Where(w => w.Name.Equals("Date/Time Original", StringComparison.CurrentCultureIgnoreCase)))
                    {
                        dateTaken = tag.Description;
                        break;
                    }
                    if (!string.IsNullOrEmpty(dateTaken))
                        break;
                }
            }

            var mySplit = dateTaken.Trim().Split(' ');
            var dateSplit = mySplit[0].Split(':');
            var timeSplit = mySplit[1].Split(':');
            var date = new DateTime(Convert.ToInt32(dateSplit[0]), Convert.ToInt32(dateSplit[1]), Convert.ToInt32(dateSplit[2]),
                                  Convert.ToInt32(timeSplit[0]), Convert.ToInt32(timeSplit[1]), Convert.ToInt32(timeSplit[2]));
            ImageCreated = date;
        }
    }
}
