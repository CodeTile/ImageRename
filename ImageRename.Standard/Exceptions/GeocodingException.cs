using System;

namespace ImageRename.Standard
{
    [Serializable]
    public class GeocodingException : Exception
    {
        public GeocodingException() { }
        public GeocodingException(string message) : base(message) { }
        public GeocodingException(string message, Exception inner) : base(message, inner) { }
        protected GeocodingException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}