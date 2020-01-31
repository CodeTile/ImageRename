using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Xunit;

namespace ImageRename.Tests
{
    internal class TestHelper
    {
        internal static IConfiguration GetConfiguration(string settingsFileName = "appsettings.json")
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), settingsFileName);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(path);
            }
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(path, optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();

#if DEBUG
            path = Path.Combine(Directory.GetCurrentDirectory(), "secrets.json");
            if (File.Exists(path))
            {
                builder.AddJsonFile(path, optional: false, reloadOnChange: true);
            }
#endif
            return builder.Build();
        }


        internal static ILogger<T> GetILoggerFactory<T>()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddConsole();
                //.AddEventLog();
            });

            return loggerFactory.CreateLogger<T>();
        }


        public static List<T> ToList<T>(dynamic[] source)
        {
            var retVal = new List<T>();
            foreach (var item in source)
            {
                retVal.Add(JsonSerializer.Deserialize<T>(item.ToString()));
            }
            return retVal;
        }
        internal static DateTime ConvertToDateTime(string value)
        {
            return ConvertToDateTime(value, Convert.ToDateTime( TimeProvider.Current.Now));
        }

        internal static DateTime ConvertToDateTime(string value, DateTime currentDateTime)
        {

            DateTime retVal;
            switch (value.ToLower())
            {
                case "<<today>>":
                case "<<now>>":
                    retVal = currentDateTime;
                    break;
                case "<<yesterday>>":
                    retVal = currentDateTime.AddDays(-1);
                    break;
                case "<<yearstart>>":
                    retVal = new DateTime(currentDateTime.Year, 1, 1);
                    break;
                case "<<monthstart>>":
                    retVal = new DateTime(currentDateTime.Year, currentDateTime.Month, 1);
                    break;
                case "<<mondaylastweek>>":
                    retVal = currentDateTime.AddDays(-7).GetDayInWeek(DayOfWeek.Monday);
                    break;
                case "<<fridaylastweek>>":
                    retVal = currentDateTime.AddDays(-7).GetDayInWeek(DayOfWeek.Friday);
                    break;
                default:
                    retVal = Convert.ToDateTime(value);
                    break;
            }

            if (retVal.Year == 1)
            {
                throw new ArgumentOutOfRangeException(value, $"parameter '{nameof(value)}' value '{value}' is out of range");
            }
            return retVal;
        }
    }
}
