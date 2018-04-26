﻿using System.IO;
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
            var targetPath = Path.GetFullPath(".\\ProcessFolderDontMoveTest");
            
            var target = new ProcessFolder()
            {
                DebugDontRenameFile = false,
                MoveToProcessedByYear = false,
                ProcessedPath = null
            };

            target.Process(targetPath);

            var files = Directory.GetFiles(targetPath, "*", SearchOption.AllDirectories);
            var filesInFolder = $"\r\nFiles in folder and sub-folder:\r\n\t{string.Join("\r\n\t", files).Replace(targetPath, string.Empty)}";

            Assert.AreEqual(7, files.Count(), filesInFolder);
            Assert.IsTrue(files.Contains($"{targetPath}\\CR2\\20180408_122634.CR2"), $"Missing file \r\n\\CR2\\20180408_122634.CR2{filesInFolder}");
            Assert.IsTrue(files.Contains($"{targetPath}\\CR2\\20180408_072740.CR2"), $"Missing file \r\n\\CR2\\20180408_072740.CR2{filesInFolder}");
            Assert.IsTrue(files.Contains($"{targetPath}\\JPG\\20180310_115353.jpg"), $"Missing file \r\n\\JPG\\20180310_115353.jpg{filesInFolder}");
            Assert.IsTrue(files.Contains($"{targetPath}\\JPG\\Bad.jpg"), $"Missing file \r\n\\JPG\\Bad.jpg{filesInFolder}");
            Assert.IsTrue(files.Contains($"{targetPath}\\mov\\20160124_141026.MOV"), $"Missing file \r\n\\mov\\20160124_141026.MOV{filesInFolder}");
            Assert.IsTrue(files.Contains($"{targetPath}\\mov\\20160124_141022.MOV"), $"Missing file \r\n\\mov\\20160124_141022.MOV{filesInFolder}");
            Assert.IsTrue(files.Contains($"{targetPath}\\mov\\20151129_093544.MOV"), $"Missing file \r\n\\mov\\20151129_093544.MOV{filesInFolder}");

        }


    }

}
