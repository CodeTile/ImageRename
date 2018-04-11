

//using System.Drawing;
//using System.Drawing.Imaging;
//using System.IO;

using System;
using ImageRename.Base.Model;

namespace ImageRename.Base.Model
{
    public class ImageFileNEF : BaseImageFile, IImageFile
    {
        public ImageFileNEF(string path)
        {
            throw new NotImplementedException();
            //if (!File.Exists(path))
            //{
            //    throw new FileNotFoundException(path);
            //}
            //FileDetails = new FileInfo(path);
            //ExtractCreatedDate();
        }

        //private void ExtractCreatedDate()
        //{
        //    var path = FileDetails.FullName;
        //    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        //    {
        //        var img = BitmapFrame.Create(fs);
        //        var md = (BitmapMetadata)img.Metadata;
        //        string date = md.DateTaken;
        //        System.Diagnostics.Debug.WriteLine(date);
        //    }

        //}
    }
}
