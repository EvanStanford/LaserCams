using System;
using System.Collections.Generic;

namespace LaserCams.Utils
{
    public class TriangleConverter : ITriangleConverter
    {
        public IEnumerable<Triangle> Convert(List<Point> points, CamCenter camCenter)
        {
            for (int i = 0; i < points.Count; i++)
            {
                yield return
                        new Triangle(
                        new Vector(0, 0, 1),
                        new Point(0, 0, 0),
                        points[i],
                        points[(i + 1) % points.Count]);
            }
        }
    }

    public class CamCenter
    {
        public float Top { get; set; }
        public float Bottom { get; set; }
        public Point2d Center { get; set; }
        public List<Point2d> Ring { get; set; }
            
    }
}
