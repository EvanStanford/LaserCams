using LaserCams.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace LaserCams.Tests
{
    public class TriangleConverterTests
    {
        [Fact]
        public void ConvertTriangles()
        {
            var camCenter = new CamCenter
            {
                Bottom = 0,
                Top = 1000,
                Center = new Point2d(0,0),
                Ring = new List<Point2d>
                {
                    new Point2d(4142, 10000),
                    new Point2d(10000, 4142),
                    new Point2d(10000, -4142),
                    new Point2d(4142, -10000),
                    new Point2d(-4142, -10000),
                    new Point2d(-10000, -4142),
                    new Point2d(-10000, 4142),
                    new Point2d(-4142, -10000)
                }
            };

            var points = new List<Point> {
                new Point(0, 1, 0),
                new Point(1, 0.8f, 0),
                new Point(0.1f, 1, 0),
                new Point(0, 1.1f, 0),
                new Point(-0.7f, 0.7f, 0),
                new Point(0,-1,0),
                new Point(-0.9f,-0.9f,0),
                new Point(-1,0,0),
                new Point(-0.8f,0.7f,0)
            };

            var converter = new TriangleConverter();
            var result = converter.Convert(points, camCenter);

            Assert.Equal(points.Count, result.Count());
        }
    }
}
