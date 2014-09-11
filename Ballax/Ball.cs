using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Ballax
{
    public class Ball
    {
        int x, y;
        /* currently active field */

        public const int BALL_FOOTBALL = 1;
        public const int BALL_BASKETBALL = 2;
        public const int BALL_VOLEYBALL = 3;

        public Field current {
            set; get;
        }

        public void setCurrent(Field field) 
        {
            this.current = field;
        }

        public Field getCurrent()
        {
            return this.current;
        }

        public void unset()
        {
            this.current = null;
        }

        public static Image getImage(int type)
        {
            switch(type) 
            {
                case Ball.BALL_FOOTBALL:
                    return Ballax.Images.ball1;

                case Ball.BALL_BASKETBALL:
                    return Ballax.Images.ball2;

                case Ball.BALL_VOLEYBALL:
                    return Ballax.Images.ball3;

                default:
                    return Ballax.Images.ball1;
            }
            
        }
        
    }
}
