using System;
using System.Collections.Generic;

namespace LaserCams.Utils
{
    public interface IInputReader
    {
        Tuple<List<Point>, List<Point>> Read(string filePath);
    }
}