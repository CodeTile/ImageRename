using System.IO;
using ImageRename.Base.Model;

namespace ImageRename.Base.Model
{
    public class VideoFile : BaseImageFile, IImageFile
    {
        public VideoFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            FileDetails = new FileInfo(path);
            GetDate();
        }

        private void GetDate()
        {
            if (FileDetails == null)
            {
                return;
            }

            if (FileDetails.CreationTime < FileDetails.LastWriteTime)
            {
                ImageCreated = FileDetails.CreationTime;
            }
            else
            {
                ImageCreated = FileDetails.LastWriteTime;
            }
        }
    }
}
