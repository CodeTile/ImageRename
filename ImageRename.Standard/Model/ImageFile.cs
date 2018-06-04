using System;
using System.Collections.Generic;
using System.Linq;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace ImageRename.Standard.Model
{
    public class ImageFile : BaseImageFile, IImageFile
    {
        public ImageFile(string path, string processedPath = null) : base(path, processedPath)
        {

        }
      
    }
}