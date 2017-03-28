using System.Collections.Generic;

namespace LaserCams.Utils
{
    public interface ITriangleConverter
    {
        IEnumerable<Triangle> Convert(List<Point> points, CamCenter camCenter);
    }
}