using System;

namespace ImageRename.Standard
{
    public static class Extensions
    {
        public static double ToDegreesLatitude(this string latitude)
        {
            return latitude.ToDegrees("S");
        }

        private static double ToDegrees(this string latitude, string negativeOrdination)
        {
            var signage = 1;
            if (latitude.ToUpper().Contains(negativeOrdination))
            {
                signage = -1;
            }
            latitude = latitude.Replace("\"", " ").Replace("''", " ");
            var degrees = Convert.ToDouble(latitude.Split('°')[0]);
            var minutes = Convert.ToDouble(latitude.Split('°')[1].Substring(0, 2));
            var s = latitude.Split(Convert.ToChar("'"))[1];
            var s1 = s.Split(' ');
            var seconds = Convert.ToDouble(s1[0]);

            var retval = signage * (degrees + (minutes / 60) + (seconds / 3600));
            Console.WriteLine($"{latitude}  ==> {retval}");
            return retval;
        }

        public static double ToDegreesLongitude(this string longitude)
        {
            return longitude.ToDegrees("W");
        }
    }
}