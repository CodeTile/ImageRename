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

        [When(@"I process the folder '(.*)' with the following flags")]
        [Given(@"I process the folder '(.*)' with the following flags")]
        public void GivenIProcessTheFolderWithTheFollowingFlags(string foldername, Table table)
        {
          
            var originalPath = Path.Combine(Helper.TestFilesFolder, foldername);

            var row = table.Rows[0];
            var target = new ProcessFolder()
            {
                DebugDontRenameFile = Convert.ToBoolean(row["DebugDontRenameFile"]),
                MoveToProcessedByYear = Convert.ToBoolean(row["MoveToProcessedByYear"]),
                ProcessedPath = string.IsNullOrEmpty(row["ProcessedPath"]) ? null : row["ProcessedPath"]
            };
            target.Process(originalPath);
            Wait(562);
        }

        [Then(@"the folder '(.*)' with subfolders contains")]
        [Given(@"the folder '(.*)' with subfolders contains")]
        public void GivenTheFolderWithSubfoldersContains(string path, Table table)
        {
            Wait(327);
            var fullPath = Path.Combine(Helper.TestFilesFolder, path);
            var actual = Directory.GetFiles(fullPath, "*.*", SearchOption.AllDirectories);
            var paths = new List<PathResult>();
            foreach (var item in actual)
            {
                paths.Add(new PathResult() { Path = item.Replace(fullPath, string.Empty) });
            }

            table.CompareToSet(paths);
        }
    }
    


}