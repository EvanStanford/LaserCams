using LaserCams.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace LaserCams.Tests
{
    public class OutputWriterTests
    {
        [Fact]
        public void Write()
        {
            string path = @"C:\Output\File.stl";

            var writer = new OutputWriter();
            writer.Write(new List<Triangle>{
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
                )}, path);
            Assert.True(File.Exists(path));

            File.Delete(path);
        }
    }
}
