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
            if (SourceFileInfo == null)
            {
                return;
            }

            ImageCreated = SourceFileInfo.LastWriteTime;

            if (SourceFileInfo.CreationTime < ImageCreated)
            {
                ImageCreated = SourceFileInfo.CreationTime;
            }
        }
    }
}