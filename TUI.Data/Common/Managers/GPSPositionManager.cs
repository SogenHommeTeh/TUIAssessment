using GeoCoordinatePortable;
using TUI.Data.Common.Models;

namespace TUI.Data.Common.Managers
{
    public static class GPSPositionManager
    {
        public static double DistanceInKmBetween(GPSPositionModel from, GPSPositionModel to)
        {
            var fromCoordinate = new GeoCoordinate(from.Latitude, from.Longitude);
            var toCoordinate = new GeoCoordinate(to.Latitude, to.Longitude);

            return fromCoordinate.GetDistanceTo(toCoordinate) / 1000;
        }
    }
}
