using System;
using System.IO;
using System.Linq;
using ImageRename.Standard.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test.Model
{
    [TestClass]
    public class ImageFileTests
    {
        /// <summary>
        /// Reset the content of the test folders
        /// </summary>
        [TestInitialize]
        public void Initilise()
        {
            var originalFolder = Path.GetFullPath(".\\..\\..\\Test Files");
            var testSourceFolder = Path.GetFullPath(".\\Test Files");
            Helper.DirectoryCopy(Path.Combine(originalFolder, "JPG"), Path.Combine(testSourceFolder, "JPG"));
            Helper.DirectoryCopy(Path.Combine(originalFolder, "CR2"), Path.Combine(testSourceFolder, "CR2"));
            Helper.DirectoryCopy(Path.Combine(originalFolder, "mov"), Path.Combine(testSourceFolder, "mov"));
            /////////////////////////////////////////////////////////////////////////////////////////
        }

        [DataRow("JPG 01", ".\\Test Files\\JPG\\Good.jpg", "20180310_115353", "10 March 2018 11:53:53", true, false, null, null)]
        [DataRow("JPG 02", ".\\Test Files\\JPG\\Good.jpg", "20180310_115353", "10 March 2018 11:53:53", true, true, ".\\Processed", ".\\Processed\\2018\\Q1\\20180310_115353.jpg")]
        [DataRow("JPG 03", ".\\Test Files\\JPG\\Bad.jpg", null, null, false, false, null, null)]

        [DataRow("CR2 01", ".\\Test Files\\CR2\\Good.CR2", "20180408_072740", "08 April 2018 07:27:40", true, false, null, null)]
        [DataRow("CR2 02", ".\\Test Files\\CR2\\20180408_122634.CR2", "20180408_122634", "08 April 2018 12:26:34", false, false, null, null)]
        [DataRow("CR2 03", ".\\Test Files\\CR2\\20180408_122634.CR2", "20180408_122634", "08 April 2018 12:26:34", false, true, ".\\Processed", ".\\Processed\\2018\\Q2\\20180408_122634.CR2")]

        [DataRow("MOV 01", ".\\Test Files\\mov\\20160124_141026.MOV", "20160124_141026", "24 January 2016 14:10:26", false, false, null, null)]
        [DataRow("MOV 02", ".\\Test Files\\mov\\Good.MOV", "20160124_141022", "24 January 2016 14:10:22", true, false, null, null)]
        [DataRow("MOV 03", ".\\Test Files\\mov\\Good2.MOV", "20151129_093544", "29 November 2015 09:35:44", true, true, ".\\Processed", ".\\Processed\\2015\\Q4\\20151129_093544.MOV")]
        [DataTestMethod]
        public void ImageFileTest(string test,
                                  string relativePath,
                                  string expectedNewFileName,
                                  string expectedDate,
                                  bool expectedNeedsRenaming,
                                  bool expectedNeedsMoving,
                                  string relativeProcessedPath,
                                  string expectedProcessedPath)
        {
            var path = Path.GetFullPath(relativePath);
            string processedPath = null;
            var originalExtension = path.Split('.').Last();
            var originalFileName = relativePath.Split('\\').Last().Replace($".{originalExtension}", string.Empty);
            IImageFile actual;
            if (!string.IsNullOrEmpty(relativeProcessedPath))
            {
                processedPath = Path.GetFullPath(relativeProcessedPath);
            }

            switch (originalExtension.ToLower())
            {
                case "mov":
                case "m4a":
                    actual = new VideoFile(path, processedPath);
                    break;
                //case "nef":
                //    actual = new ImageFileNEF(path);
                //    break;
                case "cr2":
                    actual = new ImageFileCR2(path, Convert.ToString(processedPath));
                    break;

                case "jpg":
                case "jpeg":
                    actual = new ImageFile(path, Convert.ToString(processedPath));
                    break;
                default:
                    throw new NotImplementedException();
            }

            Assert.IsNotNull(actual, "\r\nImageFile not constructed.");
            Assert.IsInstanceOfType(actual, typeof(IImageFile));
            Assert.AreEqual(actual.NeedsMoving, expectedNeedsMoving, "\r\nNeedsMoving property\r\n");

            if (expectedDate == null)
            {
                Assert.IsNull(actual.ImageCreated, "\r\nExpected date was expected to be null");
            }
            else
            {
                Assert.IsNotNull(actual.ImageCreated, $"\r\nImageCreated field is null.");
                var createdDateExpected = Convert.ToDateTime(expectedDate);
                var createdDateActual = (DateTime)actual.ImageCreated;

                Assert.AreEqual(createdDateExpected, createdDateActual,
                    $"\r\nExpected date and ImageCreated date to not match.\r\nActual:\t\t{createdDateExpected}\r\nExpected:\t{createdDateActual}");
            }

            Assert.AreEqual(expectedNewFileName, actual.DestinationFileName, "\r\nExpected newFileName and Actual newFileName do not match");
            Assert.AreEqual(expectedNeedsRenaming, actual.NeedsRenaming, "\r\nActual Needs renaiming flag does not match expected flag");

            if (!string.IsNullOrEmpty(processedPath))
            {
                var expectedNewFilePath = Path.GetFullPath(expectedProcessedPath);
                Assert.AreEqual(expectedNewFilePath, actual.DestinationFilePath,
                    $"\r\nExpected and actual DestinationFilePath do not match.\r\nActual:\t\t{actual.DestinationFilePath}\r\nExpected:\t{expectedNewFilePath}");
            }
            else if (expectedNeedsRenaming)
            {
                var expectedNewFilePath = path.Replace(originalFileName, expectedNewFileName);
                Assert.AreEqual(expectedNewFilePath, actual.DestinationFilePath, "\r\nExpected and actual NewFilePath do not match.");
            }
            else
            {
                Assert.IsNull(actual.DestinationFilePath, "\r\nNewFilePath should be null");
            }
        }
    }
}
