using System.IO;
using System.Linq;
using ImageRename.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test
{
    [TestClass]
    public class ProcessFileTests
    {
        [TestCleanup]
        [TestInitialize]
        public void TestInit()
        {
            Helper.DeleteDirectory("\\ProcessFolderTest02");
            Helper.DeleteDirectory("\\ProcessFolderTest03");
            System.Threading.Thread.Sleep(1000);
        }

        
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
            var targetPath = Path.GetFullPath(".") + "\\ProcessFolderTest02";
            if (Directory.Exists(targetPath))
            {
                Directory.Delete(targetPath, true);
            }

            Helper.DirectoryCopy(originalPath, targetPath, true);

            var target = new ProcessFolder()
            {
                DebugDontRenameFile = false,
                MoveToProcessedByYear = false,
                ProcessedPath = null
            };

            target.Process(targetPath);

            var files = Directory.GetFiles(targetPath, "*", SearchOption.AllDirectories);
            var filesmsg = $"\r\n\t{string.Join("\r\n\t", files).Replace(targetPath, string.Empty)}";
            Assert.AreEqual(7, files.Count(), filesmsg);
            Assert.IsTrue(files.Contains($"{targetPath}\\CR2\\20180408_122634.CR2"), $"Missing file \r\n\\CR2\\20180408_122634.CR2\r\n\r\n{filesmsg}");
            Assert.IsTrue(files.Contains($"{targetPath}\\CR2\\20180408_072740.CR2"), $"Missing file \r\n\\CR2\\20180408_072740.CR2\r\n\r\n{filesmsg}");
            Assert.IsTrue(files.Contains($"{targetPath}\\JPG\\20180310_115353.jpg"), $"Missing file \r\n\\JPG\\20180310_115353.jpg\r\n\r\n{filesmsg}");
            Assert.IsTrue(files.Contains($"{targetPath}\\JPG\\Bad.jpg"), $"Missing file \r\n\\JPG\\Bad.jpg\r\n\r\n{filesmsg}");
            Assert.IsTrue(files.Contains($"{targetPath}\\mov\\20160124_141026.MOV"), $"Missing file \r\n\\mov\\20160124_141026.MOV\r\n\r\n{filesmsg}");
            Assert.IsTrue(files.Contains($"{targetPath}\\mov\\20160124_141022.MOV"), $"Missing file \r\n\\mov\\20160124_141022.MOV\r\n\r\n{filesmsg}");
            Assert.IsTrue(files.Contains($"{targetPath}\\mov\\20151129_093544.MOV"), $"Missing file \r\n\\mov\\20151129_093544.MOV\r\n\r\n{filesmsg}");
            //Assert.IsTrue(files.Contains($"{targetPath}\\NEF\\Bad.nef"), "Missing file");

            Directory.Delete(targetPath, true);
        }

        //////[TestMethod]
        //////public void ProcessFolderTest03()
        //////{

        //////    var originalPath = Path.GetFullPath(".\\Test Files");
        //////    var sourcePath = Path.GetFullPath(".") + "\\ProcessFolderTest03\\Source";
        //////    var destinationPath = Path.GetFullPath(".") + "\\ProcessFolderTest03\\Destination";

        //////    Helper.DeleteDirectory(sourcePath);
        //////    Helper.DeleteDirectory(destinationPath);

        //////    Helper.DirectoryCopy(originalPath, sourcePath, true);

        //////    var target = new ProcessFolder()
        //////    {
        //////        DebugDontRenameFile = false,
        //////        MoveToProcessedByYear = true,
        //////        ProcessedPath = destinationPath
        //////    }; 

        //////    target.Process(sourcePath);

        //////    var sourceFiles = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories);
        //////    var destinationFiles = Directory.GetFiles(destinationPath, "*", SearchOption.AllDirectories);
        //////    string filesMsg = $"\r\nFiles in Source:\r\n\t{string.Join("\r\n\t", sourceFiles).Replace(sourcePath, string.Empty)}" +
        //////                      $"\r\nFiles in Destination:\r\n\t{string.Join("\r\n\t", destinationFiles).Replace(destinationPath, string.Empty)}";

        //////    Assert.AreEqual(1, sourceFiles.Count(), $"\r\nAm expecting no files in the source folder{filesMsg}");

        //////    Assert.AreEqual(7, destinationFiles.Count(), filesMsg);
        //////    Assert.IsTrue(destinationFiles.Contains($"{destinationPath}\\2018\\Q2\\20180408_122634.CR2"), $"Missing file \r\n\\2018\\Q2\\20180408_122634.CR2{filesMsg}");
        //////    Assert.IsTrue(destinationFiles.Contains($"{destinationPath}\\2018\\Q2\\20180408_072740.CR2"), $"Missing file \r\n\\2018\\Q2\\20180408_072740.CR2{filesMsg}");
        //////    Assert.IsTrue(destinationFiles.Contains($"{destinationPath}\\2016\\Q1\\20160124_141026.MOV"), $"Missing file \r\n\\2016\\Q1\\20160124_141026.MOV{filesMsg}");
        //////    Assert.IsTrue(destinationFiles.Contains($"{destinationPath}\\JPG\\Bad.jpg"), $"Missing file \r\n{filesMsg}");
        //////    Assert.IsTrue(destinationFiles.Contains($"{destinationPath}\\2016\\Q1\\20160124_141026.MOV"), $"Missing file \r\n\\2016\\Q1\\20160124_141026.MOV{filesMsg}");
        //////    Assert.IsTrue(destinationFiles.Contains($"{destinationPath}\\2016\\Q1\\20160124_141022.MOV"), $"Missing file \r\n\\2016\\Q1\\20160124_141022.MOV{filesMsg}");
        //////    Assert.IsTrue(destinationFiles.Contains($"{destinationPath}\\2015\\Q4\\20151129_093544.MOV"), $"Missing file \r\n\\2015\\Q4\\20151129_093544.MOV{filesMsg}");
        //////    //Assert.IsTrue(files.Contains($"{targetPath}\\NEF\\Bad.nef"), "Missing file");

        //////    Directory.Delete(sourcePath, true);
        //////    Directory.Delete(destinationPath, true);
        //////}

    }

}
