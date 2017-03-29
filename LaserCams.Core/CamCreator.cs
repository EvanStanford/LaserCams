using System;
using LaserCams.Utils;
using System.Linq;

namespace LaserCams.Core
{
    public class CamCreator
    {
        private readonly IInputReader _reader;
        private readonly ITriangleConverter _triangleConverter;
        private readonly IStl _writer;
        private readonly Config _config;

        public CamCreator(Config config, IInputReader reader = null, ITriangleConverter triangleConverter = null, IStl writer = null)
        {
            _config = config;
            _reader = reader ?? new InputReader();
            _triangleConverter = triangleConverter ?? new TriangleConverter();
            _writer = writer ?? new MiliaStl();
        }

        public void CreateCams()
        {
            var input = _reader.Read(_config.InputPath);
            var aCamTriangles = _triangleConverter.Convert(input.ACam).ToList();
            var bCamTriangles = _triangleConverter.Convert(input.BCam).ToList();
            _writer.Write(aCamTriangles, _config.ACamPath);
            _writer.Write(bCamTriangles, _config.BCamPath);
        }
    }

    public class Config
    {
        public string InputPath { get; set; }
        public string ACamPath { get; set; }
        public string BCamPath { get; set; }
    }
}
