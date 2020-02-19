namespace ImageRename.Standard.Model
{
    public class ImageDetails : BaseImageFile, IImageDetails
    {
        public ImageDetails(string path, string processedPath = null) : base(path, processedPath)
        {
        }
    }
}