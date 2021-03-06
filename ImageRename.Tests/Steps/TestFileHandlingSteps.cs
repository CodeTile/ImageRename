﻿using System.IO;
using ImageRename.Tests.Context;
using TechTalk.SpecFlow;

namespace ImageRename.Tests.Steps
{
    [Binding]
    public class TestFileHandlingSteps : BaseSteps
    {
        public TestFileHandlingSteps(BaseContext context) : base(context)
        {
        }

        [Given(@"I add the keywords to the files")]
        public void GivenIAddTheKeywordsToTheFiles(Table table)
        {
            foreach (var row in table.Rows)
            {
                Helper.WriteKeywords(row["Filename"], row["Keywords"]);
            }
        }

        [Given(@"I copy the following files")]
        public void GivenICopyTheFollowingFiles(Table table)
        {
            foreach (var row in table.Rows)
            {
                var sourceFile = Path.Combine(OriginalFolder, row["SourceFolder"], row["SourceFile"]);
                var destinationFile = Path.Combine(TestFileFolder, row["DestinationFolder"], row["DestinationFile"]);

                Helper.CopyTestFileTo(sourceFile, destinationFile);
            }
            // let the file system catch up
            System.Threading.Thread.Sleep(543);
        }

        [Given(@"I copy the following files in the folder '(.*)'")]
        public void GivenICopyTheFollowingFilesInTheFolder(string folder, Table table)
        {
            foreach (var row in table.Rows)
            {
                var sourceFile = Path.Combine(TestFileFolder, folder, row["SourceFolder"], row["SourceFile"]);
                var destinationFile = Path.Combine(TestFileFolder, folder, row["DestinationFolder"], row["DestinationFile"]);

                Helper.CopyTestFileTo(sourceFile, destinationFile);
            }
            //Let the filesystem catchup
            Wait(345);
        }

        [Given(@"I create a copy of all test files into the folder '(.*)'")]
        public void GivenICreateACopyOfAllTestFilesInTheFolder(string destinationFolder)
        {
            var destinationPath = Path.Combine(TestFileFolder, destinationFolder);
            Helper.DirectoryCopy(Helper.TestFilesSourceFolder, destinationPath);
            //Helper.CopyTestFilesTo(destinationPath);
            // let the file system catch up
            System.Threading.Thread.Sleep(543);
        }

        [Given(@"I delete the folders")]
        public void GivenIDeleteTheFolders(Table table)
        {
            foreach (var row in table.Rows)
            {
                var path = Path.Combine(TestFileFolder, row["Path"]);
                Helper.DeleteDirectory(path);
            }
        }

        [Given(@"in the folder '(.*)' I delete the files")]
        public void GivenInTheFolderIDeleteTheFiles(string rootPath, Table table)
        {
            foreach (var row in table.Rows)
            {
                var path = Path.Combine(TestFileFolder, rootPath, row["Path"]);
                Helper.DeleteFile(path);
            }
        }
    }
}