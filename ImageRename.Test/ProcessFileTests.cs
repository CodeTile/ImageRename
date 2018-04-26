using System.IO;
using System.Linq;
using ImageRename.Standard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test
{
    [TestClass]
    public class ProcessFileTests
    {
        private string _processFolderMoveTestProcessedroot = Path.GetFullPath(".\\ProcessFolderMoveTestProcessed");
        /// <summary>
        /// Reset the content of the test folders
        /// </summary>
        [TestInitialize]
        public void Initilise()
        {
            Helper.DeleteDirectory(_processFolderMoveTestProcessedroot);

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

            var target = new ProcessFolder()
            {
                DebugDontRenameFile = false,
                MoveToProcessedByYear = true,
                ProcessedPath = _processFolderMoveTestProcessedroot
            };

            target.Process(originalPath);

            var filesOriginal = Directory.GetFiles(originalPath, "*", SearchOption.AllDirectories);
            var filesProcessed = Directory.GetFiles(_processFolderMoveTestProcessedroot, "*", SearchOption.AllDirectories);
            var filesInFolders = $"\r\nOriginal path:\r\n\t{string.Join("\r\n\t", filesOriginal).Replace(originalPath, string.Empty)}"
                               + $"\r\nProcessed path:\r\n\t{string.Join("\r\n\t", filesProcessed).Replace(_processFolderMoveTestProcessedroot, string.Empty)}";

            Assert.AreEqual(1, filesOriginal.Count(), $"{filesInFolders}");
            Assert.AreEqual(6, filesProcessed.Count(), $"{filesInFolders}");
            //Processed files
            Assert.IsTrue(filesProcessed.Contains($"{_processFolderMoveTestProcessedroot}\\2018\\Q2\\20180408_122634.CR2"), $"\r\nMissing file \r\n\t\\2018\\Q2\\20180408_122634.CR2{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{_processFolderMoveTestProcessedroot}\\2018\\Q2\\20180408_072740.CR2"), $"\r\nMissing file \r\n\t\\2018\\Q2\\20180408_072740.CR2{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{_processFolderMoveTestProcessedroot}\\2018\\Q1\\20180310_115353.jpg"), $"\r\nMissing file \r\n\t\\2018\\Q1\\20180310_115353.jpg{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{_processFolderMoveTestProcessedroot}\\2016\\Q1\\20160124_141022.MOV"), $"\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141022.MOV{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{_processFolderMoveTestProcessedroot}\\2016\\Q1\\20160124_141026.MOV"), $"\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141026.MOV{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{_processFolderMoveTestProcessedroot}\\2015\\Q4\\20151129_093544.MOV"), $"\r\nMissing file \r\n\t\\2015\\Q4\\20151129_093544.MOV{filesInFolders}");
            //Failed to process files
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\JPG\\Bad.jpg"), $"Missing file \r\n\\JPG\\Bad.jpg{filesInFolders}");
            /////////////////////////////////////////////////////
            //   Check empty directories have been removed
            /////////////////////////////////////////////////////

            var originalDirectories = Directory.EnumerateDirectories(originalPath,"*",SearchOption.AllDirectories).ToList();
            var directoriesInOriginalPath = $"\r\nOriginal path:\r\n\t{string.Join("\r\n\t", originalDirectories).Replace(originalPath, string.Empty)}";
            Assert.AreEqual(1, originalDirectories.Count(),$"{directoriesInOriginalPath}");
            Assert.IsTrue(originalDirectories.Contains($"{originalPath}\\JPG"),$"{directoriesInOriginalPath}");
        }


    }

}
