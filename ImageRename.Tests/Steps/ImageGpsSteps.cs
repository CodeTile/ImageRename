using System;
using System.Collections.Generic;
using System.IO;
using ImageRename.Standard;
using ImageRename.Standard.Model;
using ImageRename.Tests.Context;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ImageRename.Tests.Steps
{
    [Binding]
    public class ImageGpsSteps : BaseSteps
    {
        public ImageGpsSteps(BaseContext context) : base(context)
        {
        }

        [Given(@"I create image objects with the following properties")]
        public void GivenICreateImageObjectsWithTheFollowingProperties(Table table)
        {
           var target = new ProcessFolder(Helper.GetConfiguration());
            var images = new List<ImageFile>();
            foreach (var row in table.Rows)
            {
                var image = new ImageFile(Path.Combine("<<DEBUG>>",row["TestFile"]));
                if (!string.IsNullOrEmpty(row["Latitude"]))
                {
                    image.GPS = new GPSCoridates()
                    {
                        GpsDateTime = Convert.ToDateTime(row["GPSImageTaken"]),
                        Latitude = row["Latitude"],
                        Longitude = row["Longitude"]
                    };
                }

                image.KeyWords= row["Keywords"];
                image.ImageCreatedOriginal = Convert.ToDateTime(row["ImageCreatedOriginal"]);
                image.ImageCreated = Convert.ToDateTime(row["ImageCreatedOriginal"]);
                image.KeyWords=row["Keywords"];
                target.ReverseGeocode(image);
                images.Add(image);
            }
            Context.SUT = images;
        }

        [Then(@"the following files have the values in the ImageFile object")]
        public void ThenTheFollowingFilesHaveTheValuesInTheImageObject(Table table)
        {
            var target = new ProcessFolder(Helper.GetConfiguration());
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
                    KeyWords = actual.KeyWords,
                    DegreesLongitude = actual.GPS?.DegreesLongitude,
                    DegreesLatitude = actual.GPS?.DegreesLatitude
                });
            }
            table.CompareToSet<ImageResult>(results);
        }

        [Then(@"the image object list has following values")]
        public void ThenTheImageObjectListHasFollowingValues(Table table)
        {

            var images = (IEnumerable<IImageFile>)Context.SUT;
            var results = new List<ImageResult>();
           

            foreach (var image in images)
            {
                results.Add(new ImageResult()
                {
                    TestFile =image.SourceFileInfo.Name,
                    Longitude = image.GPS?.Longitude,
                    Latitude = image.GPS?.Latitude,
                    ImageTaken = image.ImageCreated?.ToString("dd MMM yyyy hh:mm:ss"),
                    ImageCreatedOriginal = image.ImageCreatedOriginal?.ToString("dd MMM yyyy hh:mm:ss"),
                    GPSImageTaken = image.GPS?.GpsDateTime?.ToString("dd MMM yyyy hh:mm:ss"),
                    DestinationFileName = image.DestinationFileName,
                    KeyWords = image.KeyWords,
                    DegreesLongitude = image.GPS?.DegreesLongitude,
                    DegreesLatitude = image.GPS?.DegreesLatitude
                });
            }


            table.CompareToSet(results);
        }
    }
}