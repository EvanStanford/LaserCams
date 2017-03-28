using System.Collections.Generic;

namespace LaserCams.Utils
{
    public class TriangleConverter : ITriangleConverter
    {
        public IEnumerable<Triangle> Convert(List<Point> points)
        {
            //add one extra triangle to indicate timing and direction
            var firstPoint = points[0];
            var secondPoint = points[1];

            yield return new Triangle(
                new Vector(0, 0, 1),
                new Point(firstPoint.X * 1.2f, firstPoint.Y * 1.2f, 0),
                new Point(firstPoint.X * 1.4f, firstPoint.Y * 1.4f, 0),
                new Point(secondPoint.X * 1.3f, secondPoint.Y * 1.3f, 0)
                );



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
}
