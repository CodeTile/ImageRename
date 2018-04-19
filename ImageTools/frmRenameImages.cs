using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
namespace ImageTools
{
    public partial class frmRenameImages : Form
    {
        #region frmRenameImages
        public frmRenameImages()
        {
            InitializeComponent();
        }

        #endregion
        ArrayList mFileInfo;

        #region frmRenameImages_Load
        private void frmRenameImages_Load(object sender, EventArgs e)
        {
            string watchFolder = Properties.Settings.Default.WatchFolder.ReplaceNullOrEmpty();
            ucBrowse2.Text = watchFolder;
        }

        #endregion
        #region btnProcess_Click
        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                lblProcessed.Text = "0";
                lblRenamed.Text = "0";
                lblXMP.Text = "0";
                progressBar1.Visible = true;
                progressBar1.Style = ProgressBarStyle.Marquee;
                mFileInfo = new ArrayList();
                txtResults.Text = "";
                btnProcess.Enabled = false;
                progressBar1.Value = 0;
                GetFileNames(ucBrowse2.Text);
                progressBar1.Maximum = mFileInfo.Count;
                progressBar1.Style = ProgressBarStyle.Continuous;
                foreach (FileInfo f in mFileInfo)
                {
                    progressBar1.Value += 1;
                    lblProcessed.Text = progressBar1.Value.ToString();
                    ProcessFile(f);
                    lblProcessed.Refresh();
                    lblRenamed.Refresh();
                    lblXMP.Refresh();

                }
                if (Directory.Exists(ucBrowse2.Text.ReplaceNullOrEmpty()))
                {
                    Properties.Settings.Default.WatchFolder = ucBrowse2.Text.ReplaceNullOrEmpty();
                    Properties.Settings.Default.Save();
                }
            }
            finally
            {
                btnProcess.Enabled = true;

                progressBar1.Visible = false;
                txtResults.AppendText("\r\n**********************************************************************************************************\r\n**** Finished\r\n**********************************************************************************************************");
            }
        }
        #endregion
        #region GetFileNames

        private void GetFileNames(string pPath)
        {
            //process Childfolders
            foreach (string child in System.IO.Directory.GetDirectories(pPath))
            {
                GetFileNames(child);
            }
            //process Files in this folder
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(pPath);
            string sFilter = "*.jpg;*.jpeg;*.CR2;*.nef;*.mov";
            string[] sFilters = sFilter.Split(';');


            foreach (string Filter in sFilters)
            {

                foreach (System.IO.FileInfo f in dir.GetFiles(Filter))
                {
                    mFileInfo.Add(f);
                }

            }

        }
        #endregion



        #region ProcessFile
        private void ProcessFile(System.IO.FileInfo f)
        {
            txtResults.AppendText("\r\n" + f.FullName.Replace(ucBrowse2.Text, ""));
            string[] sTemp = f.Name.Split('.');
            string fileextension = sTemp[sTemp.Length - 1];
            switch (fileextension.ToLower())
            {
                case "jpeg":
                case "jpg":
                    ProcessJpeg(f.FullName, f.Name);
                    break;
                case "cr2":
                case "raw":
                    ProcessCR2(f);
                    break;
                case "nef":
                    ProcessCR2(f);
                    break;
                case "mov":
                case "m4a":
                    ProcessMOv(f);
                    break;
                default:
                    break;
            }

        }


        #endregion
        public void ProcessMOv(FileInfo f)
        {
            if (!f.Name.StartsWith("20"))
            {
                RenameFile(f, f.CreationTimeUtc);
            }
        }
        #region ReplaceInFile
        /// <summary>
        /// Replaces text in a file.
        /// </summary>
        /// <param name="filePath">Path of the text file.</param>
        /// <param name="searchText">Text to search for.</param>
        /// <param name="replaceText">Text to replace the search text.</param>
        static public void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();

            content = Regex.Replace(content, searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();
        }
        #endregion

        #region ProcessXMP
        private void ProcessXMP(FileInfo f, DateTime imagedate)
        {
            if (f.FullName.ToUpper().EndsWith(".CR2") &&
                File.Exists(f.FullName.ToUpper().Replace(".CR2", ".XMP")))
            {
                /////////////////////////////////////////////////////////////////
                /// Get the datestamp out of the XMP file and use that as the 
                /// time stamp
                ///
                string fullname;
                string oldshortname;
                string newshortname;
                string oldsuffix;
                string sNewFileName;
                string newsuffix = "XMP";
                //////
                // get the oldvalues
                oldsuffix = f.Name.Split('.')[1];
                fullname = f.FullName.ToUpper().Replace(oldsuffix, newsuffix);
                oldshortname = f.Name.Replace(oldsuffix, newsuffix);
                newshortname = string.Format("{0}.{1}",
                                            ImageNewDateFileName(imagedate),
                                            newsuffix);
                txtResults.AppendText("\r\n    ");
                txtResults.AppendText(newshortname);

                sNewFileName = fullname.Replace(oldshortname.ToUpper(), newshortname);

                RenameFile(fullname, sNewFileName);
                /// now change the filename pointer in the xmp file
                /// 

                oldshortname = f.Name;
                newshortname = string.Format("{0}.{1}",
                                            ImageNewDateFileName(imagedate),
                                            oldsuffix);
                ReplaceInFile(sNewFileName, oldshortname, newshortname);
                lblXMP.Text = Convert.ToString(Convert.ToInt32(lblXMP.Text) + 1);

                /////////////////////////////////////////////////////////////////
            }

        }

        #endregion
        #region ProcessCR2

        private void ProcessCR2(FileInfo f)
        {


            string xmlImage;
            DateTime imagedate = Convert.ToDateTime("1 jan 1900");
            xmlImage = com.Run.GetImageInfoForFile(f.FullName, com.Run.eOutput.eoXML2);
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
                            imagedate = Convert.ToDateTime(tag.LastChild.InnerText);
                            RenameFile(f, imagedate);
                            ProcessXMP(f, imagedate);
                            break;
                        }
                    }//end tags
                    if (imagedate != Convert.ToDateTime("1 jan 1900")) { break; }
                }//end directorys
                if (imagedate != Convert.ToDateTime("1 jan 1900")) { break; }
            }//end file
        }

        #endregion

        #region ProcessJpeg
        private void ProcessJpeg(string fullname, string shortname)
        {
            Goheer.EXIF.EXIFextractor er2;
            try
            {
                er2 = new Goheer.EXIF.EXIFextractor(fullname, "", "");
                // dont process processed files
                //if (er2["Software Used"].ToString() == "")
                //{
                string sDtOrig = er2["DTOrig"].ToString().Replace(":", "").Replace(" ", "_").Replace("\0", ".");
                string sNewFileName = fullname.Replace(shortname, sDtOrig);
                string[] sTemp = shortname.Split('.');
                sNewFileName += sTemp[sTemp.Length - 1];
                RenameFile(fullname, sNewFileName);
                //}//end if
            }// end try

            catch
            {


            }//end catch
            finally
            {

                er2 = null;
            }


        }// end void 
        #endregion


        #region ImageNewDateFileName
        private static string ImageNewDateFileName(DateTime imagedate)
        {
            return string.Format("{0}{1}{2}_{3}{4}{5}",
                                            imagedate.Year.ToString("0000"),
                                            imagedate.Month.ToString("00"),
                                            imagedate.Day.ToString("00"),
                                            imagedate.Hour.ToString("00"),
                                            imagedate.Minute.ToString("00"),
                                            imagedate.Second.ToString("00"));
        }
        #endregion
        #region RenameFile
        private void RenameFile(FileInfo f, string newsuffix, DateTime imagedate)
        {
            string fullname;
            string oldshortname;
            string newshortname;
            string oldsuffix;
            string sNewFileName;
            //////
            // get the oldvalues
            oldsuffix = f.Name.Split('.')[1];
            fullname = f.FullName.ToUpper().Replace(oldsuffix, newsuffix);
            oldshortname = f.Name.Replace(oldsuffix, newsuffix).ToUpper();
            newshortname = string.Format("{0}.{1}",
                                        ImageNewDateFileName(imagedate),
                                        newsuffix);

            sNewFileName = fullname.Replace(oldshortname, newshortname);

            RenameFile(fullname, sNewFileName);



        }
        private void RenameFile(FileInfo f, DateTime imagedate)
        {

            string sDtOrig = ImageNewDateFileName(imagedate);
            string sNewFileName = f.FullName.Replace(f.Name, sDtOrig);
            string[] sTemp = f.Name.Split('.');
            sNewFileName += "." + sTemp[1];
            RenameFile(f.FullName, sNewFileName);
        }

        private void RenameFile(string pOriginal, string pNew)
        {

            if (pOriginal != pNew)
            {
                if (File.Exists(pOriginal))
                {
                    string[] sTemp = pNew.Split('.');
                    string NEW_FILENAME = sTemp[0] + @"_{0}." + sTemp[1];
                    int i = 0;
                    while (File.Exists(pNew))
                    {
                        i++;
                        pNew = string.Format(NEW_FILENAME,
                                             i.ToString("###"));

                    }
                    File.Copy(pOriginal, pNew);
                    if (File.Exists(pNew))
                    {
                        File.Delete(pOriginal);
                    }
                    txtResults.AppendText("  ----------->  " + pNew.Replace(ucBrowse2.Text, ""));
                    lblRenamed.Text = Convert.ToString(Convert.ToInt32(lblRenamed.Text) + 1);
                    lblRenamed.Refresh();
                }// end if
            }// end if
        }

        #endregion

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }// end form
}// end namespace
