using System;
using System.Collections.Generic;
using System.IO;
using ImageRename.Standard;
using ImageRename.Standard.Model;
using ImageRename.Tests.Context;
using ImageRename.Tests.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace ImageRename.Tests.Steps
{

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
            var row = table.Rows[0];
            var target = new ProcessFolder(Helper.GetConfiguration())
            {
                DebugDontRenameFile = Convert.ToBoolean(row["DebugDontRenameFile"]),
            };
            var parameters = new ProcessParameters()
            {
                SortByYear = Convert.ToBoolean(row["MoveToProcessedByYear"]),
                SourcePath= Path.Combine(TestFileFolder, foldername),
            ProcessedPath = string.IsNullOrEmpty(row["ProcessedPath"]) ? null : Path.Combine(TestFileFolder, row["ProcessedPath"])
            };
            target.Process(parameters);
            Wait(640);
        }

        [Then(@"the folder '(.*)' with subfolders contains")]
        [Given(@"the folder '(.*)' with subfolders contains")]
        public void GivenTheFolderWithSubfoldersContains(string path, Table table)
        {
            Wait(124);
            var fullPath = Path.Combine(TestFileFolder, path);
            var actual = Directory.GetFiles(fullPath, "*.*", SearchOption.AllDirectories);
            ComparePaths(table, fullPath, actual);
        }

        private static void ComparePaths(Table table, string fullPath, string[] actual)
        {
            var paths = new List<PathResult>();
            foreach (var item in actual)
            {
                paths.Add(new PathResult() { Path = item.Replace(fullPath, string.Empty) });
            }

            table.CompareToSet(paths);
        }

        [Then(@"the folder '(.*)' has subfolders")]
        public void ThenTheFolderHasSubfolder(string path, Table table)
        {
            var fullPath = Path.Combine(TestFileFolder, path);
            var actual = Directory.GetDirectories(fullPath, "*.*", SearchOption.AllDirectories);

            ComparePaths(table, fullPath, actual);
        }

        [Then(@"there are no subfolders in '(.*)'")]
        public void ThenThereAreNoSubfoldersIn(string folder)
        {
            var fullPath = Path.Combine(TestFileFolder, folder);
            var actual = Directory.GetDirectories(fullPath).Length;
            Assert.Equal(0, actual);
        }
    }
}