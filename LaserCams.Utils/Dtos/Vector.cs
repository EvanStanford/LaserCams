using System;
using System.Collections.Generic;
using System.Text;

namespace LaserCams.Utils
{
    public class Vector
    {
        public Vector(float x, float y, float z) { X = x; Y = y; Z = z; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}
