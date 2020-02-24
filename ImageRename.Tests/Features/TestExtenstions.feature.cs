// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.1.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ImageRename.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class TestExtenstionsFeature : object, Xunit.IClassFixture<TestExtenstionsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "TestExtenstions.feature"
#line hidden
        
        public TestExtenstionsFeature(TestExtenstionsFeature.FixtureData fixtureData, ImageRename_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "TestExtenstions", "\tTest the testing extentions", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 5
#line hidden
#line 6
testRunner.Given("I reset the TimeProvider", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
testRunner.And("I wait 2 second", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="StartOfWeek")]
        [Xunit.TraitAttribute("FeatureTitle", "TestExtenstions")]
        [Xunit.TraitAttribute("Description", "StartOfWeek")]
        public virtual void StartOfWeek()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("StartOfWeek", null, ((string[])(null)));
#line 9
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                            "TargetDate",
                            "DayOfWeek",
                            "Expected"});
                table33.AddRow(new string[] {
                            "25 Nov 2019",
                            "Monday",
                            "25 Nov 2019"});
                table33.AddRow(new string[] {
                            "25 Nov 2019",
                            "Tuesday",
                            "26 Nov 2019"});
                table33.AddRow(new string[] {
                            "25 Nov 2019",
                            "Wednesday",
                            "27 Nov 2019"});
                table33.AddRow(new string[] {
                            "25 Nov 2019",
                            "Thursday",
                            "28 Nov 2019"});
                table33.AddRow(new string[] {
                            "25 Nov 2019",
                            "Friday",
                            "29 Nov 2019"});
                table33.AddRow(new string[] {
                            "25 Nov 2019",
                            "Saturday",
                            "30 Nov 2019"});
                table33.AddRow(new string[] {
                            "25 Nov 2019",
                            "Sunday",
                            "01 Dec 2019"});
                table33.AddRow(new string[] {
                            "07 Mar 2016",
                            "Monday",
                            "07 Mar 2016"});
                table33.AddRow(new string[] {
                            "07 Mar 2016",
                            "Tuesday",
                            "08 Mar 2016"});
                table33.AddRow(new string[] {
                            "07 Mar 2016",
                            "Wednesday",
                            "09 Mar 2016"});
                table33.AddRow(new string[] {
                            "07 Mar 2016",
                            "Thursday",
                            "10 Mar 2016"});
                table33.AddRow(new string[] {
                            "07 Mar 2016",
                            "Friday",
                            "11 Mar 2016"});
                table33.AddRow(new string[] {
                            "07 Mar 2016",
                            "Saturday",
                            "12 Mar 2016"});
                table33.AddRow(new string[] {
                            "07 Mar 2016",
                            "Sunday",
                            "13 Mar 2016"});
                table33.AddRow(new string[] {
                            "01 Mar 2012",
                            "Monday",
                            "27 Feb 2012"});
                table33.AddRow(new string[] {
                            "01 Mar 2012",
                            "Tuesday",
                            "28 Feb 2012"});
                table33.AddRow(new string[] {
                            "01 Mar 2012",
                            "Wednesday",
                            "29 Feb 2012"});
                table33.AddRow(new string[] {
                            "01 Mar 2012",
                            "Thursday",
                            "01 Mar 2012"});
                table33.AddRow(new string[] {
                            "01 Mar 2012",
                            "Friday",
                            "02 Mar 2012"});
                table33.AddRow(new string[] {
                            "01 Mar 2012",
                            "Saturday",
                            "03 Mar 2012"});
                table33.AddRow(new string[] {
                            "01 Mar 2012",
                            "Sunday",
                            "04 Mar 2012"});
#line 10
testRunner.Given("I Test Extention Method StartOfWeek with the following values", ((string)(null)), table33, "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="GetDayInWeek1")]
        [Xunit.TraitAttribute("FeatureTitle", "TestExtenstions")]
        [Xunit.TraitAttribute("Description", "GetDayInWeek1")]
        public virtual void GetDayInWeek1()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetDayInWeek1", null, ((string[])(null)));
#line 35
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 36
testRunner.Given("I set the TimeProvider date to \'6 Nov 2019 13:34:56\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 37
testRunner.And("I wait 2 second", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                            "Value",
                            "Expected"});
                table34.AddRow(new string[] {
                            "Monday",
                            "4 Nov 2019"});
                table34.AddRow(new string[] {
                            "Tuesday",
                            "5 Nov 2019"});
                table34.AddRow(new string[] {
                            "Wednesday",
                            "6 Nov 2019"});
                table34.AddRow(new string[] {
                            "Thursday",
                            "7 Nov 2019"});
                table34.AddRow(new string[] {
                            "Friday",
                            "8 Nov 2019"});
                table34.AddRow(new string[] {
                            "Saturday",
                            "9 Nov 2019"});
                table34.AddRow(new string[] {
                            "Sunday",
                            "10 Nov 2019"});
#line 38
testRunner.Then("I check extension method GetDayInWeek returns the following", ((string)(null)), table34, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="GetDayInWeek2")]
        [Xunit.TraitAttribute("FeatureTitle", "TestExtenstions")]
        [Xunit.TraitAttribute("Description", "GetDayInWeek2")]
        public virtual void GetDayInWeek2()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetDayInWeek2", null, ((string[])(null)));
#line 49
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 50
testRunner.Given("I set the TimeProvider date to \'1 Mar 2012 13:34:56\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 51
testRunner.And("I wait 2 second", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                            "Value",
                            "Expected"});
                table35.AddRow(new string[] {
                            "Monday",
                            "27 Feb 2012"});
                table35.AddRow(new string[] {
                            "Tuesday",
                            "28 Feb 2012"});
                table35.AddRow(new string[] {
                            "Wednesday",
                            "29 Feb 2012"});
                table35.AddRow(new string[] {
                            "Thursday",
                            "1 Mar 2012"});
                table35.AddRow(new string[] {
                            "Friday",
                            "2 Mar 2012"});
                table35.AddRow(new string[] {
                            "Saturday",
                            "3 Mar 2012"});
                table35.AddRow(new string[] {
                            "Sunday",
                            "4 Mar 2012"});
#line 52
testRunner.Then("I check extension method GetDayInWeek returns the following", ((string)(null)), table35, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="GetFirstDayOfWeek")]
        [Xunit.TraitAttribute("FeatureTitle", "TestExtenstions")]
        [Xunit.TraitAttribute("Description", "GetFirstDayOfWeek")]
        public virtual void GetFirstDayOfWeek()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("GetFirstDayOfWeek", null, ((string[])(null)));
#line 63
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
#line 64
testRunner.Given("I set the TimeProvider date to \'29 Feb 2012 13:34:56\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 65
testRunner.And("I wait 2 second", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                            "Value",
                            "Expected"});
                table36.AddRow(new string[] {
                            "1 Mar 2012",
                            "27 Feb 2012"});
                table36.AddRow(new string[] {
                            "2 Mar 2012",
                            "27 Feb 2012"});
                table36.AddRow(new string[] {
                            "3 Mar 2012",
                            "27 Feb 2012"});
                table36.AddRow(new string[] {
                            "4 Mar 2012",
                            "27 Feb 2012"});
                table36.AddRow(new string[] {
                            "27 Feb 2012",
                            "27 Feb 2012"});
                table36.AddRow(new string[] {
                            "28 Feb 2012",
                            "27 Feb 2012"});
                table36.AddRow(new string[] {
                            "29 Feb 2012",
                            "27 Feb 2012"});
#line 66
testRunner.Given("I check the date time extenstion GetFirstDayOfWeek", ((string)(null)), table36, "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="ToGpsSector")]
        [Xunit.TraitAttribute("FeatureTitle", "TestExtenstions")]
        [Xunit.TraitAttribute("Description", "ToGpsSector")]
        public virtual void ToGpsSector()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ToGpsSector", null, ((string[])(null)));
#line 76
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                            "Value",
                            "Expected"});
                table37.AddRow(new string[] {
                            "5.00°21.04\'0.00\" N",
                            "N"});
                table37.AddRow(new string[] {
                            "5.00°21.04\'0.00\" E",
                            "E"});
                table37.AddRow(new string[] {
                            "5.00°21.04\'0.00\" S",
                            "S"});
                table37.AddRow(new string[] {
                            "5.00°21.04\'0.00\" W",
                            "W"});
                table37.AddRow(new string[] {
                            "5.00°21.04\'0.00\" X",
                            ""});
                table37.AddRow(new string[] {
                            "",
                            ""});
#line 77
testRunner.Given("I check ToGpsSector", ((string)(null)), table37, "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="ToGpsDegrees")]
        [Xunit.TraitAttribute("FeatureTitle", "TestExtenstions")]
        [Xunit.TraitAttribute("Description", "ToGpsDegrees")]
        public virtual void ToGpsDegrees()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ToGpsDegrees", null, ((string[])(null)));
#line 87
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
                            "Value",
                            "Expected"});
                table38.AddRow(new string[] {
                            "5.11°21.12\'1.45\" N",
                            "5.11"});
                table38.AddRow(new string[] {
                            "5.22°21.22\'2.56\" E",
                            "5.22"});
                table38.AddRow(new string[] {
                            "5.33°21.23\'3.78\" S",
                            "5.33"});
                table38.AddRow(new string[] {
                            "5.44°21.34\'4.12\" W",
                            "5.44"});
                table38.AddRow(new string[] {
                            "5.55°21.56\'5.34\" X",
                            "5.55"});
#line 88
testRunner.Given("I check ToGpsDegrees", ((string)(null)), table38, "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="ToGpsMinutes")]
        [Xunit.TraitAttribute("FeatureTitle", "TestExtenstions")]
        [Xunit.TraitAttribute("Description", "ToGpsMinutes")]
        public virtual void ToGpsMinutes()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ToGpsMinutes", null, ((string[])(null)));
#line 98
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                            "Value",
                            "Expected"});
                table39.AddRow(new string[] {
                            "5.11°21.11\'1.45\" N",
                            "21.11"});
                table39.AddRow(new string[] {
                            "5.22°21.22\'2.56\" E",
                            "21.22"});
                table39.AddRow(new string[] {
                            "5.33°21.33\'3.78\" S",
                            "21.33"});
                table39.AddRow(new string[] {
                            "5.44°21.44\'4.12\" W",
                            "21.44"});
                table39.AddRow(new string[] {
                            "5.55°21.55\'5.34\" X",
                            "21.55"});
                table39.AddRow(new string[] {
                            "5.55°21.666\'5.34\" X",
                            "21.666"});
#line 99
testRunner.Given("I check ToGpsMinutes", ((string)(null)), table39, "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="ToGpsSeconds")]
        [Xunit.TraitAttribute("FeatureTitle", "TestExtenstions")]
        [Xunit.TraitAttribute("Description", "ToGpsSeconds")]
        public virtual void ToGpsSeconds()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ToGpsSeconds", null, ((string[])(null)));
#line 110
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 5
this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                            "Value",
                            "Expected"});
                table40.AddRow(new string[] {
                            "5.11°21.12\'1.45\" N",
                            "1.45"});
                table40.AddRow(new string[] {
                            "5.22°21.22\'2.56\" E",
                            "2.56"});
                table40.AddRow(new string[] {
                            "5.33°21.23\'3.78\" S",
                            "3.78"});
                table40.AddRow(new string[] {
                            "5.44°21.34\'4.12\" W",
                            "4.12"});
                table40.AddRow(new string[] {
                            "5.55°21.56\'5.34\" X",
                            "5.34"});
#line 111
testRunner.Given("I check ToGpsSeconds", ((string)(null)), table40, "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.1.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                TestExtenstionsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                TestExtenstionsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
