using System;
using System.Collections.Generic;
using System.Text;
using IxMilia.Stl;
using System.IO;
using System.Linq;

namespace LaserCams.Utils
{
    public class OutputWriter : IOutputWriter
    {
        public void Write(List<Triangle> triangles, string path)
        {
            var _stlFile = new StlFile();
            _stlFile.SolidName = "solidname";

            triangles.ForEach(t => _stlFile.Triangles.Add(new StlTriangle(
                new StlNormal(t.Normal.X, t.Normal.Y, t.Normal.Z),
                new StlVertex(t.A.X, t.A.Y, t.A.Z),
                new StlVertex(t.B.X, t.B.Y, t.B.Z),
                new StlVertex(t.C.X, t.C.Y, t.C.Z))));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                _stlFile.Save(fs);
            }
        }
    }
}
