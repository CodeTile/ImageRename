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
    public partial class TestHelperFeature : object, Xunit.IClassFixture<TestHelperFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "TestHelper.feature"
#line hidden
        
        public TestHelperFeature(TestHelperFeature.FixtureData fixtureData, ImageRename_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "TestHelper", "\tTest the TestHelper methods", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="TestHelper.convertToDateTime1")]
        [Xunit.TraitAttribute("FeatureTitle", "TestHelper")]
        [Xunit.TraitAttribute("Description", "TestHelper.convertToDateTime1")]
        public virtual void TestHelper_ConvertToDateTime1()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TestHelper.convertToDateTime1", null, ((string[])(null)));
#line 4
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
 testRunner.Given("I reset the TimeProvider", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
                            "Value",
                            "Result",
                            "IncludeTime",
                            "CurrentDate"});
                table41.AddRow(new string[] {
                            "1 Feb 2000",
                            "1 Feb 2000",
                            "false",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "December 1 2222",
                            "1 Dec 2222",
                            "false",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "1 Feb 2000 13:34:43",
                            "1 Feb 2000 13:34:43",
                            "true",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "December 1 2222 09:23:48",
                            "1 Dec 2222 09:23:48",
                            "true",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "<<now>>",
                            "6 Nov 2019 13:34:56",
                            "true",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "<<today>>",
                            "6 Nov 2019",
                            "false",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "<<yesterday>>",
                            "5 Nov 2019",
                            "false",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "<<yearstart>>",
                            "1 Jan 2019",
                            "false",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "<<monthstart>>",
                            "1 Nov 2019",
                            "false",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "<<mondaylastweek>>",
                            "28 Oct 2019",
                            "false",
                            "6 Nov 2019 13:34:56"});
                table41.AddRow(new string[] {
                            "<<fridaylastweek>>",
                            "1 Nov 2019",
                            "false",
                            "6 Nov 2019 13:34:56"});
#line 6
 testRunner.And("I TestHelper function convertToDateTime with the following", ((string)(null)), table41, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="TestHelper.convertToDateTime2")]
        [Xunit.TraitAttribute("FeatureTitle", "TestHelper")]
        [Xunit.TraitAttribute("Description", "TestHelper.convertToDateTime2")]
        public virtual void TestHelper_ConvertToDateTime2()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("TestHelper.convertToDateTime2", null, ((string[])(null)));
#line 20
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
#line 21
 testRunner.Given("I reset the TimeProvider", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
                            "Value",
                            "Result",
                            "IncludeTime",
                            "CurrentDate"});
                table42.AddRow(new string[] {
                            "1 Feb 2000",
                            "1 Feb 2000",
                            "false",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "December 1 2222",
                            "1 Dec 2222",
                            "false",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "1 Feb 2000 13:34:43",
                            "1 Feb 2000 13:34:43",
                            "true",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "December 1 2222 09:23:48",
                            "1 Dec 2222 09:23:48",
                            "true",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "<<now>>",
                            "4 Feb 2020 23:14:59",
                            "true",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "<<today>>",
                            "4 Feb 2020",
                            "false",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "<<yesterday>>",
                            "3 Feb 2020",
                            "false",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "<<yearstart>>",
                            "1 Jan 2020",
                            "false",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "<<monthstart>>",
                            "1 Feb 2020",
                            "false",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "<<mondaylastweek>>",
                            "27 Jan 2020",
                            "false",
                            "4 Feb 2020 23:14:59"});
                table42.AddRow(new string[] {
                            "<<fridaylastweek>>",
                            "31 Jan 2020",
                            "false",
                            "4 Feb 2020 23:14:59"});
#line 22
 testRunner.And("I TestHelper function convertToDateTime with the following", ((string)(null)), table42, "And ");
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
                TestHelperFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                TestHelperFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
