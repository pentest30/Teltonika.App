using System;
using System.Collections.Generic;
using System.Drawing;

namespace Teltonika.Core.Geofence
{
    public class GeofenceHelper
    {
        public enum DistanceType
        {
            Miles,
            Kilometers
        };

        /// <summary>
        /// Specifies a Latitude / Longitude point.
        /// </summary>
        public struct Position
        {
            public double Latitude;
            public double Longitude;
        }

        private static double ToRadian(double val)
        {
            return (Math.PI / 180) * val;
        }

        /// <summary>
        /// Haversines the formula.
        /// </summary>
        /// <param name="pos1">The pos1.</param>
        /// <param name="pos2">The pos2.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static double HaversineFormula(Position pos1, Position pos2, DistanceType type)
        {
            double r = (type == DistanceType.Miles) ? 3960 : 6371;
            double dLat = ToRadian(pos2.Latitude - pos1.Latitude);
            double dLon = ToRadian(pos2.Longitude - pos1.Longitude);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                       Math.Cos(ToRadian(pos1.Latitude)) * Math.Cos(ToRadian(pos2.Latitude)) *
                       Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = r * c;
            return d;
        }

        public static bool PolyContainsPoint(List<Point> points, Point p)
        {
            bool inside = false;

            // An imaginary closing segment is implied,
            // so begin testing with that.
            Point v1 = points[points.Count - 1];

            foreach (Point v0 in points)
            {
                double d1 = (p.Y - v0.Y) * (v1.X - v0.X);
                double d2 = (p.X - v0.X) * (v1.Y - v0.Y);

                if (p.Y < v1.Y)
                {
                    // V1 below ray
                    if (v0.Y <= p.Y)
                    {
                        // V0 on or above ray
                        // Perform intersection test
                        if (d1 > d2)
                        {
                            inside = !inside; // Toggle state
                        }
                    }
                }
                else if (p.Y < v0.Y)
                {
                    // V1 is on or above ray, V0 is below ray
                    // Perform intersection test
                    if (d1 < d2)
                    {
                        inside = !inside; // Toggle state
                    }
                }

                v1 = v0; //Store previous endpoint as next startpoint
            }

            return inside;
        }

        public static double CalculateDistance(double lat1, double lng1, double lat2, double lng2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lng1 - lng2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;
            return dist * 1.609344;
        }

        public static double GetDirection(double newH, double oldH)
        {
            double deltaH = newH - oldH;

            //Ensure deltaH takes the shortest path from oldH to newH
            if (-180 < deltaH && deltaH < 180)
            {
                return deltaH;
            }
            else if (deltaH <= -180)
            {
                return deltaH + 360;
            }
            else if (deltaH >= 180)
            {
                return deltaH - 360;
            }

            return 0;
        }
        public static double DegreeBearing( double lat1, double lon1,double lat2, double lon2)
        {
            var dLon = ToRad(lon2 - lon1);
            var dPhi = Math.Log(
                Math.Tan(ToRad(lat2) / 2 + Math.PI / 4) / Math.Tan(ToRad(lat1) / 2 + Math.PI / 4));
            if (Math.Abs(dLon) > Math.PI)
                dLon = dLon > 0 ? -(2 * Math.PI - dLon) : (2 * Math.PI + dLon);
            return ToBearing(Math.Atan2(dLon, dPhi));
        }

        public static double ToRad(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static double ToDegrees(double radians)
        {
            return radians * 180 / Math.PI;
        }

        public static double ToBearing(double radians)
        {
            // convert radians to degrees (as bearing: 0...360)
            return (ToDegrees(radians) + 360) % 360;
        }

    }
}
