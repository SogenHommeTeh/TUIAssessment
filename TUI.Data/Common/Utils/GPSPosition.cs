using GeoCoordinatePortable;

namespace TUI.Data.Common.Utils
{
    public class GPSPosition
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double DistanceTo(GPSPosition to)
        {
            var fromCoordinate = new GeoCoordinate(Latitude, Longitude);
            var toCoordinate = new GeoCoordinate(to.Latitude, to.Longitude);

            return fromCoordinate.GetDistanceTo(toCoordinate) / 1000;
        }
    }
}
