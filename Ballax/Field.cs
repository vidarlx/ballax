using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ballax
{
    class Field : Button
    {
        int state;
        int width, height;
        int x, y;

        public void setWidth(int width)
        {
            this.width = width;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void draw()
        {
            this.Width = this.width;
            this.Height = this.height;
            this.Left = this.x * this.width + 2;
            this.Top = this.y * this.height + 2;
            this.Visible = true;
            this.TabStop = false;                                           //prevent to move through the fields using tab key
            this.FlatStyle = FlatStyle.Flat;                                //remove convex button border
            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.White;
            this.FlatAppearance.CheckedBackColor = Color.White;
            this.FlatAppearance.MouseDownBackColor = Color.White;
            this.FlatAppearance.MouseOverBackColor = Color.White;           //highlight field
            this.Cursor = Cursors.Hand;
            this.Name = "button_" + x.ToString() + "_" + y.ToString();      //assing unique id
        }

        public void bindClickEvent()
        {
            /*
             * There is several posibilities after the click.
             * 
             * 1. Ball is raised.
             *      1.1. Field is empty - just put ball here. 
             *      1.2. Field is not empty - don't do antyhing - don't drop ball also
             * 2. Ball is not raised.
             *      2.1. Field is empty. Don't do  anything.
             *      2.2. Field is not empty - raise it
             */
            this.Click += (sender, e) =>
            {
                Button button = sender as Button;
                Player player = Player.Instance;
                /* retrieve x & y position of clicked button */
                string controlName = button.Name.ToString();
                string[] controlNameSplitted = controlName.Split('_');
                int controlIndexX = int.Parse(controlNameSplitted[1]);
                int controlIndexY = int.Parse(controlNameSplitted[2]);

                // case 1
                if (player.PICKED_UP)
                {
                    /* is this field empty? case 1.1 */
                    if (this._checkIfEmpty())
                    {
                        //put ball here

                        player.PICKED_UP = false;
                    }                     
                }
                // case 2
                else
                {
                    /* is this field empty? case 2.2 */
                    if (!this._checkIfEmpty())
                    {
                        //pick up the ball
                        player.ball.setCoords(this.x, this.y);
                        player.PICKED_UP = true;
                    }   
                }
            };
        }

        private bool _checkIfEmpty()
        {
            if (this.state > 0)
            {
                return false;
            }
            return true;
        }
    }
}
