using SmartOnStreetParking.Models.Enums;

using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOnStreetParking.Models
{
    public static class Extensions
    {

        public static List<Coordinate> ToEdges(this DbGeometry Geometry)
        {
            List<Coordinate> Ret = new List<Coordinate>();
            for (int i = 0; i < Geometry.PointCount; i++)
                Ret.Add(new Coordinate { Longitude = Geometry.PointAt(i + 1).XCoordinate.Value, Latitude = Geometry.PointAt(i + 1).YCoordinate.Value });
            return Ret;
        }

        public static DbGeography ToGeography(this Coordinate Coordinate)
        {
            return DbGeography.PointFromText("POINT(" + Coordinate.Longitude.ToString(CultureInfo.InvariantCulture) + " " + Coordinate.Latitude.ToString(CultureInfo.InvariantCulture) + ")", 4326);
        }

        public static DbGeography ToGeography(this DbGeometry Geometry)
        {
            if (Geometry == null || Geometry.PointCount == 0)
                return null;
            else
                return DbGeography.FromText(Geometry.PointAt(1).AsText());
        }

        public static DbGeometry ToGeometry(this List<Coordinate> Edges, GeometryType GeometryType)
        {
            if (Edges == null || Edges.Count == 0)
                return null;


            if (GeometryType == GeometryType.Polygon)
                return DbGeometry.PolygonFromText("POLYGON((" + Edges.Select(i => (string)i.Longitude.ToString(CultureInfo.InvariantCulture) + " " + i.Latitude.ToString(CultureInfo.InvariantCulture)).Aggregate((a, b) => a + "," + b) + "))", 4326);
            else if (GeometryType == GeometryType.Point)
                return DbGeometry.PointFromText("POINT(" + Edges.Select(i => (string)i.Longitude.ToString(CultureInfo.InvariantCulture) + " " + i.Latitude.ToString(CultureInfo.InvariantCulture)).FirstOrDefault() + ")", 4326);
            else
                return DbGeometry.LineFromText("LINESTRING(" + Edges.Select(i => (string)i.Longitude.ToString(CultureInfo.InvariantCulture) + " " + i.Latitude.ToString(CultureInfo.InvariantCulture)).Aggregate((a, b) => a + "," + b) + ")", 4326);
        }


    }
}
