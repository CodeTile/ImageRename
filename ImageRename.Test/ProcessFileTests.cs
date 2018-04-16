using System.IO;
using System.Linq;
using ImageRename.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test
{
    [TestClass]
    public class ProcessFileTests
    {
        [TestMethod]
        public void ProcessFolderTest01()
        {
            var path = Path.GetFullPath(".\\Test Files");
            var target = new ProcessFolder()
            {
                DebugDontRenameFile = true
            };

            target.Process(path);

        }

        [TestMethod]
        public void ProcessFolderTest02()
        {
            
            var originalPath = Path.GetFullPath(".\\Test Files");
            var targetPath = Path.GetFullPath(".")+ "\\ProcessFolderTest02";
            if(Directory.Exists(targetPath))
            {
                Directory.Delete(targetPath, true);
            }

            Helper.DirectoryCopy(originalPath, targetPath, true);

            var target = new ProcessFolder();

            target.Process(targetPath);

            var files = Directory.GetFiles(targetPath,"*",SearchOption.AllDirectories);
            Assert.AreEqual(6, files.Count(), $"\r\n\t{string.Join("\r\n\t", files).Replace(targetPath,string.Empty)}");
            Assert.IsTrue(files.Contains($"{targetPath}\\CR2\\20180408_122634.CR2"), "Missing file \r\n\\CR2\\20180408_122634.CR2");
            Assert.IsTrue(files.Contains($"{targetPath}\\CR2\\20180408_072740.CR2"), "Missing file \r\n\\CR2\\20180408_072740.CR2");
            Assert.IsTrue(files.Contains($"{targetPath}\\JPG\\20180310_115353.jpg"), "Missing file \r\n\\JPG\\20180310_115353.jpg");
            Assert.IsTrue(files.Contains($"{targetPath}\\JPG\\Bad.jpg"), "Missing file \r\n\\JPG\\Bad.jpg");
            Assert.IsTrue(files.Contains($"{targetPath}\\mov\\20160124_141026.MOV"), "Missing file \r\n\\mov\\20160124_141026.MOV");
            Assert.IsTrue(files.Contains($"{targetPath}\\mov\\20160124_141022.MOV"), "Missing file \r\n\\mov\\20160124_141022.MOV");
            //Assert.IsTrue(files.Contains($"{targetPath}\\NEF\\Bad.nef"), "Missing file");

            Directory.Delete(targetPath, true);
        }

    }

}
