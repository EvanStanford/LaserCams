using System;
using System.Collections.Generic;
using System.Text;
using IxMilia.Stl;
using System.IO;

namespace LaserCams.Core
{
    public class OutputWriter
    {
        public void Write(string path)
        {
            StlFile stlFile = new StlFile();
            stlFile.SolidName = "my-solid";
            stlFile.Triangles.Add(new StlTriangle(new StlNormal(1, 0, 0), new StlVertex(0, 0, 0), new StlVertex(1, 0, 0), new StlVertex(1, 1, 0)));
            // ...

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                stlFile.Save(fs);
            }
        }
    }
}
