using System.Collections.Generic;

namespace LaserCams.Utils
{
    public interface IOutputWriter
    {
        void Write(List<Triangle> triangles, string path);
    }
}