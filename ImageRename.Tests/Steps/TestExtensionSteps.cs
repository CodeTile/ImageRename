﻿using System;
using System.Collections.Generic;
using ImageRename.Tests.Context;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ImageRename.Tests.Steps
{
    [Binding]
    public class TestExtensionSteps : BaseSteps
    {
        public TestExtensionSteps(BaseContext context) : base(context)
        {
        }

        private DayOfWeek GetDayOfWeek(string dayOfWeek)
        {
            var day = (dayOfWeek.ToLower()) switch
            {
                "monday" => DayOfWeek.Monday,
                "tuesday" => DayOfWeek.Tuesday,
                "wednesday" => DayOfWeek.Wednesday,
                "thursday" => DayOfWeek.Thursday,
                "friday" => DayOfWeek.Friday,
                "saturday" => DayOfWeek.Saturday,
                "sunday" => DayOfWeek.Sunday,
                _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek)),
            };
            return day;
        }
        [Given(@"I wait (.*) second")]
        public void GivenIWaitSecond(int waitInSeconds)
        {
            System.Threading.Thread.Sleep(1000* waitInSeconds);
        }

        [Given(@"I check the date time extenstion GetFirstDayOfWeek")]
        public void GivenICheckTheDateTimeExtenstionGetFirstDayOfWeek(Table table)
        {
            var results = new List<ValueExpected>();
            foreach (var row in table.Rows)
            {
                var target = Convert.ToDateTime(row["Value"]);
                var actual = target.GetFirstDayOfWeek();
                results.Add(new ValueExpected() { Value = row["Value"], Expected = actual.ToString("d MMM yyyy") });
            }

            table.CompareToSet(results);
        }

        [Given(@"I Test Extention Method StartOfWeek with the following values")]
        public void GivenITestExtenstionMethodStartOfWeekWithTheFollowingValues(Table table)
        {
            var results = new List<StartOfWeekData>(); ;
            foreach (var row in table.Rows)
            {
                var target = Convert.ToDateTime(row["TargetDate"]);
                var expected = Convert.ToDateTime(row["Expected"]);

                var result = new StartOfWeekData()
                {
                    TargetDate = target.ToString("dd MMM yyyy"),
                    DayOfWeek = row["DayOfWeek"],
                    Expected = expected.ToString("dd MMM yyyy")
                };

                results.Add(result);
            }
            table.CompareToSet(results);
        }

        [Then(@"I check extension method GetDayInWeek returns the following")]
        public void ThenICheckExtensionMethodGetDayInWeekReturnsTheFollowing(Table table)
        {
            var results = new List<ValueExpected>();
            var sut = Context.TimeProvider;
            foreach (var row in table.Rows)
            {
                var dow = GetDayOfWeek(row["Value"]);
                var actual = sut.Now.GetDayInWeek(dow).ToString("d MMM yyyy");
                results.Add(new ValueExpected() { Value = row["Value"], Expected = actual });
            }
            table.CompareToSet(results);
        }

        public struct StartOfWeekData
        {
            public string DayOfWeek { get; set; }
            public string Expected { get; set; }
            public string TargetDate { get; set; }
        }

        public struct ValueExpected
        {
            public string Expected { get; set; }
            public string Value { get; set; }
        }
        public struct ValueExpectedFloat
        {
            public float Expected { get; set; }
            public string Value { get; set; }
        }
        [Given(@"I check ToGpsSector")]
        public void GivenICheckToGpsSector(Table table)
        {
            var results = new List<ValueExpected>();
            foreach (var row in table.Rows)
            {
                var actual = row["Value"].ToGpsSector();
                results.Add(new ValueExpected() { Value = row["Value"], Expected = actual });
            }
            table.CompareToSet(results);
        }
        [Given(@"I check ToGpsDegrees")]
        public void GivenICheckToGpsDegrees(Table table)
        {
            var results = new List<ValueExpectedFloat>();
            foreach (var row in table.Rows)
            {
                float actual = row["Value"].ToGpsDegrees();
                results.Add(new ValueExpectedFloat() { Value = row["Value"], Expected = actual });
            }
            table.CompareToSet(results);
        }

        [Given(@"I check ToGpsMinutes")]
        public void GivenICheckToGpsMinutes(Table table)
        {
            var results = new List<ValueExpectedFloat>();
            foreach (var row in table.Rows)
            {
                float actual = row["Value"].ToGpsMinutes();
                results.Add(new ValueExpectedFloat() { Value = row["Value"], Expected = actual });
            }
            table.CompareToSet(results);
        }

        [Given(@"I check ToGpsSeconds")]
        public void GivenICheckToGpsSeconds(Table table)
        {
            var results = new List<ValueExpectedFloat>();
            foreach (var row in table.Rows)
            {
                float actual = row["Value"].ToGpsSeconds();
                results.Add(new ValueExpectedFloat() { Value = row["Value"], Expected = actual });
            }
            table.CompareToSet(results);
        }

    }
}