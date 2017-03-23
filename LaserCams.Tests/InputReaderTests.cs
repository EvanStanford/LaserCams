using System;
using Xunit;
using LaserCams.Utils;
using System.Linq;

namespace LaserCams.Tests
{
    public class InputReaderTests
    {
        [Fact]
        public void ReadPositive()
        {
            var reader = new InputReader();
            var result = reader.Read(@"C:\Dropbox\projects\LaserCams\LaserCams.Tests\Files\star cams.csv"); //required to use absolute paths because xunit bug https://github.com/xunit/xunit/issues/978

            Assert.Equal(result.Item1.Count(), 35);
            Assert.Equal(result.Item2.Count(), 35);
            float maxExpected = 1000000;
            float minExpected = -1000000;
            Assert.True(result.Item1.All(p => p.X < maxExpected && p.X > minExpected && p.Y < maxExpected && p.Y > minExpected));
            Assert.True(result.Item1.All(p => p.Z == 0));
        }
    }
}
