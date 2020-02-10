using System;

namespace ImageRename.Standard.Model
{
    public class GPSCoridates : IGPSCoridates
    {
        public double DegreesLatitude { get { return Latitude.ToDegrees(); } }
        public double DegreesLongitude { get { return Longitude.ToDegrees(); } }
        public DateTime? GpsDateTime { get; set; }
        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }

    public interface IGPSCoridates
    {
         double DegreesLatitude { get; }
         double DegreesLongitude { get; }
         DateTime? GpsDateTime { get; set; }
         string Latitude { get; set; }

         string Longitude { get; set; }
    }
}