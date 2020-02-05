using System.Collections.Generic;
using System.IO;
using ImageRename.Standard;
using ImageRename.Tests.Context;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ImageRename.Tests.Steps
{
    [Binding]
    public partial class ImageGpsSteps : BaseSteps
    {
        public ImageGpsSteps(BaseContext context) : base(context)
        {
        }

        [Then(@"the following files have the values in the ImageFile object")]
        public void ThenTheFollowingFilesHaveTheValuesInTheImageObject(Table table)
        {
            var target = new ProcessFolder();
            var results = new List<ImageResult>();
            foreach (var row in table.Rows)
            {
                var path = Path.Combine(TestFileFolder, row["TestFolder"], row["TestFile"]);
                var actual = target.ProcessFile(path);
                results.Add(new ImageResult()
                {
                    TestFolder = row["TestFolder"],
                    TestFile = row["TestFile"],
                    Longitude = actual.GPS?.Longitude,
                    Latitude = actual.GPS?.Latitude,
                    ImageTaken = actual.ImageCreated?.ToString("dd MMM yyyy hh:mm:ss"),
                    ImageCreatedOriginal = actual.ImageCreatedOriginal?.ToString("dd MMM yyyy hh:mm:ss"),
                    GPSImageTaken = actual.GPS?.GpsDateTime?.ToString("dd MMM yyyy hh:mm:ss"),
                    DestinationFileName = actual.DestinationFileName,
                    KeyWords = row["KeyWords"]
                });
            }
            table.CompareToSet<ImageResult>(results);
        }
    }
}