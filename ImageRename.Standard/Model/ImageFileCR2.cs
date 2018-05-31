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
    }
}
