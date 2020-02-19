using System;

namespace ImageRename.Tests
{
    public static class Extensions
    {
        public static string ToGpsSector(this string dms)
        {
            string retval = null; ;
            dms = dms.ToUpper();
            if(dms.Contains("N"))
            {
                retval = "N";
            }
            else if (dms.Contains("E"))
            {
                retval = "E";
            }
            if (dms.Contains("S"))
            {
                retval = "S";
            }
            if (dms.Contains("W"))
            {
                retval = "W";
            }

            return retval;
        }
        public static float ToGpsDegrees(this string dms)
        {
            if (string.IsNullOrEmpty(dms))
            {
                throw new ArgumentOutOfRangeException(nameof(dms));
            }
         
            return (float)Convert.ToDecimal(dms.Split('°')[0]);
        }

        public static float ToGpsMinutes(this string dms)
        {
            if (string.IsNullOrEmpty(dms))
            {
                throw new ArgumentOutOfRangeException(nameof(dms));
            }
            return (float)Convert.ToDecimal(dms.Split('°')[1].Split("'")[0]);
        }
        public static float ToGpsSeconds(this string dms)
        {
            if (string.IsNullOrEmpty(dms))
            {
                throw new ArgumentOutOfRangeException(nameof(dms));
            }
            return (float)Convert.ToDecimal(dms.Split("'")[1].Split("\"")[0]);
        }
        public static DateTime GetDayInWeek(this DateTime dt, DayOfWeek dayOfWeek)
        {
            var firstDateOfWeek = dt.GetFirstDayOfWeek().AddDays(dayOfWeek.ToInt());
            return firstDateOfWeek;
        }

        /// <summary>
        /// Returns the first day of the week that the specified date is in.
        /// </summary>
        public static DateTime GetFirstDayOfWeek(this DateTime dt)
        {
            var firstDayOfWeek = DayOfWeek.Monday;
            DateTime firstDayInWeek = dt.Date;
            while (firstDayInWeek.DayOfWeek != firstDayOfWeek)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        public static int ToInt(this DayOfWeek dow)
        {
            switch (dow)
            {
                case DayOfWeek.Monday:
                    return 0;

                case DayOfWeek.Tuesday:
                    return 1;

                case DayOfWeek.Wednesday:
                    return 2;

                case DayOfWeek.Thursday:
                    return 3;

                case DayOfWeek.Friday:
                    return 4;

                case DayOfWeek.Saturday:
                    return 5;

                case DayOfWeek.Sunday:
                    return 6;

                default:
                    throw new ArgumentOutOfRangeException(nameof(dow), dow, null);
            }
        }
    }
}