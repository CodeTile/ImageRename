using System;
using System.IO;
using System.Linq;
using ImageRename.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test.Model
{
    [TestClass]
    public class ImageFileTests
    {
        [DataRow(".\\Test Files\\JPG\\Good.jpg", "20180310_115353", "10 March 2018 11:53:53", true)]
        [DataRow(".\\Test Files\\JPG\\Bad.jpg", null, null, false)]
        [DataRow(".\\Test Files\\CR2\\Good.CR2", "20180408_072740", "08 April 2018 07:27:40", true)]
        [DataRow(".\\Test Files\\CR2\\20180408_122634.CR2", "20180408_122634", "08 April 2018 12:26:34", false)]
        //[DataRow(".\\Test Files\\NEF\\Good.NEF", "20080508_1756", "08 May 2008 17:56:09", true)]
        [DataTestMethod]
        public void ImageFileTest(string relativePath, string expectedNewFileName, string expectedDate, bool expectedNeedsRenaming)
        {
            var path = Path.GetFullPath(relativePath);
            var originalExtension = path.Split('.').Last();
            var originalFileName = relativePath.Split('\\').Last().Replace($".{originalExtension}", string.Empty);
            IImageFile actual;
            if (originalExtension.Equals("nef", StringComparison.CurrentCultureIgnoreCase))
            {

                actual = new ImageFileNEF(path);
            }
            else
            {
                actual = new ImageFile(path);

            }
            Assert.IsNotNull(actual, "ImageFile not constructed.");
            Assert.IsInstanceOfType(actual, typeof(IImageFile));

            if (expectedDate == null)
            {
                Assert.IsNull(actual.ImageCreated);
            }
            else
            {
                Assert.AreEqual(Convert.ToDateTime(expectedDate), actual.ImageCreated);
            }
            Assert.AreEqual(expectedNewFileName, actual.NewFileName);
            Assert.AreEqual(expectedNeedsRenaming, actual.NeedsRenaming);
            if (expectedNeedsRenaming)
            {
                var expectedNewFilePath = path.Replace(originalFileName, expectedNewFileName);
                Assert.AreEqual(expectedNewFilePath, actual.NewFilePath);
            }
            else
            {
                Assert.IsNull(actual.NewFilePath, "NewFilePath should be null");
            }
        }
    }
}
