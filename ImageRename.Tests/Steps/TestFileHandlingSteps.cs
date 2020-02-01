using System;
using System.Collections.Generic;
using System.IO;
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
        [Given(@"I clear the testfiles folder")]
        public void GivenIClearTheTestfilesFolder()
        {
            Helper.DeleteDirectory(TestFileFolder);
            // let the file system catch up
            System.Threading.Thread.Sleep(543);
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
        }
    }
}
