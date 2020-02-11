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
    public partial class ProcessFolderFeature : object, Xunit.IClassFixture<ProcessFolderFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "ProcessFolder.feature"
#line hidden
        
        public ProcessFolderFeature(ProcessFolderFeature.FixtureData fixtureData, ImageRename_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "ProcessFolder", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 4
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Path"});
            table7.AddRow(new string[] {
                        "ProcessFolderDontMoveTest"});
            table7.AddRow(new string[] {
                        "ProcessFolderMoveTest"});
            table7.AddRow(new string[] {
                        "ProcessFolderMoveTestProcessed"});
            table7.AddRow(new string[] {
                        "ProcessFolderMoveTest2"});
            table7.AddRow(new string[] {
                        "ProcessFolderMoveTest2Processed"});
            table7.AddRow(new string[] {
                        "DuplicateTimeStampDontMove"});
            table7.AddRow(new string[] {
                        "DuplicateTimeStampMove"});
            table7.AddRow(new string[] {
                        "DuplicateTimeStampMoveProcessed"});
            table7.AddRow(new string[] {
                        "DuplicateTimeStampMoveWithExistingFiles"});
            table7.AddRow(new string[] {
                        "DuplicateTimeStampMoveWithExistingFilesProcessed"});
#line 5
 testRunner.Given("I delete the folders", ((string)(null)), table7, "Given ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="DontMoveTest")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "DontMoveTest")]
        public virtual void DontMoveTest()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DontMoveTest", null, ((string[])(null)));
#line 18
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
#line 4
this.FeatureBackground();
#line hidden
#line 19
 testRunner.Given("I create a copy of all test files into the folder \'ProcessFolderDontMoveTest\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table8.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table8.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table8.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table8.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table8.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table8.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table8.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table8.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table8.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table8.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
#line 20
 testRunner.And("the folder \'ProcessFolderDontMoveTest\' with subfolders contains", ((string)(null)), table8, "And ");
#line hidden
                TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table9.AddRow(new string[] {
                            "false",
                            "false",
                            ""});
#line 33
 testRunner.When("I process the folder \'ProcessFolderDontMoveTest\' with the following flags", ((string)(null)), table9, "When ");
#line hidden
                TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table10.AddRow(new string[] {
                            "\\CR2\\20180408_072740.CR2"});
                table10.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table10.AddRow(new string[] {
                            "\\JPG\\20180310_115353.jpg"});
                table10.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table10.AddRow(new string[] {
                            "\\JPG\\20200127_115041.jpg"});
                table10.AddRow(new string[] {
                            "\\mov\\20151129_093543.MOV"});
                table10.AddRow(new string[] {
                            "\\mov\\20160124_141020.MOV"});
                table10.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table10.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table10.AddRow(new string[] {
                            "\\NEF\\20080601_020200_2.nef"});
#line 37
 testRunner.Then("the folder \'ProcessFolderDontMoveTest\' with subfolders contains", ((string)(null)), table10, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="MoveTest1")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "MoveTest1")]
        public virtual void MoveTest1()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MoveTest1", null, ((string[])(null)));
#line 50
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
#line 4
this.FeatureBackground();
#line hidden
#line 51
 testRunner.Given("I create a copy of all test files into the folder \'ProcessFolderMoveTest\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table11.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table11.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table11.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table11.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table11.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table11.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table11.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table11.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table11.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table11.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
#line 52
 testRunner.And("the folder \'ProcessFolderMoveTest\' with subfolders contains", ((string)(null)), table11, "And ");
#line hidden
                TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table12.AddRow(new string[] {
                            "false",
                            "true",
                            "ProcessFolderMoveTestProcessed"});
#line 65
 testRunner.When("I process the folder \'ProcessFolderMoveTest\' with the following flags", ((string)(null)), table12, "When ");
#line hidden
                TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table13.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200.nef"});
                table13.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200_2.nef"});
                table13.AddRow(new string[] {
                            "\\2015\\Q4\\20151129_093543.MOV"});
                table13.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141020.MOV"});
                table13.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141023.MOV"});
                table13.AddRow(new string[] {
                            "\\2018\\Q1\\20180310_115353.jpg"});
                table13.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_072740.CR2"});
                table13.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634.CR2"});
                table13.AddRow(new string[] {
                            "\\2020\\Q1\\20200127_115041.jpg"});
#line 69
 testRunner.Then("the folder \'ProcessFolderMoveTestProcessed\' with subfolders contains", ((string)(null)), table13, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table14.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
#line 80
 testRunner.And("the folder \'ProcessFolderMoveTest\' with subfolders contains", ((string)(null)), table14, "And ");
#line hidden
                TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table15.AddRow(new string[] {
                            "\\JPG"});
#line 83
 testRunner.And("the folder \'ProcessFolderMoveTest\' has subfolders", ((string)(null)), table15, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="MoveTest2")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "MoveTest2")]
        public virtual void MoveTest2()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("MoveTest2", null, ((string[])(null)));
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
#line 4
this.FeatureBackground();
#line hidden
#line 88
 testRunner.Given("I create a copy of all test files into the folder \'ProcessFolderMoveTest2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table16.AddRow(new string[] {
                            "JPG\\Bad.jpg"});
#line 89
 testRunner.And("in the folder \'ProcessFolderMoveTest2\' I delete the files", ((string)(null)), table16, "And ");
#line hidden
                TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table17.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table17.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table17.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table17.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table17.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table17.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table17.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table17.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table17.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
#line 92
 testRunner.And("the folder \'ProcessFolderMoveTest2\' with subfolders contains", ((string)(null)), table17, "And ");
#line hidden
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table18.AddRow(new string[] {
                            "false",
                            "true",
                            "ProcessFolderMoveTest2Processed"});
#line 104
 testRunner.When("I process the folder \'ProcessFolderMoveTest2\' with the following flags", ((string)(null)), table18, "When ");
#line hidden
                TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table19.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200.nef"});
                table19.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200_2.nef"});
                table19.AddRow(new string[] {
                            "\\2015\\Q4\\20151129_093543.MOV"});
                table19.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141020.MOV"});
                table19.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141023.MOV"});
                table19.AddRow(new string[] {
                            "\\2018\\Q1\\20180310_115353.jpg"});
                table19.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_072740.CR2"});
                table19.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634.CR2"});
                table19.AddRow(new string[] {
                            "\\2020\\Q1\\20200127_115041.jpg"});
#line 108
 testRunner.Then("the folder \'ProcessFolderMoveTest2Processed\' with subfolders contains", ((string)(null)), table19, "Then ");
#line hidden
#line 119
 testRunner.And("there are no subfolders in \'ProcessFolderMoveTest2\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="DuplicateTimeStampDontMove")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "DuplicateTimeStampDontMove")]
        public virtual void DuplicateTimeStampDontMove()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DuplicateTimeStampDontMove", null, ((string[])(null)));
#line 121
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
#line 4
this.FeatureBackground();
#line hidden
#line 122
 testRunner.Given("I create a copy of all test files into the folder \'DuplicateTimeStampDontMove\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                            "SourceFolder",
                            "SourceFile",
                            "DestinationFolder",
                            "DestinationFile"});
                table20.AddRow(new string[] {
                            "CR2",
                            "good.cr2",
                            "cr2",
                            "Duplicate.cr2"});
                table20.AddRow(new string[] {
                            "jpg",
                            "good.jpg",
                            "jpg",
                            "duplicate.jpg"});
                table20.AddRow(new string[] {
                            "JPG",
                            "gps.jpg",
                            "jpg",
                            "Duplicate2.jpg"});
                table20.AddRow(new string[] {
                            "mov",
                            "good.mov",
                            "mov",
                            "duplicate.Mov"});
#line 123
 testRunner.And("I copy the following files in the folder \'DuplicateTimeStampDontMove\'", ((string)(null)), table20, "And ");
#line hidden
                TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table21.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table21.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table21.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table21.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table21.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table21.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table21.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table21.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table21.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
                table21.AddRow(new string[] {
                            "\\CR2\\Duplicate.cr2"});
                table21.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table21.AddRow(new string[] {
                            "\\JPG\\duplicate.jpg"});
                table21.AddRow(new string[] {
                            "\\JPG\\Duplicate2.jpg"});
                table21.AddRow(new string[] {
                            "\\mov\\duplicate.Mov"});
#line 130
 testRunner.Then("the folder \'DuplicateTimeStampDontMove\' with subfolders contains", ((string)(null)), table21, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table22.AddRow(new string[] {
                            "false",
                            "false",
                            ""});
#line 147
 testRunner.When("I process the folder \'DuplicateTimeStampDontMove\' with the following flags", ((string)(null)), table22, "When ");
#line hidden
                TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table23.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table23.AddRow(new string[] {
                            "\\CR2\\20180408_072740.cr2"});
                table23.AddRow(new string[] {
                            "\\CR2\\20180408_072740_2.CR2"});
                table23.AddRow(new string[] {
                            "\\JPG\\20180310_115353.jpg"});
                table23.AddRow(new string[] {
                            "\\JPG\\20180310_115353_2.jpg"});
                table23.AddRow(new string[] {
                            "\\JPG\\20200127_115041.jpg"});
                table23.AddRow(new string[] {
                            "\\JPG\\20200127_115041_2.jpg"});
                table23.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table23.AddRow(new string[] {
                            "\\mov\\20151129_093543.MOV"});
                table23.AddRow(new string[] {
                            "\\mov\\20160124_141020.Mov"});
                table23.AddRow(new string[] {
                            "\\mov\\20160124_141020_2.MOV"});
                table23.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table23.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table23.AddRow(new string[] {
                            "\\NEF\\20080601_020200_2.nef"});
#line 150
 testRunner.Then("the folder \'DuplicateTimeStampDontMove\' with subfolders contains", ((string)(null)), table23, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="DuplicateTimeStampMoveWithExistingFiles")]
        [Xunit.TraitAttribute("FeatureTitle", "ProcessFolder")]
        [Xunit.TraitAttribute("Description", "DuplicateTimeStampMoveWithExistingFiles")]
        public virtual void DuplicateTimeStampMoveWithExistingFiles()
        {
            string[] tagsOfScenario = ((string[])(null));
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DuplicateTimeStampMoveWithExistingFiles", null, ((string[])(null)));
#line 167
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
#line 4
this.FeatureBackground();
#line hidden
#line 168
 testRunner.Given("I create a copy of all test files into the folder \'DuplicateTimeStampMoveWithExis" +
                        "tingFiles\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                            "SourceFolder",
                            "SourceFile",
                            "DestinationFolder",
                            "DestinationFile"});
                table24.AddRow(new string[] {
                            "CR2",
                            "good.cr2",
                            "cr2",
                            "Duplicate.cr2"});
                table24.AddRow(new string[] {
                            "jpg",
                            "good.jpg",
                            "jpg",
                            "duplicate.jpg"});
                table24.AddRow(new string[] {
                            "JPG",
                            "gps.jpg",
                            "jpg",
                            "Duplicate2.jpg"});
                table24.AddRow(new string[] {
                            "mov",
                            "good.mov",
                            "mov",
                            "duplicate.Mov"});
#line 169
 testRunner.And("I copy the following files in the folder \'DuplicateTimeStampMoveWithExistingFiles" +
                        "\'", ((string)(null)), table24, "And ");
#line hidden
                TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                            "SourceFolder",
                            "SourceFile",
                            "DestinationFolder",
                            "DestinationFile"});
                table25.AddRow(new string[] {
                            "CR2",
                            "20180408_122634.CR2",
                            "DuplicateTimeStampMoveWithExistingFilesProcessed\\2018\\Q2",
                            "20180408_122634.CR2"});
                table25.AddRow(new string[] {
                            "CR2",
                            "20180408_122634.CR2",
                            "DuplicateTimeStampMoveWithExistingFilesProcessed\\2018\\Q2",
                            "20180408_122634_2.CR2"});
#line 175
 testRunner.And("I copy the following files", ((string)(null)), table25, "And ");
#line hidden
                TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table26.AddRow(new string[] {
                            "\\CR2\\20180408_122634.CR2"});
                table26.AddRow(new string[] {
                            "\\CR2\\Good.CR2"});
                table26.AddRow(new string[] {
                            "\\JPG\\Good.jpg"});
                table26.AddRow(new string[] {
                            "\\JPG\\GPS.jpg"});
                table26.AddRow(new string[] {
                            "\\mov\\20160124_141023.MOV"});
                table26.AddRow(new string[] {
                            "\\mov\\Good.MOV"});
                table26.AddRow(new string[] {
                            "\\mov\\Good2.MOV"});
                table26.AddRow(new string[] {
                            "\\NEF\\20080601_020200.nef"});
                table26.AddRow(new string[] {
                            "\\NEF\\Good.nef"});
                table26.AddRow(new string[] {
                            "\\CR2\\Duplicate.cr2"});
                table26.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
                table26.AddRow(new string[] {
                            "\\JPG\\duplicate.jpg"});
                table26.AddRow(new string[] {
                            "\\JPG\\Duplicate2.jpg"});
                table26.AddRow(new string[] {
                            "\\mov\\duplicate.Mov"});
#line 180
 testRunner.Then("the folder \'DuplicateTimeStampMoveWithExistingFiles\' with subfolders contains", ((string)(null)), table26, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table27.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634.CR2"});
                table27.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634_2.CR2"});
#line 196
 testRunner.Then("the folder \'DuplicateTimeStampMoveWithExistingFilesProcessed\' with subfolders con" +
                        "tains", ((string)(null)), table27, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                            "DebugDontRenameFile",
                            "MoveToProcessedByYear",
                            "ProcessedPath"});
                table28.AddRow(new string[] {
                            "false",
                            "true",
                            "DuplicateTimeStampMoveWithExistingFilesProcessed"});
#line 201
 testRunner.When("I process the folder \'DuplicateTimeStampMoveWithExistingFiles\' with the following" +
                        " flags", ((string)(null)), table28, "When ");
#line hidden
                TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table29.AddRow(new string[] {
                            "\\JPG\\Bad.jpg"});
#line 204
 testRunner.Then("the folder \'DuplicateTimeStampMoveWithExistingFiles\' with subfolders contains", ((string)(null)), table29, "Then ");
#line hidden
                TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                            "Path"});
                table30.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200.nef"});
                table30.AddRow(new string[] {
                            "\\2008\\Q2\\20080601_020200_2.nef"});
                table30.AddRow(new string[] {
                            "\\2015\\Q4\\20151129_093543.MOV"});
                table30.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141020.Mov"});
                table30.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141020_2.MOV"});
                table30.AddRow(new string[] {
                            "\\2016\\Q1\\20160124_141023.MOV"});
                table30.AddRow(new string[] {
                            "\\2018\\Q1\\20180310_115353.jpg"});
                table30.AddRow(new string[] {
                            "\\2018\\Q1\\20180310_115353_2.jpg"});
                table30.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_072740.cr2"});
                table30.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_072740_2.CR2"});
                table30.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634.CR2"});
                table30.AddRow(new string[] {
                            "\\2020\\Q1\\20200127_115041.jpg"});
                table30.AddRow(new string[] {
                            "\\2020\\Q1\\20200127_115041_2.jpg"});
                table30.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634_2.CR2"});
                table30.AddRow(new string[] {
                            "\\2018\\Q2\\20180408_122634_3.CR2"});
#line 207
 testRunner.And("the folder \'DuplicateTimeStampMoveWithExistingFilesProcessed\' with subfolders con" +
                        "tains", ((string)(null)), table30, "And ");
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
                ProcessFolderFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                ProcessFolderFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
