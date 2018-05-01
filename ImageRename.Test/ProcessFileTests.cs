using System.IO;
using System.Linq;
using ImageRename.Standard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageRename.Test
{
    [TestClass]
    public class ProcessFileTests
    {
        private static class FilePaths
        {
            public static string ProcessFolderDontMoveTest = Path.GetFullPath(".\\ProcessFolderDontMoveTest");

            public static string ProcessFolderMoveTest = Path.GetFullPath(".\\ProcessFolderMoveTest");
            public static string ProcessFolderMoveTestProcessedroot = Path.GetFullPath(".\\ProcessFolderMoveTestProcessed");
            public static string DuplicateTimeStampDontMove = Path.GetFullPath(".\\DuplicateTimeStampDontMove");
            public static string DuplicateTimeStampMove = Path.GetFullPath(".\\DuplicateTimeStampMove");
            public static string DuplicateTimeStampMoveProcessed = Path.GetFullPath(".\\DuplicateTimeStampMoveProcessed");
        }

        /// <summary>
        /// Reset the content of the test folders
        /// </summary>
        [TestInitialize]
        public void Initilise()
        {
            Helper.DeleteDirectory(FilePaths.ProcessFolderMoveTestProcessedroot);
            Helper.DeleteDirectory(FilePaths.DuplicateTimeStampMoveProcessed);

            var originalFolder = Path.GetFullPath(".\\..\\..\\Test Files");
            Helper.DirectoryCopy(Path.Combine(originalFolder, "JPG"), Path.Combine(Helper.TestSourceFolder, "JPG"));
            Helper.DirectoryCopy(Path.Combine(originalFolder, "CR2"), Path.Combine(Helper.TestSourceFolder, "CR2"));
            Helper.DirectoryCopy(Path.Combine(originalFolder, "mov"), Path.Combine(Helper.TestSourceFolder, "mov"));
            /////////////////////////////////////////////////////////////////////////////////////////
            Helper.CopyTestFilesTo(FilePaths.ProcessFolderDontMoveTest);
            Helper.CopyTestFilesTo(FilePaths.ProcessFolderMoveTest);

            Helper.CopyTestFilesTo(FilePaths.DuplicateTimeStampDontMove);
            Helper.CopyTestFilesTo(FilePaths.DuplicateTimeStampMove);

            Helper.DuplicateFile(FilePaths.DuplicateTimeStampDontMove, "CR2\\Good.CR2", "CR2\\Duplicate.CR2");
            Helper.DuplicateFile(FilePaths.DuplicateTimeStampDontMove, "JPG\\Good.jpg", "JPG\\Duplicate.jpg");
            Helper.DuplicateFile(FilePaths.DuplicateTimeStampDontMove, "mov\\Good.MOV", "mov\\Duplicate.MOV");

            Helper.DuplicateFile(FilePaths.DuplicateTimeStampMove, "CR2\\Good.CR2", "CR2\\Duplicate.CR2");
            Helper.DuplicateFile(FilePaths.DuplicateTimeStampMove, "JPG\\Good.jpg", "JPG\\Duplicate.jpg");
            Helper.DuplicateFile(FilePaths.DuplicateTimeStampMove, "mov\\Good.MOV", "mov\\Duplicate.MOV");
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
            var originalPath = FilePaths.ProcessFolderDontMoveTest;

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
            var originalPath = FilePaths.ProcessFolderMoveTest;

            var target = new ProcessFolder()
            {
                DebugDontRenameFile = false,
                MoveToProcessedByYear = true,
                ProcessedPath = FilePaths.ProcessFolderMoveTestProcessedroot
            };

            target.Process(originalPath);

            var filesOriginal = Directory.GetFiles(originalPath, "*", SearchOption.AllDirectories);
            var filesProcessed = Directory.GetFiles(FilePaths.ProcessFolderMoveTestProcessedroot, "*", SearchOption.AllDirectories);
            var filesInFolders = $"\r\nOriginal path:\r\n\t{string.Join("\r\n\t", filesOriginal).Replace(originalPath, string.Empty)}"
                               + $"\r\nProcessed path:\r\n\t{string.Join("\r\n\t", filesProcessed).Replace(FilePaths.ProcessFolderMoveTestProcessedroot, string.Empty)}";

            Assert.AreEqual(1, filesOriginal.Count(), $"{filesInFolders}");
            Assert.AreEqual(6, filesProcessed.Count(), $"{filesInFolders}");
            //Processed files
            Assert.IsTrue(filesProcessed.Contains($"{FilePaths.ProcessFolderMoveTestProcessedroot}\\2018\\Q2\\20180408_122634.CR2"), $"\r\nMissing file \r\n\t\\2018\\Q2\\20180408_122634.CR2{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{FilePaths.ProcessFolderMoveTestProcessedroot}\\2018\\Q2\\20180408_072740.CR2"), $"\r\nMissing file \r\n\t\\2018\\Q2\\20180408_072740.CR2{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{FilePaths.ProcessFolderMoveTestProcessedroot}\\2018\\Q1\\20180310_115353.jpg"), $"\r\nMissing file \r\n\t\\2018\\Q1\\20180310_115353.jpg{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{FilePaths.ProcessFolderMoveTestProcessedroot}\\2016\\Q1\\20160124_141022.MOV"), $"\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141022.MOV{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{FilePaths.ProcessFolderMoveTestProcessedroot}\\2016\\Q1\\20160124_141026.MOV"), $"\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141026.MOV{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{FilePaths.ProcessFolderMoveTestProcessedroot}\\2015\\Q4\\20151129_093544.MOV"), $"\r\nMissing file \r\n\t\\2015\\Q4\\20151129_093544.MOV{filesInFolders}");
            //Failed to process files
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\JPG\\Bad.jpg"), $"Missing file \r\n\\JPG\\Bad.jpg{filesInFolders}");
            /////////////////////////////////////////////////////
            //   Check empty directories have been removed
            /////////////////////////////////////////////////////

            var originalDirectories = Directory.EnumerateDirectories(originalPath, "*", SearchOption.AllDirectories).ToList();
            var directoriesInOriginalPath = $"\r\nOriginal path:\r\n\t{string.Join("\r\n\t", originalDirectories).Replace(originalPath, string.Empty)}";
            Assert.AreEqual(1, originalDirectories.Count(), $"{directoriesInOriginalPath}");
            Assert.IsTrue(originalDirectories.Contains($"{originalPath}\\JPG"), $"{directoriesInOriginalPath}");
        }

        [TestMethod]
        public void DuplicateTimeStampDontMove()
        {
            var originalPath = FilePaths.DuplicateTimeStampDontMove;
            var target = new ProcessFolder()
            {
                DebugDontRenameFile = false,
                MoveToProcessedByYear = false,
                ProcessedPath = null
            };

            target.Process(originalPath);

            var files = Directory.GetFiles(originalPath, "*", SearchOption.AllDirectories);
            var filesInFolder = $"\r\nFiles in folder and sub-folder:\r\n\t{string.Join("\r\n\t", files).Replace(originalPath, string.Empty)}";
            Assert.AreEqual(10, files.Count(), filesInFolder);

            Assert.IsTrue(files.Contains($"{originalPath}\\CR2\\20180408_122634.CR2"), $"Missing file \r\n\\CR2\\20180408_122634.CR2{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\CR2\\20180408_072740.CR2"), $"Missing file \r\n\\CR2\\20180408_072740.CR2{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\CR2\\20180408_072740_2.CR2"), $"Missing file \r\n\\CR2\\20180408_072740_2.CR2{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\JPG\\20180310_115353.jpg"), $"Missing file \r\n\\JPG\\20180310_115353.jpg{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\JPG\\20180310_115353_2.jpg"), $"Missing file \r\n\\JPG\\20180310_115353_2.jpg{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\JPG\\Bad.jpg"), $"Missing file \r\n\\JPG\\Bad.jpg{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\mov\\20160124_141026.MOV"), $"Missing file \r\n\\mov\\20160124_141026.MOV{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\mov\\20160124_141022.MOV"), $"Missing file \r\n\\mov\\20160124_141022.MOV{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\mov\\20160124_141022_2.MOV"), $"Missing file \r\n\\mov\\20160124_141022_2.MOV{filesInFolder}");
            Assert.IsTrue(files.Contains($"{originalPath}\\mov\\20151129_093544.MOV"), $"Missing file \r\n\\mov\\20151129_093544.MOV{filesInFolder}");
        }

        [TestMethod]
        public void DuplicateTimeStampMove()
        {
            var originalPath = FilePaths.DuplicateTimeStampMove;
            var processedPath = FilePaths.DuplicateTimeStampMoveProcessed;
            var target = new ProcessFolder()
            {
                DebugDontRenameFile = false,
                MoveToProcessedByYear = true,
                ProcessedPath = processedPath
            };

            target.Process(originalPath);

            var filesOriginal = Directory.GetFiles(originalPath, "*", SearchOption.AllDirectories);
            var filesProcessed = Directory.GetFiles(processedPath, "*", SearchOption.AllDirectories);
            var filesInFolders = $"\r\nOriginal path:\r\n\t{originalPath}\r\n\t{string.Join("\r\n\t", filesOriginal).Replace(originalPath, string.Empty)}"
                               + $"\r\nProcessed path:\r\n\t{processedPath}\r\n\t{string.Join("\r\n\t", filesProcessed).Replace(processedPath, string.Empty)}";

            Assert.AreEqual(1, filesOriginal.Count(), $"{filesInFolders}");
            Assert.AreEqual(9, filesProcessed.Count(), $"{filesInFolders}");
            //Processed files
            Assert.IsTrue(filesProcessed.Contains($"{processedPath}\\2018\\Q2\\20180408_122634.CR2"), $"\r\nMissing file \r\n\t\\2018\\Q2\\20180408_122634.CR2{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{processedPath}\\2018\\Q2\\20180408_072740.CR2"), $"\r\nMissing file \r\n\t\\2018\\Q2\\20180408_072740.CR2{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{processedPath}\\2018\\Q1\\20180310_115353.jpg"), $"\r\nMissing file \r\n\t\\2018\\Q1\\20180310_115353.jpg{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{processedPath}\\2016\\Q1\\20160124_141022.MOV"), $"\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141022.MOV{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{processedPath}\\2016\\Q1\\20160124_141026.MOV"), $"\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141026.MOV{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{processedPath}\\2015\\Q4\\20151129_093544.MOV"), $"\r\nMissing file \r\n\t\\2015\\Q4\\20151129_093544.MOV{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{processedPath}\\2018\\Q2\\20180408_072740_2.CR2"), $"\r\nMissing file \r\n\t\\2018\\Q2\\20180408_072740_2.CR2{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{processedPath}\\2018\\Q1\\20180310_115353_2.jpg"), $"\r\nMissing file \r\n\t\\2018\\Q1\\20180310_115353_2.jpg{filesInFolders}");
            Assert.IsTrue(filesProcessed.Contains($"{processedPath}\\2016\\Q1\\20160124_141022_2.MOV"), $"\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141022_2.MOV{filesInFolders}");
            //Failed to process files
            Assert.IsTrue(filesOriginal.Contains($"{originalPath}\\JPG\\Bad.jpg"), $"Missing file \r\n\\JPG\\Bad.jpg{filesInFolders}");
            /////////////////////////////////////////////////////
            //   Check empty directories have been removed
            /////////////////////////////////////////////////////

            var originalDirectories = Directory.EnumerateDirectories(originalPath, "*", SearchOption.AllDirectories).ToList();
            var directoriesInOriginalPath = $"\r\nOriginal path:\r\n\t{string.Join("\r\n\t", originalDirectories).Replace(originalPath, string.Empty)}";
            Assert.AreEqual(1, originalDirectories.Count(), $"{directoriesInOriginalPath}");
            Assert.IsTrue(originalDirectories.Contains($"{originalPath}\\JPG"), $"{directoriesInOriginalPath}");

        }
    }
}
