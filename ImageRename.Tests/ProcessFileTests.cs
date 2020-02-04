//////using System.Collections.ObjectModel;
//////using System.IO;
//////using System.Linq;
//////using ImageRename.Standard;
//////using Microsoft.VisualStudio.TestTools.UnitTesting;

//////namespace ImageRename.Test
//////{
//////    [TestClass]
//////    public class ProcessFileTests
//////    {
//////        private readonly string _processFolderDontMoveTest = Path.GetFullPath(".\\ProcessFolderDontMoveTest");
//////        private readonly string _processFolderMoveTest = Path.GetFullPath(".\\ProcessFolderMoveTest");
//////        private readonly string _processFolderMoveTestProcessed = Path.GetFullPath(".\\ProcessFolderMoveTestProcessed");
//////        private readonly string _duplicateTimeStampDontMove = Path.GetFullPath(".\\DuplicateTimeStampDontMove");
//////        private readonly string _duplicateTimeStampMove = Path.GetFullPath(".\\DuplicateTimeStampMove");
//////        private readonly string _duplicateTimeStampMoveProcessed = Path.GetFullPath(".\\DuplicateTimeStampMoveProcessed");
//////        private readonly string _duplicateTimeStampMoveWithExistingFiles = Path.GetFullPath(".\\DuplicateTimeStampMoveWithExistingFiles");
//////        private readonly string _duplicateTimeStampMoveWithExistingFilesProcessed = Path.GetFullPath(".\\DuplicateTimeStampMoveWithExistingFilesProcessed");
//////        private readonly string _GPSPopulated = Path.GetFullPath(".\\GPS\\Populated");
//////        private readonly string _GPSKeyWords= Path.GetFullPath(".\\GPS\\Keywords");

//////        /// <summary>
//////        /// Reset the content of the test folders
//////        /// </summary>
//////        [TestInitialize]
//////        public void Initilise()
//////        {
//////            Helper.DeleteDirectory(_duplicateTimeStampMoveWithExistingFilesProcessed);
//////            Helper.DeleteDirectory(_processFolderMoveTestProcessed);
//////            Helper.DeleteDirectory(_duplicateTimeStampMoveProcessed);
//////            Helper.DeleteDirectory(_GPSPopulated);
//////            Helper.DeleteDirectory(_GPSKeyWords);

//////            var originalFolder = Path.GetFullPath(".\\..\\..\\Test Files");
//////            Helper.DirectoryCopy(Path.Combine(originalFolder, "JPG"), Path.Combine(Helper.TestSourceFolder, "JPG"));
//////            Helper.DirectoryCopy(Path.Combine(originalFolder, "CR2"), Path.Combine(Helper.TestSourceFolder, "CR2"));
//////            Helper.DirectoryCopy(Path.Combine(originalFolder, "mov"), Path.Combine(Helper.TestSourceFolder, "mov"));
//////            Helper.DirectoryCopy(Path.Combine(originalFolder, "NEF"), Path.Combine(Helper.TestSourceFolder, "NEF"));

//////            /////////////////////////////////////////////////////////////////////////////////////////
//////            Helper.CopyTestFilesTo(_duplicateTimeStampDontMove);
//////            Helper.CopyTestFilesTo(_duplicateTimeStampMove);
//////            Helper.CopyTestFilesTo(_duplicateTimeStampMoveWithExistingFiles);

//////            Helper.CopyTestFilesTo(_processFolderDontMoveTest);
//////            Helper.CopyTestFilesTo(_processFolderMoveTest);

//////            Helper.DuplicateFile(_duplicateTimeStampDontMove, "CR2\\Good.CR2", "CR2\\Duplicate.CR2");
//////            Helper.DuplicateFile(_duplicateTimeStampDontMove, "JPG\\Good.jpg", "JPG\\Duplicate.jpg");
//////            Helper.DuplicateFile(_duplicateTimeStampDontMove, "JPG\\GPS.jpg", "JPG\\Duplicate.jpg");
//////            Helper.DuplicateFile(_duplicateTimeStampDontMove, "mov\\Good.MOV", "mov\\Duplicate.MOV");

//////            Helper.DuplicateFile(_duplicateTimeStampMove, "CR2\\Good.CR2", "CR2\\Duplicate.CR2");
//////            Helper.DuplicateFile(_duplicateTimeStampMove, "JPG\\Good.jpg", "JPG\\Duplicate.jpg");
//////            Helper.DuplicateFile(_duplicateTimeStampMove, "mov\\Good.MOV", "mov\\Duplicate.MOV");

//////            Helper.DuplicateFile(_duplicateTimeStampMoveWithExistingFiles, "CR2\\Good.CR2", "CR2\\Duplicate.CR2");
//////            Helper.DuplicateFile(_duplicateTimeStampMoveWithExistingFiles, "JPG\\Good.jpg", "JPG\\Duplicate.jpg");
//////            Helper.DuplicateFile(_duplicateTimeStampMoveWithExistingFiles, "mov\\Good.MOV", "mov\\Duplicate.MOV");

//////            Helper.CopyTestFileTo(Path.Combine(_duplicateTimeStampMoveWithExistingFiles, "CR2\\20180408_122634.CR2"),
//////                                  Path.Combine(_duplicateTimeStampMoveWithExistingFilesProcessed, "2018\\Q2\\20180408_122634.CR2"));
//////            Helper.CopyTestFileTo(Path.Combine(_duplicateTimeStampMoveWithExistingFiles, "CR2\\20180408_122634.CR2"),
//////                                  Path.Combine(_duplicateTimeStampMoveWithExistingFilesProcessed, "2018\\Q2\\20180408_122634_2.CR2"));
//////            Helper.CopyTestFileTo(Path.Combine(Helper.TestSourceFolder, "JPG", "GPS.JPG"),
//////                                  Path.Combine(_GPSPopulated, "GPS.JPG"));
//////            Helper.CopyTestFileTo(Path.Combine(Helper.TestSourceFolder, "JPG", "GPS.JPG"),
//////                                  Path.Combine(_GPSKeyWords, "GPS.JPG"));
//////        }

//////        [TestMethod]
//////        public void IsGpsPopulated()
//////        {
//////            var target = new ProcessFolder()
//////            {
//////                DebugDontRenameFile = false,
//////                MoveToProcessedByYear = false,
//////                ProcessedPath = null
//////            };
//////            target._images = new ObservableCollection<Standard.Model.IImageFile>();
//////            target.FindFiles(_GPSPopulated);
//////            var actual = target._images.Single();
//////            Assert.IsNotNull(actual.GPS);

//////        }

//////        [TestMethod]
//////        public void GPSKeyWords()
//////        {
//////            var target = new ProcessFolder()
//////            {
//////                DebugDontRenameFile = false,
//////                MoveToProcessedByYear = false,
//////                ProcessedPath = null
//////            };
//////            target._images = new ObservableCollection<Standard.Model.IImageFile>();
//////            target.FindFiles(_GPSPopulated);
//////            var actual = target._images.Single();
//////            Assert.IsNotNull(actual.GPS);

//////        }



//////       

//////        [TestMethod]
//////        public void DuplicateTimeStampMoveWithExistingFiles()
//////        {
//////            string[] filesOriginal = null;
//////            string[] filesSourceContent = null;
//////            string[] filesProcessedContent = null;
//////            var originalPath = _duplicateTimeStampMoveWithExistingFiles;
//////            var processedPath = _duplicateTimeStampMoveWithExistingFilesProcessed;
//////            var filesInFolders = GetFilesList("Orignal contents", originalPath, ref filesOriginal);

//////            var target = new ProcessFolder()
//////            {
//////                DebugDontRenameFile = false,
//////                MoveToProcessedByYear = true,
//////                ProcessedPath = processedPath
//////            };

//////            target.Process(originalPath);

//////            filesInFolders += GetFilesList("Source", originalPath, ref filesSourceContent)
//////                           + GetFilesList("Processed", processedPath, ref filesProcessedContent);

//////            Assert.AreEqual(1, filesSourceContent.Count(), $"\r\nOriginal folder check{filesInFolders}");
//////            Assert.AreEqual(14, filesProcessedContent.Count(), $"\r\nProcessed folder check{filesInFolders}");
//////            //Processed files
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2015\\Q4\\20151129_093543.MOV"), " $\r\nMissing file \r\n\t\\2015\\Q4\\20151129_093543.MOV{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2016\\Q1\\20160124_141020.MOV"), " $\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141020.MOV{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2016\\Q1\\20160124_141020_2.MOV"), " $\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141020_2.MOV{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2016\\Q1\\20160124_141023.MOV"), " $\r\nMissing file \r\n\t\\2016\\Q1\\20160124_141023.MOV{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2018\\Q1\\20180310_115353.jpg"), " $\r\nMissing file \r\n\t\\2018\\Q1\\20180310_115353.jpg{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2018\\Q1\\20180310_115353_2.jpg"), " $\r\nMissing file \r\n\t\\2018\\Q1\\20180310_115353_2.jpg{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2018\\Q2\\20180408_072740.CR2"), " $\r\nMissing file \r\n\t\\2018\\Q2\\20180408_072740.CR2{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2018\\Q2\\20180408_072740_2.CR2"), " $\r\nMissing file \r\n\t\\2018\\Q2\\20180408_072740_2.CR2{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2018\\Q2\\20180408_122634.CR2"), " $\r\nMissing file \r\n\t\\2018\\Q2\\20180408_122634.CR2{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2018\\Q2\\20180408_122634_2.CR2"), " $\r\nMissing file \r\n\t\\2018\\Q2\\20180408_122634_2.CR2{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2018\\Q2\\20180408_122634_3.CR2"), " $\r\nMissing file \r\n\t\\2018\\Q2\\20180408_122634_3.CR2{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2008\\Q2\\20080601_020200.nef"), $"\r\nMissing file \r\n\t\\2008\\Q2\\20080601_020200.nef{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2008\\Q2\\20080601_020200_2.nef"), $"\r\nMissing file \r\n\t\\2008\\Q2\\20080601_020200_2.nef{filesInFolders}");
//////            Assert.IsTrue(filesProcessedContent.Contains($"{processedPath}\\2019\\Q2\\20190510_095011.JPG"), $"\r\nMissing file \r\n\t\\2019\\Q2\\20190510_095011.jpg{filesInFolders}");

//////            //Failed to process files
//////            Assert.IsTrue(filesSourceContent.Contains($"{originalPath}\\JPG\\Bad.jpg"), $"Missing file \r\n\\JPG\\Bad.jpg{filesInFolders}");
//////            /////////////////////////////////////////////////////
//////            //   Check empty directories have been removed
//////            /////////////////////////////////////////////////////

//////            var originalDirectories = Directory.EnumerateDirectories(originalPath, "*", SearchOption.AllDirectories).ToList();
//////            var directoriesInOriginalPath = $"\r\nOriginal path:\r\n\t{string.Join("\r\n\t", originalDirectories).Replace(originalPath, string.Empty)}";
//////            Assert.AreEqual(1, originalDirectories.Count(), $"{directoriesInOriginalPath}");
//////            Assert.IsTrue(originalDirectories.Contains($"{originalPath}\\JPG"), $"{directoriesInOriginalPath}");
//////        }
//////    }
//////}