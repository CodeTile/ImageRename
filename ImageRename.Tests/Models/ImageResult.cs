﻿namespace ImageRename.Tests.Steps
{
    public partial class ImageResult
        {
            public string ImageTaken { get; internal set; }
            public string ImageCreatedOriginal { get; internal set; }
            public string GPSImageTaken { get; internal set; }
            public string Latitude { get; internal set; }
            public string Longitude { get; internal set; }
            public string TestFile { get; internal set; }
            public string TestFolder { get; internal set; }
            public string DestinationFileName { get; internal set; }
            public string KeyWords { get; internal set; }
            public string NeedRenaming { get; internal set; }
            public string NeedMoving { get; internal set; }        
    };
}