using System;
using System.IO;
using System.Linq;
using ImageRename.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test.Model
{
    [TestClass]
    public class IImageFileTests
    {
        [DataRow(".\\Test Files\\JPG\\Good.jpg", "20180310_115353", "10 March 2018 11:53:53", true)]
        [DataRow(".\\Test Files\\JPG\\Bad.jpg", null, null, false)]
        [DataRow(".\\Test Files\\CR2\\Good.CR2", "20180408_072740", "08 April 2018 07:27:40", true)]
        [DataRow(".\\Test Files\\CR2\\20180408_122634.CR2", "20180408_122634", "08 April 2018 12:26:34", false)]
        [DataRow(".\\Test Files\\mov\\20160124_141026.MOV", "20160124_141026", "24 January 2016 14:10:26", false)]
        [DataRow(".\\Test Files\\mov\\Good.MOV", "20160124_141022", "24 January 2016 14:10:22", true)]

        //[DataRow(".\\Test Files\\NEF\\Good.NEF", "20080508_1756", "08 May 2008 17:56:09", true)]
        [DataTestMethod]
        public void ImageFileTest(string relativePath, string expectedNewFileName, string expectedDate, bool expectedNeedsRenaming)
        {
            var path = Path.GetFullPath(relativePath);
            var originalExtension = path.Split('.').Last();
            var originalFileName = relativePath.Split('\\').Last().Replace($".{originalExtension}", string.Empty);
            IImageFile actual;

            switch (originalExtension.ToLower())
            {
                case "mov":
                case "m4a":
                    actual = new VideoFile(path);
                    break;
                case "nef":
                    actual = new ImageFileNEF(path);
                    break;
                default:
                    actual = new ImageFile(path);
                    break;
            }
            
            Assert.IsNotNull(actual, "\r\nImageFile not constructed.");
            Assert.IsInstanceOfType(actual, typeof(IImageFile));

            if (expectedDate == null)
            {
                Assert.IsNull(actual.ImageCreated, "\r\nExpected date was expected to be null");
            }
            else
            {
                Assert.AreEqual(Convert.ToDateTime(expectedDate), actual.ImageCreated, "\r\nExpected date and ImageCreated date to not match");
            }
            Assert.AreEqual(expectedNewFileName, actual.NewFileName, "\r\nExpected newFileName and Actual newFileName do not match");
            Assert.AreEqual(expectedNeedsRenaming, actual.NeedsRenaming, "\r\nActual Needs renaiming flag does not match expected flag");
            if (expectedNeedsRenaming)
            {
                var expectedNewFilePath = path.Replace(originalFileName, expectedNewFileName);
                Assert.AreEqual(expectedNewFilePath, actual.NewFilePath, "\r\nExpected and actual NewFilePath do not match.");
            }
            else
            {
                Assert.IsNull(actual.NewFilePath, "\r\nNewFilePath should be null");
            }
        }
    }
}
