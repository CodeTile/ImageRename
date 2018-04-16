using System.IO;

namespace ImageRename.Core.Model
{
    public class VideoFile : BaseImageFile, IImageFile
    {
        public VideoFile(string path, string processedPath=null)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            ProcessedPath = processedPath;
            FileDetails = new FileInfo(path);
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
