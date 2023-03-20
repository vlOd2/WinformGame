using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinformGame
{
    public class AABB
    {
        public int X1;
        public int Y1;
        public int X2;
        public int Y2;

        public bool IsColliding(AABB aabb) 
        {
            return aabb.X2 > X1 && 
                aabb.X1 < X2 &&
                aabb.Y2 > Y1 &&
                aabb.Y1 < Y2;
        }
    }
}
