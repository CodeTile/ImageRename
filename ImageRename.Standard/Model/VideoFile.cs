using System.IO;

namespace ImageRename.Standard.Model
{
    public class VideoFile : BaseImageFile, IImageFile
    {
        public VideoFile(string path, string processedPath = null) : base(path, processedPath)
        {
            GetDate();
        }

        private void GetDate()
        {
            if (FileDetails == null)
            {
                return;
            }

            ImageCreated = FileDetails.LastWriteTime;

            if (FileDetails.CreationTime < ImageCreated)
            {
                ImageCreated = FileDetails.CreationTime;
            }
        }
    }
}