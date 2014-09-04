using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ballax
{
    public class Ball
    {
        int x, y;

        /*
         * (-1, -1) coords - ball isn't picked up 
         */
        public void resetCoords()
        {
            this.x = -1;
            this.y = -1;
        }

        public void setCoords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        
    }
}
