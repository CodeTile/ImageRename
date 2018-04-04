using System;
using System.IO;
using ImageRename.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test.Model
{
    [TestClass]
    public class ImageFileTests
    {
        private string GetGoodJpegPath => Path.GetFullPath(".\\Test Files\\JPG\\Good.jpg");
        private string GetBadJpegPath => Path.GetFullPath(".\\Test Files\\JPG\\Bad.jpg");

        [TestMethod]
        public void ConstructorTest01()
        {
            var actual = new ImageFileJpeg(GetGoodJpegPath);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IImageFile));
            Assert.AreEqual(Convert.ToDateTime("10 March 2018 11:53:53"), actual.ImageCreated);
            Assert.IsTrue(actual.NeedsRenaming);
            Assert.AreEqual("20180310_115353", actual.NewFileName);
            var expectedNewFilePath = GetGoodJpegPath.Replace("Good", actual.NewFileName);
            Assert.AreEqual(expectedNewFilePath, actual.NewFilePath);
        }

        [TestMethod]
        public void ConstructorTest02()
        {
            var actual = new ImageFileJpeg(GetBadJpegPath);
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(IImageFile));

            Assert.IsNull(actual.ImageCreated);
            Assert.IsFalse(actual.NeedsRenaming);
            Assert.IsNull(actual.NewFileName);
            Assert.IsNull(actual.NewFilePath);
        }
    }
}
