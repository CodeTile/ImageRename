using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace ImageRename.Standard.Model
{
    public sealed class ImageFileCR2 : BaseImageFile, IImageFile
    {
        public ImageFileCR2(string path, string processedPath = null) : base(path, processedPath)
        {

        }

        public override void GetCreationDate()
        {
            string xmlImage;
            //DateTime imagedate = Convert.ToDateTime("1 jan 1900");
            xmlImage = com.Run.GetImageInfoForFile(SourceFileInfo.FullName, com.Run.eOutput.eoXML2);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlImage);
            XmlNodeList files = doc.SelectNodes("metadataExtractor/file");
            foreach (XmlNode file in files)
            {
                foreach (XmlNode directory in file.SelectNodes("directory"))
                {
                    foreach (XmlNode tag in directory.SelectNodes("tag"))
                    {
                        if (tag.FirstChild.InnerText == "Date/Time Original")
                        {
                            ImageCreated = Convert.ToDateTime(tag.LastChild.InnerText);
                            return;
                        }
                    }//end tags
                }//end directorys
            }//end file
        }
    }
}
