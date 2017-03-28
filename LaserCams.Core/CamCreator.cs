using System;
using LaserCams.Utils;
using System.Linq;

namespace LaserCams.Core
{
    public class CamCreator
    {
        private readonly IInputReader _reader;
        private readonly ITriangleConverter _triangleConverter;
        private readonly IStl _stl;
        private readonly Config _config;

        public CamCreator(Config config, IInputReader reader = null, ITriangleConverter triangleConverter = null, IStl stl = null)
        {
            _config = config;
            _reader = reader ?? new InputReader();
            _triangleConverter = triangleConverter ?? new TriangleConverter();
            _stl = stl ?? new MiliaStl();
        }

        public void CreateCams()
        {
            var blankCamA = _stl.Read(_config.InputBlankCamAPath);
            var blankCamB = _stl.Read(_config.InputBlankCamBPath);

            var inputCsv = _reader.Read(_config.InputCsvPath);
            var aCamPoints = inputCsv.Item1;
            var bCamPoints = inputCsv.Item2;
            var aCamTriangles = _triangleConverter.Convert(aCamPoints).ToList();
            var bCamTriangles = _triangleConverter.Convert(bCamPoints).ToList();
            _stl.Write(aCamTriangles, _config.ACamPath);
            _stl.Write(bCamTriangles, _config.BCamPath);
        }
    }

    public class Config
    {
        public string InputBlankCamAPath { get; set; }
        public string InputBlankCamBPath { get; set; }
        public string InputCsvPath { get; set; }
        public string ACamPath { get; set; }
        public string BCamPath { get; set; }
    }
}
