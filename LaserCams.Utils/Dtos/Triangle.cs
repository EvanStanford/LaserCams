using System;
using System.Collections.Generic;
using System.Text;

namespace LaserCams.Utils
{
    public class Triangle
    {
        public Triangle(Vector normal, Point a, Point b, Point c) { Normal = normal; A = a; B = b; C = c; }
        public Vector Normal { get; set; }
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
    }
}
