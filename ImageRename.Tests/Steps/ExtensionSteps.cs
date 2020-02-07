using System.Collections.Generic;
using ImageRename.Tests.Context;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ImageRename.Standard;
namespace ImageRename.Tests.Steps
{
    public class CordinatesConversionModel
    {
        public string Coordinates { get; set; }
        public string Degrees { get; set; }
        public string KeyWords { get; set; }
    }

    [Binding]
    public class ExtensionSteps : BaseSteps
    {
        public ExtensionSteps(BaseContext context) : base(context)
        {
        }

        [Given(@"I test the coordinates")]
        public void GivenITestTheCoridantes(Table table)
        {
            var results = new List<CordinatesConversionModel>();
            foreach (var row in table.Rows)
            {
                results.Add(new CordinatesConversionModel()
                {
                    KeyWords = row["KeyWords"],
                    Degrees = row["Coordinates"].ToDegrees().ToString("N5"),
                    Coordinates = row["Coordinates"]
                });
            }
            table.CompareToSet(results);
        }
    }
}