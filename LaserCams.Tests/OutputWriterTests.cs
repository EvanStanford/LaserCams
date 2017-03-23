using LaserCams.Core;
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
            writer.Write(path);
            Assert.True(File.Exists(path));

            File.Delete(path);
        }
    }
}
