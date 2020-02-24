using ImageRename.Standard;
using ImageRename.Standard.Model;
using ImageRename.Tests.Context;
using System;
using System.Collections.Generic;
using System.IO;
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
            var target = new ProcessFolder(Configuration);
            var images = new List<ImageDetails>();
            foreach (var row in table.Rows)
            {
                target.HasInternet = Convert.ToBoolean(row["HasInternet"]);
                var image = new ImageDetails(Path.Combine("<<DEBUG>>", row["TestFile"]))
                {
                    OriginalKeywords = row["Keywords"],
                    KeyWords = row["Keywords"],
                    ImageCreatedOriginal = Convert.ToDateTime(row["ImageCreatedOriginal"]),
                    ImageCreated = Convert.ToDateTime(row["ImageTaken"]),
                    HasInternet = target.HasInternet
                };
                if (!string.IsNullOrEmpty(row["Latitude"]))
                {
                    image.GPS = new GPSCoridates()
                    {
                        GpsDateTime = Convert.ToDateTime(row["GPSImageTaken"]),
                        Latitude = row["Latitude"],
                        Longitude = row["Longitude"]
                    };
                }

                target.ReverseGeocode(image);
                images.Add(image);
            }
            Context.SUT = images;
        }

        [Then(@"the following files have the values in the ImageFile object")]
        public void ThenTheFollowingFilesHaveTheValuesInTheImageObject(Table table)
        {
            string path="";
            try
            {
                var target = new ProcessFolder(base.Configuration);
                var results = new List<ImageResult>();
                foreach (var row in table.Rows)
                {
                     path = Path.Combine(TestFileFolder, row["TestFolder"], row["TestFile"]);
                    target.HasInternet = Convert.ToBoolean(row["HasInternet"]);
                    var actual = target.ProcessFile(path);
                    results.Add(new ImageResult()
                    {
                        DegreesLatitude = actual.GPS?.DegreesLatitude,
                        DegreesLongitude = actual.GPS?.DegreesLongitude,
                        DestinationFileName = actual.DestinationFileName,
                        GPSImageTaken = actual.GPS?.GpsDateTime?.ToString("dd MMM yyyy HH:mm:ss"),
                        HasInternet = actual.HasInternet,
                        HasNewKeywords = actual.HasNewKeywords,
                        ImageCreatedOriginal = actual.ImageCreatedOriginal?.ToString("dd MMM yyyy HH:mm:ss"),
                        ImageTaken = actual.ImageCreated?.ToString("dd MMM yyyy HH:mm:ss"),
                        KeyWords = actual.KeyWords,
                        Latitude = actual.GPS?.Latitude,
                        Longitude = actual.GPS?.Longitude,
                        NeedsRenaming = actual.NeedsRenaming,
                        OriginalKeywords = actual.OriginalKeywords,
                        TestFile = row["TestFile"],
                        TestFolder = row["TestFolder"]
                    }); ;
                }
                table.CompareToSet<ImageResult>(results);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}\r\n\t{path}");
                throw;
            }
        }

        [Then(@"the image object list has following values")]
        public void ThenTheImageObjectListHasFollowingValues(Table table)
        {
            var images = (IEnumerable<IImageDetails>)Context.SUT;
            var results = new List<ImageResult>();

            foreach (var image in images)
            {
                results.Add(new ImageResult()
                {
                    DegreesLatitude = image.GPS?.DegreesLatitude,
                    DegreesLongitude = image.GPS?.DegreesLongitude,
                    DestinationFileName = image.DestinationFileName,
                    GPSImageTaken = image.GPS?.GpsDateTime?.ToString("dd MMM yyyy HH:mm:ss"),
                    HasNewKeywords = image.HasNewKeywords,
                    ImageCreatedOriginal = image.ImageCreatedOriginal?.ToString("dd MMM yyyy HH:mm:ss"),
                    ImageTaken = image.ImageCreated?.ToString("dd MMM yyyy HH:mm:ss"),
                    KeyWords = image.KeyWords,
                    Latitude = image.GPS?.Latitude,
                    Longitude = image.GPS?.Longitude,
                    NeedsRenaming = image.NeedsRenaming,
                    OriginalKeywords = image.OriginalKeywords,
                    TestFile = image.SourceFileInfo.Name
                    
                    
                });
            }

            table.CompareToSet(results);
        }
    }
}