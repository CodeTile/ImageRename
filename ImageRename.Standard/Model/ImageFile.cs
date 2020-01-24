namespace ImageRename.Standard.Model
{
    public class ImageFile : BaseImageFile, IImageFile
    {
        public ImageFile(string path, string processedPath = null) : base(path, processedPath)
        {
        }
    }
}