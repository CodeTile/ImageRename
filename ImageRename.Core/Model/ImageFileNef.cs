using System.IO;

namespace ImageRename.Core.Model
{
    public class ImageFileNEF : BaseImageFile, IImageFile
    {
        public ImageFileNEF(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            FileDetails = new FileInfo(path);
            ExtractCreatedDate();
        }

        private void ExtractCreatedDate()
        {
            throw new System.NotImplementedException();
            //var path = FileDetails.FullName;
            //using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            //{
            //    var img = BitmapFrame.Create(fs);
            //    var md = (BitmapMetadata)img.Metadata;
            //    string date = md.DateTaken;
            //    System.Diagnostics.Debug.WriteLine(date);
            //}

        }
    }
}
