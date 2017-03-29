using System;
using System.Collections.Generic;

namespace LaserCams.Utils
{
    public interface IInputReader
    {
        InputCams Read(string filePath);
    }
    
    public class InputCams
    {
        public List<Point> BCam { get; set; }
        public List<Point> ACam { get; set; }
    }
}