using System;
using System.Collections.Generic;
using System.IO;
using ImageRename.Standard;
using ImageRename.Tests.Context;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace ImageRename.Tests.Steps
{
    [Binding]
    public class ImageGpsSteps : BaseSteps
    {
        public ImageGpsSteps(BaseContext context) : base(context)
        {
        }

        [Then(@"the following files have the values in the ImageFile object")]
        public void ThenTheFollowingFilesHaveTheValuesInTheImageObject(Table table)
        {
            var target = new ProcessFolder();
            var results = new List<Result1>();
            foreach (var row in table.Rows)
            {
                var path = Path.Combine(TestFileFolder, row["TestFolder"], row["TestFile"]);
                var actual = target.ProcessFile(path);
                results.Add(new Result1()
                {
                    TestFolder = row["TestFolder"],
                    TestFile = row["TestFile"],
                    Longitude = actual.GPS?.Longitude,
                    Latitude = actual.GPS?.Latitude,
                    ImageTaken = actual.ImageCreated?.ToString("dd MMM yyyy hh:mm:ss"),
                    ImageCreatedOriginal = actual.ImageCreatedOriginal?.ToString("dd MMM yyyy hh:mm:ss"),
                    GPSImageTaken = actual.GPS?.GpsDateTime?.ToString("dd MMM yyyy hh:mm:ss"),

                });
            }
            table.CompareToSet<Result1>(results);
        }

        private struct Result1
        {
            public string ImageTaken { get; internal set; }
            public string ImageCreatedOriginal { get; internal set; }
            public string GPSImageTaken { get; internal set; }
            public string Latitude { get; internal set; }
            public string Longitude { get; internal set; }
            public string TestFile { get; internal set; }
            public string TestFolder { get; internal set; }
        };
    }
}