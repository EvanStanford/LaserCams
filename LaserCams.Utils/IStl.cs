using System.Collections.Generic;

namespace LaserCams.Utils
{
    public interface IStl
    {
        void Write(List<Triangle> triangles, string path);
    }
}