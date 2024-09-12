
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLSS.Mathematics
{
    internal static class MathUtil
    {
        public static float Wrap(float v, float min, float max)
        {
            return ((v - min) % (max - min)) + min;
        }

        public static int Wrap(int v, int min, int max)
        {
            return ((v - min) % (max - min)) + min;
        }
    }
}