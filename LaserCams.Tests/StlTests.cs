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
                new Point(1000, 0, 0),
                new Point(1000, 1000, 0)
                ),
                new Triangle(
                new Vector(0, -1, 0),
                new Point(0, 0, 0),
                new Point(1000, 0, 0),
                new Point(1000, 0, 1000)
                ),
                new Triangle(
                new Vector(1, 0, 0),
                new Point(1000, 0, 0),
                new Point(1000, 1000, 0),
                new Point(1000, 0, 1000)
                )};

            var stl = new MiliaStl();
            stl.Write(triangles, path);
            Assert.True(File.Exists(path));

            var readTriangles = stl.Read(path);
            Assert.Equal(triangles.Sum(t=> t.A.X / t.C.Y), readTriangles.Sum(t => t.A.X / t.C.Y));

            File.Delete(path);
        }
    }
}
