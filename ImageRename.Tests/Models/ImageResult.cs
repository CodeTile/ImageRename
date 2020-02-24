namespace ImageRename.Tests.Steps
{
    public class ImageResult
    {
        public double? DegreesLatitude { get; set; }
        public double? DegreesLongitude { get; set; }
        public string DestinationFileName { get; set; }
        public string GPSImageTaken { get; set; }
        public string ImageCreatedOriginal { get; set; }
        public string ImageTaken { get; set; }
        public string KeyWords { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string NeedMoving { get; set; }
        public bool NeedsRenaming { get; set; }
        public string TestFile { get; set; }
        public string TestFolder { get; set; }
        public bool HasInternet { get; internal set; }
        public bool HasNewKeywords { get; internal set; }
        public string OriginalKeywords { get; internal set; }
    };
}