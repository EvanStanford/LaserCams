using System;
using System.Collections.Generic;
using System.Text;
using IxMilia.Stl;
using System.IO;
using System.Linq;

namespace LaserCams.Utils
{
    public class MiliaStl : IStl
    {
        public void Write(List<Triangle> triangles, string path)
        {
            var stlFile = new StlFile();
            stlFile.SolidName = "solidname";

            triangles.ForEach(t => stlFile.Triangles.Add(Convert(t)));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                stlFile.Save(fs);
            }
        }

        public List<Triangle> Read(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                var stlFile = StlFile.Load(fs);
                return stlFile.Triangles.Select(t => Convert(t)).ToList();
            }
        }

        private Triangle Convert(StlTriangle t)
        {
            return new Triangle(
                new Vector(t.Normal.X, t.Normal.Y, t.Normal.Z),
                new Point(t.Vertex1.X, t.Vertex1.Y, t.Vertex1.Z),
                new Point(t.Vertex2.X, t.Vertex2.Y, t.Vertex2.Z),
                new Point(t.Vertex3.X, t.Vertex3.Y, t.Vertex3.Z));
        }

        private StlTriangle Convert (Triangle t)
        {
            return new StlTriangle(
                new StlNormal(t.Normal.X, t.Normal.Y, t.Normal.Z),
                new StlVertex(t.A.X, t.A.Y, t.A.Z),
                new StlVertex(t.B.X, t.B.Y, t.B.Z),
                new StlVertex(t.C.X, t.C.Y, t.C.Z));
        }
    }
}
