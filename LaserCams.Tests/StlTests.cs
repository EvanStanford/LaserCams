using LaserCams.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using Xunit;

namespace LaserCams.Tests
{
    public class StlTests
    {
        [Fact]
        public void WriteAndRead()
        {
            string path = @"C:\Output\File.stl";
            var triangles = new List<Triangle>{
                new Triangle(
                new Vector(0, 0, -1),
                new Point(0, 0, 0),
                new Point(1, 0, 0),
                new Point(1, 1, 0)
                ),
                new Triangle(
                new Vector(0, -1, 0),
                new Point(0, 0, 0),
                new Point(1, 0, 0),
                new Point(1, 0, 1)
                ),
                new Triangle(
                new Vector(1, 0, 0),
                new Point(1, 0, 0),
                new Point(1, 1, 0),
                new Point(1, 0, 1)
                )};

            var stl = new MiliaStl();
            stl.Write(triangles, path);
            Assert.True(File.Exists(path));

            var readTriangles = stl.Read(path);
            Assert.Equal(triangles.Sum(t => t.A.X / t.C.Y), readTriangles.Sum(t => t.A.X / t.C.Y));

            File.Delete(path);
        }
        
        [Theory]
        [InlineData(@"C:\Dropbox\projects\LaserCams\blank cam A.stl")]
        [InlineData(@"C:\Dropbox\projects\LaserCams\blank cam B.stl")]
        public void ReadBlank(string stlFile)
        {
            var stl = new MiliaStl();
            var triangles = stl.Read(stlFile);
            Assert.True(triangles.Count() > 1000);
            var points = triangles.SelectMany(t => new List<Point> { t.A, t.B, t.C });

            float xMax = points.Max(t => t.X);
            var xMaxPoints = points.Where(p => p.X == xMax).ToList();
            Assert.Equal(2, xMaxPoints.Select(p => p.Y).Distinct().Count());
            var zAltitudes = xMaxPoints.Select(p => p.Z).Distinct().OrderBy(z => z);
            float zzTop = zAltitudes.Max();
            float zzBottom = zAltitudes.Min();
            Assert.Equal(2, xMaxPoints.Select(p => p.Z).Distinct().Count());
            
            float yMax = points.Max(t => t.Y);
            var yMaxPoints = points.Where(p => p.Y == yMax).ToList();
            Assert.Equal(2, yMaxPoints.Select(p => p.X).Distinct().Count());
            Assert.Equal(zAltitudes, yMaxPoints.Select(p => p.Z).Distinct().OrderBy(z => z));
            
            float xMin = points.Min(t => t.X);
            var xMinPoints = points.Where(p => p.X == xMin).ToList();
            Assert.Equal(2, xMinPoints.Select(p => p.Y).Distinct().Count());
            Assert.Equal(zAltitudes, xMinPoints.Select(p => p.Z).Distinct().OrderBy(z => z));
            
            float yMin = points.Min(t => t.Y);
            var yMinPoints = points.Where(p => p.Y == yMin).ToList();
            Assert.Equal(2, yMinPoints.Select(p => p.X).Distinct().Count());
            Assert.Equal(zAltitudes, yMinPoints.Select(p => p.Z).Distinct().OrderBy(z => z));

            Assert.Equal(yMaxPoints.Select(p => p.X).Distinct().OrderBy(x => x),
                yMinPoints.Select(p => p.X).Distinct().OrderBy(x => x));
            Assert.Equal(xMaxPoints.Select(p => p.Y).Distinct().OrderBy(y => y),
                xMinPoints.Select(p => p.Y).Distinct().OrderBy(y => y));
        }
    }
}

