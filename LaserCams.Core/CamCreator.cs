using System;
using LaserCams.Utils;
using System.Linq;

namespace LaserCams.Core
{
    public class CamCreator
    {
        private readonly IInputReader _reader;
        private readonly ITriangleConverter _triangleConverter;
        private readonly IOutputWriter _writer;
        private readonly Config _config;

        public CamCreator(Config config, IInputReader reader = null, ITriangleConverter triangleConverter = null, IOutputWriter writer = null)
        {
            _config = config;
            _reader = reader ?? new InputReader();
            _triangleConverter = triangleConverter ?? new TriangleConverter();
            _writer = writer ?? new OutputWriter();
        }

        public void CreateCams()
        {
            var input = _reader.Read(_config.InputPath);
            var aCamPoints = input.Item1;
            var bCamPoints = input.Item2;
            var aCamTriangles = _triangleConverter.Convert(aCamPoints).ToList();
            var bCamTriangles = _triangleConverter.Convert(bCamPoints).ToList();
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
