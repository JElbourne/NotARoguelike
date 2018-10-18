using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotARoguelike
{
    static class Utility
    {
        static public int CircleDistance(int x0, int y0, int x1, int y1)
        {
            int x = x0 - x1;
            int y = y0 - y1;

            return (int)Math.Sqrt(x * x + y * y);
        }
 
    }
}