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
            var result = converter.Convert(points);

            Assert.Equal(points.Count, result.Count());
        }
    }
}
