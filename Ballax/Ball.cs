using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ballax
{
    public class Ball
    {
        int x, y;
        /* currently active field */
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
        
    }
}
