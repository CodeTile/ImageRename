using System;
using System.Collections.Generic;
using System.Linq;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace ImageRename.Standard.Model
{
    public class ImageFileJpg : BaseImageFile, IImageFile
    {
        public ImageFileJpg(string path, string processedPath = null) : base(path, processedPath)
        {

        }
      
    }
}