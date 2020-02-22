using ExifLibrary;
using ImageRename.Tests.Context;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using TechTalk.SpecFlow;

namespace ImageRename.Tests.Steps
{
    [Binding]
    public class TestJpegCreationSteps : BaseSteps
    {
        public TestJpegCreationSteps(BaseContext context) : base(context)
        {
        }

        private byte[] _image;

        public byte[] CreateGridImage(
           int maxXCells = 10,
           int maxYCells = 10,
           int cellXPosition = 9,
           int cellYPosition = 9,
           int boxSize = 30)
        {
            if (_image == null)
            {
                using var bmp = new System.Drawing.Bitmap(maxXCells * boxSize + 1, maxYCells * boxSize + 1);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Yellow);
                    Pen pen = new Pen(Color.Black)
                    {
                        Width = 1
                    };

                    //Draw red rectangle to go behind cross
                    Rectangle rect = new Rectangle(boxSize * (cellXPosition - 1), boxSize * (cellYPosition - 1), boxSize, boxSize);
                    g.FillRectangle(new SolidBrush(Color.Red), rect);

                    //Draw cross
                    g.DrawLine(pen, boxSize * (cellXPosition - 1), boxSize * (cellYPosition - 1), boxSize * cellXPosition, boxSize * cellYPosition);
                    g.DrawLine(pen, boxSize * (cellXPosition - 1), boxSize * cellYPosition, boxSize * cellXPosition, boxSize * (cellYPosition - 1));

                    //Draw horizontal lines
                    for (int i = 0; i <= maxXCells; i++)
                    {
                        g.DrawLine(pen, (i * boxSize), 0, i * boxSize, boxSize * maxYCells);
                    }

                    //Draw vertical lines
                    for (int i = 0; i <= maxYCells; i++)
                    {
                        g.DrawLine(pen, 0, (i * boxSize), boxSize * maxXCells, i * boxSize);
                    }
                }

                var memStream = new MemoryStream();
                bmp.Save(memStream, ImageFormat.Jpeg);
                _image = memStream.ToArray();
            }
            return _image;
        }

        [Given(@"I create the JPEG files")]
        public void ICreateTheJpegFiles(Table table)
        {
            foreach (var row in table.Rows)
            {
                CreateTheJpegFiles(row);
            }
        }

        private void AddExifTagstoFile(string filename, TableRow row)
        {
            ///| Folder | FileName | Keywords | ImageCreatedOriginal | ImageTaken | GPSImageTaken | Longitude | Latitude |///
            var file = ImageFile.FromFile(filename);
            if (!string.IsNullOrEmpty(row["Keywords"]))
            {
                file.Properties.Set(ExifTag.WindowsKeywords, row["Keywords"]);
            }
            if (!string.IsNullOrEmpty(row["ImageCreatedOriginal"]))
            {
                file.Properties.Set(ExifTag.DateTimeOriginal, Convert.ToDateTime(row["ImageCreatedOriginal"]));
            }
            if (!string.IsNullOrEmpty(row["ImageTaken"]))
            {
                file.Properties.Set(ExifTag.DateTime, Convert.ToDateTime(row["ImageTaken"]));
            }
            if (!string.IsNullOrEmpty(row["GPSImageTaken"]))
            {
                var gDate = Convert.ToDateTime(row["GPSImageTaken"]);
                file.Properties.Set(ExifTag.GPSDateStamp, gDate.ToString("yyyy:MM:dd"));
                file.Properties.Set(ExifTag.GPSTimeStamp, (float)gDate.Hour, (float)gDate.Minute, (float)gDate.Second);
            }

            if (!string.IsNullOrEmpty(row["Latitude"]))
            {
                var value = row["Latitude"];
                file.Properties.Set(ExifTag.GPSLatitude, value.ToGpsDegrees(), value.ToGpsMinutes(), value.ToGpsSeconds());
                file.Properties.Set(ExifTag.GPSLatitudeRef, value.ToGpsSector());
            }
            if (!string.IsNullOrEmpty(row["Longitude"]))
            {
                var value = row["Longitude"];
                file.Properties.Set(ExifTag.GPSLongitude, value.ToGpsDegrees(), value.ToGpsMinutes(), value.ToGpsSeconds());
                file.Properties.Set(ExifTag.GPSLongitudeRef, value.ToGpsSector());
            }


            file.Save(filename);
        }

        private void CreateTheJpegFiles(TableRow row)
        {
            var fi = new FileInfo(Path.Combine(TestFileFolder, row["Folder"], row["FileName"]));
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            File.WriteAllBytes(fi.FullName, CreateGridImage());
            AddExifTagstoFile(fi.FullName, row);
        }
    }
}