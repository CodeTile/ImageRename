using System;

namespace ImageRename.Standard.Model
{
    public class GPSCoridates: IGPSCoridates
    {
        public DateTime? GpsDateTime { get; set; }
        public string Latitude { get; set; }

        public string Longitude { get; set; }
        public double DegreesLongitude { get { return Longitude.ToDegreesLongitude(); } }
        public double DegreesLatitude { get { return Longitude.ToDegreesLatitude(); } }
    }

    public class IGPSCoridates
    {
        DateTime? GpsDateTime { get; set; }
         string Latitude { get; set; }

         string Longitude { get; set; }
         double DegreesLongitude { get; }
         double DegreesLatitude { get; }
    }
}