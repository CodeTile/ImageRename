using System.IO;
using System.Linq;
using ImageRename.Standard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test
{
    [TestClass]
    public class ProcessFileTests
    {
        /// <summary>
        /// Reset the content of the test folders
        /// </summary>
        [TestInitialize]
        public void Initilise()
        {
            var originalFolder = Path.GetFullPath(".\\..\\..\\Test Files");
            Helper.DirectoryCopy(Path.Combine(originalFolder, "JPG"), Path.Combine(Helper.TestSourceFolder, "JPG"));
            Helper.DirectoryCopy(Path.Combine(originalFolder, "CR2"), Path.Combine(Helper.TestSourceFolder, "CR2"));
            Helper.DirectoryCopy(Path.Combine(originalFolder, "mov"), Path.Combine(Helper.TestSourceFolder, "mov"));
            /////////////////////////////////////////////////////////////////////////////////////////
            Helper.CopyTestFilesTo(Path.GetFullPath(".\\ProcessFolderDontMoveTest"));
            Helper.CopyTestFilesTo(Path.GetFullPath(".\\ProcessFolderMoveTest"));
        }

        [TestMethod]
        public void ProcessFolderTestSimpleRunsTest()
        {
           
            var target = new ProcessFolder()
            {
                DebugDontRenameFile = true
            };

            target.Process(Helper.TestSourceFolder);

        }

        [TestMethod]
        public void ProcessFolderDontMoveTest()
        {
            var originalPath = Path.GetFullPath(".\\ProcessFolderDontMoveTest");
            
            var target = new ProcessFolder()
            {
                DebugDontRenameFile = false,
                MoveToProcessedByYear = false,
                ProcessedPath = null
            };

            target.Process(originalPath);

            var files = Directory.GetFiles(originalPath, "*", SearchOption.AllDirectories);
            var filesInFolder = $"\r\nFiles in folder and sub-folder:\r\n\t{string.Join("\r\n\t", files).Replace(originalPath, string.Empty)}";

            Assert.AreEqual(7, files.Count(), filesInFolder);
            Assert.IsTrue(files.Contains($"{originalPath}\\CR2\\20180408_122634.CR2"), $"Missing file \r\n\\CR2\\20180408_122634.CR2{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\CR2\\20180408_072740.CR2"), $"Missing file \r\n\\CR2\\20180408_072740.CR2{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\JPG\\20180310_115353.jpg"), $"Missing file \r\n\\JPG\\20180310_115353.jpg{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\JPG\\Bad.jpg"), $"Missing file \r\n\\JPG\\Bad.jpg{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\mov\\20160124_141026.MOV"), $"Missing file \r\n\\mov\\20160124_141026.MOV{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\mov\\20160124_141022.MOV"), $"Missing file \r\n\\mov\\20160124_141022.MOV{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\mov\\20151129_093544.MOV"), $"Missing file \r\n\\mov\\20151129_093544.MOV{filesInFolder}");

        }

        [TestMethod]
        public void ProcessFolderMoveTest()
        {
            var originalPath = Path.GetFullPath(".\\ProcessFolderMoveTest");
            var processedPath = Path.GetFullPath(".\\ProcessFolderMoveTestProcessed");

            var target = new ProcessFolder()
            {
                DebugDontRenameFile = false,
                MoveToProcessedByYear = true,
                ProcessedPath = processedPath
            };

            target.Process(originalPath);

            var filesOriginal = Directory.GetFiles(originalPath, "*", SearchOption.AllDirectories);
            var filesProcessed = Directory.GetFiles(processedPath, "*", SearchOption.AllDirectories);
            var filesInFolders = $"\r\nOriginal:\r\n\t{string.Join("\r\n\t", filesOriginal).Replace(originalPath, string.Empty)}"
                               + $"\r\nProcessed:\r\n\t{string.Join("\r\n\t", filesProcessed).Replace(processedPath, string.Empty)}";

            Assert.AreEqual(6, filesOriginal.Count(), filesInFolders);
            Assert.AreEqual(1, filesProcessed.Count(), filesInFolders);
            //Processed files
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\CR2\\20180408_122634.CR2"), $"Missing file \r\n\\CR2\\20180408_122634.CR2{filesInFolders}");
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\CR2\\20180408_072740.CR2"), $"Missing file \r\n\\CR2\\20180408_072740.CR2{filesInFolders}");
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\JPG\\20180310_115353.jpg"), $"Missing file \r\n\\JPG\\20180310_115353.jpg{filesInFolders}");
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\mov\\20160124_141026.MOV"), $"Missing file \r\n\\mov\\20160124_141026.MOV{filesInFolders}");
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\mov\\20160124_141022.MOV"), $"Missing file \r\n\\mov\\20160124_141022.MOV{filesInFolders}");
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\mov\\20151129_093544.MOV"), $"Missing file \r\n\\mov\\20151129_093544.MOV{filesInFolders}");
            //Faild to process files
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\JPG\\Bad.jpg"), $"Missing file \r\n\\JPG\\Bad.jpg{filesInFolders}");

        }


    }

}
