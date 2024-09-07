using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLSS.Mathematics
{
    public struct Vector3(float x, float y, float z)
    {
        public float x = x, y = y, z = z;

        public override string ToString()
        {
            return $"{x} {y} {z}";
        }
    }

    public struct Vector3Int(int x, int y, int z)
    {
        public int x = x, y = y, z = z;

        public override string ToString()
        {
            return $"{x} {y} {z}";
        }
    }
}
