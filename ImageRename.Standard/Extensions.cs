using System;

namespace ImageRename.Standard
{
    public static class Extensions
    {
       // private static double ToDegrees(this string coordinates, string negativeOrdination)
            public static double ToDegrees(this string coordinates)
        {
            var signage = 1;
            coordinates=coordinates
                    .Replace("′", "'")
                    .Replace('″', '"')
                    .Replace("\"","\" ")
                    .Replace("\"  ", "\" ")
                    .Replace("° ", "°")
                    .Replace("' ", "'")
                    .ToUpper();

            if (coordinates.Contains("W") || coordinates.Contains("S"))
            {
                signage = -1;
            }
            coordinates = coordinates.Replace("\"", " ").Replace("''", " ");
            var degrees = Convert.ToDouble(coordinates.Split('°')[0]);
            var minutes = Convert.ToDouble(coordinates.Split('°')[1].Substring(0, 2));
            var s = coordinates.Split(Convert.ToChar("'"))[1];
            var s1 = s.Split(' ');
            var seconds = Convert.ToDouble(s1[0]);

            var retval = signage * (degrees + (minutes / 60) + (seconds / 3600));
            Console.WriteLine($"{coordinates}  ==> {retval}");
            return retval;
        }

        //public static double ToDegrees(this string cordinates)
        //{
        //    if (cordinates.Contains("W"))
        //    {
        //        return cordinates.ToDegrees("W");
        //    }
        //    if (cordinates.Contains("S"))
        //    {
        //        return cordinates.ToDegrees("S");
        //    }
        //    else
        //    {
        //        return cordinates.ToDegrees(string.Empty);
        //    }
        //}

        [Obsolete]
        public static double ToDegreesLatitude(this string coordinates)
        {
            return coordinates.ToDegrees();
        }
        [Obsolete]
        public static double ToDegreesLongitude(this string coordinates)
        {
            return coordinates.ToDegrees();
        }
    }
}