using System;
using System.IO;
using System.Xml;
using ExifLib;

namespace ImageRename.Standard.Model
{
    public class ImageFile : BaseImageFile, IImageFile
    {
        public ImageFile(string path, string processedPath = null) : base(path, processedPath)
        {
        }
        public override void GetCreationDate()
        {
            try
            {
                using (var reader = new ExifReader(SourceFileInfo.FullName))
                {
                    DateTime datePictureTaken;
                    // Extract the tag data using the ExifTags enumeration
                    if (reader.GetTagValue<DateTime>(ExifTags.DateTimeDigitized,
                                                    out datePictureTaken))
                    {
                        ImageCreated = datePictureTaken;
                    }
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                //Suppress errors
            }
        }
        //////////////    ////////if (ImageCreated == null)
        //////////////    ////////{
        //////////////    ////////    string xmlImage;
        //////////////    ////////    //DateTime imagedate = Convert.ToDateTime("1 jan 1900");
        //////////////    ////////    xmlImage = com.Run.GetImageInfoForFile(SourceFileInfo.FullName, com.Run.eOutput.eoXML2);
        //////////////    ////////    XmlDocument doc = new XmlDocument();
        //////////////    ////////    doc.LoadXml(xmlImage);
        //////////////    ////////    XmlNodeList files = doc.SelectNodes("metadataExtractor/file");
        //////////////    ////////    foreach (XmlNode file in files)
        //////////////    ////////    {
        //////////////    ////////        foreach (XmlNode directory in file.SelectNodes("directory"))
        //////////////    ////////        {
        //////////////    ////////            foreach (XmlNode tag in directory.SelectNodes("tag"))
        //////////////    ////////            {
        //////////////    ////////                if (tag.FirstChild.InnerText == "Date/Time Original")
        //////////////    ////////                {
        //////////////    ////////                    ImageCreated = Convert.ToDateTime(tag.LastChild.InnerText);
        //////////////    ////////                    break;
        //////////////    ////////                }
        //////////////    ////////            }//end tags
        //////////////    ////////            if (ImageCreated != null) { break; }
        //////////////    ////////        }//end directorys
        //////////////    ////////        if (ImageCreated != null) { break; }
        //////////////    ////////    }//end file
        //////////////    ////////}
        //////////////}
    }
}