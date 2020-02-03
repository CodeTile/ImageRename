using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageRename.Standard;
using ImageRename.Tests.Context;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;
namespace ImageRename.Tests.Steps
{
    internal struct PathResult
    {
        public string Path { get; set; }
    }
    [Binding]
    public class ProcessFolderSteps : BaseSteps
    {
        public ProcessFolderSteps(BaseContext context) : base(context)
        {
        }

        [Given(@"I process the folder '(.*)' with the following flags")]
        public void GivenIProcessTheFolderWithTheFollowingFlags(string foldername, Table table)
        {
            string[] filesOriginal = null;
            string[] filesProcessedContent = null;
            var originalPath = Path.Combine(Helper.TestFilesFolder, foldername);
            var filesInFolders = GetFilesList("Orignal contents", originalPath, ref filesOriginal);

            var row = table.Rows[0];
            var target = new ProcessFolder()
            {
                DebugDontRenameFile = Convert.ToBoolean(row["DebugDontRenameFile"]),
                MoveToProcessedByYear = Convert.ToBoolean(row["MoveToProcessedByYear"]),
                ProcessedPath = string.IsNullOrEmpty(row["ProcessedPath"]) ? null : row["ProcessedPath"]
            };
            target.Process(originalPath);
            filesInFolders += GetFilesList("Processed", originalPath, ref filesProcessedContent);

            Assert.Equal(10, filesProcessedContent.Length);
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\CR2\\20180408_072740.CR2"), $"\r\nMissing file \r\n\t\\CR2\\20180408_072740.CR2{filesInFolders}");
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\CR2\\20180408_122634.CR2"), $"\r\nMissing file \r\n\t\\CR2\\20180408_122634.CR2{filesInFolders}");
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\JPG\\20180310_115353.jpg"), $"\r\nMissing file \r\n\t\\JPG\\20180310_115353.jpg{filesInFolders}");
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\JPG\\Bad.jpg"), $"\r\nMissing file \r\n\t\\JPG\\Bad.jpg{filesInFolders}");
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\JPG\\20190510_095011.JPG"), $"\r\nMissing file \r\n\t\\JPG\\20190510_095011.jpg{filesInFolders}");
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\mov\\20151129_093543.MOV"), $"\r\nMissing file \r\n\t\\mov\\20151129_093543.MOV{filesInFolders}");
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\mov\\20160124_141020.MOV"), $"\r\nMissing file \r\n\t\\mov\\20160124_141020.MOV{filesInFolders}");
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\mov\\20160124_141023.MOV"), $"\r\nMissing file \r\n\t\\mov\\20160124_141023.MOV{filesInFolders}");
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\NEF\\20080601_020200.nef"), $"\r\nMissing file \r\n\t\\NEF\\20080601_020200.nef{filesInFolders}");
            //Assert.True(filesProcessedContent.Contains($"{originalPath}\\NEF\\20080601_020200_2.nef"), $"\r\nMissing file \r\n\t\\NEF\\20080601_020200_2.nef{filesInFolders}");

        }

        [Given(@"the folder '(.*)' with subfolders contains")]
        public void GivenTheFolderWithSubfoldersContains(string path, Table table)
        {
            var fullPath = Path.Combine(Helper.TestFilesFolder, path);
            var actual = Directory.GetFiles(fullPath, "*.*", SearchOption.AllDirectories);
            var paths = new List<PathResult>();
            foreach (var item in actual)
            {
                paths.Add(new PathResult() {Path= item.Replace(fullPath,string.Empty) });
            }

            table.CompareToSet(paths);
        }
       
    }
}