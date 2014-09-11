using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Ballax
{
    public class Field : Button
    {
        /* 0 or ball type */
        int state = 0;
        int width, height;
        int x, y;
        Board board = Board.Instance;

        public int getState()
        {
            return this.state;
        }

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
            this.Name = "button_" + x.ToString() + "_" + y.ToString();      //assign unique id
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
                /* get x&y pos from name */
                int controlIndexX = int.Parse(controlNameSplitted[1]);
                int controlIndexY = int.Parse(controlNameSplitted[2]);

                // case 1
                if (player.PICKED_UP)
                {
                    /* is this field empty? case 1.1 */
                    if (this._checkIfEmpty())
                    {
                        System.Diagnostics.Debug.WriteLine("Field click: is empty - put to " + this.x.ToString() + ", " + this.y.ToString());
                        //put ball here
                        Field currentField = player.ball.getCurrent();
                        this.putBall(currentField.state);

                        //release lastly ocuppied field
                        currentField.release();
                        player.PICKED_UP = false;

                        /* put new balls */
                        board.putRandomBalls(3);
                    }
                }
                // case 2
                else
                {
                    /* is this field empty? case 2.2 */
                    if (!this._checkIfEmpty())
                    {
                        System.Diagnostics.Debug.WriteLine("Field click: picked up the ball from " + this.x.ToString() + ", " + this.y.ToString());
                        /* pick up the ball */
                        player.ball.setCurrent(this);
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

        public void putBall(int type)
        {
            if (this.state <= 0)
            {
                this.state = type;
                this.BackgroundImage = Ball.getImage(type);
            }
        }

        /* release this field */
        public void release()
        {
            this.state = 0;
            this.BackgroundImage = null;
        }
    }
}
