using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Ballax
{
    /*
     * Possible states of fields:
     *  0 - empty field
     *  n(>0) - n-type ball is put on this field 
     */
    class Board
    {
        /* length of the board edge */
        const int BOARD_SIZE = 9;
        /* width and height of fields in px */
        const int FIELD_WIDTH = 45;
        const int FIELD_HEIGHT = 45;

        Field[][] fields;

        /* contains next balls */
        Field[] ballsBuffer = new Field[3];

        /* drawing context */
        Panel drawingArea = null;

        /* how many same fields we need to remove
         * from board and add points */
        int eraseBorder = 5;

        private static Board instance = null;
        private Board() { }

        public static Board Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Board();
                }

                return instance;
            }

        }

        public void setDrawingArea(Panel panel)
        {
            drawingArea = panel;
        }

        public void setBuffer(Field[] buffer)
        {
            this.ballsBuffer = buffer;
        }

        public void draw()
        {
            fields = new Field[BOARD_SIZE][];
            this._drawFields(BOARD_SIZE);
        }

        /* draw all fields on board */
        private void _drawFields(int size)
        {
            for (int i = 0; i < size; i++)
            {
                fields[i] = new Field[BOARD_SIZE];
                for (int j = 0; j < size; j++)
                {
                    this._drawField(i, j);
                }
            }
        }

        private void _drawField(int i, int j)
        {
            fields[i][j] = new Field();
            fields[i][j].setWidth(FIELD_WIDTH);
            fields[i][j].setHeight(FIELD_HEIGHT);
            fields[i][j].setX(i);
            fields[i][j].setY(j);
            fields[i][j].draw();
            fields[i][j].bindClickEvent();


            /* add created field to the drawing context */
            drawingArea.Controls.Add(fields[i][j]);
        }

        public void putRandomBalls(int amount)
        {
            int randomX, randomY;
            Random random = new Random();

            /* Get random fields for putting new balls.
             * Omit non-empty fields - we can't put there
             */
            for (int i = 0; i < amount; i++)
            {
                randomX = random.Next(0, BOARD_SIZE);
                randomY = random.Next(0, BOARD_SIZE);
 

                if (fields[randomX][randomY].getState() == 0)
                {
                    fields[randomX][randomY].putBall(this.ballsBuffer[i].getState());
                }
                else
                {
                    i--;
                }
            }            
        }

        public void putBallsToBuffer(int amount)
        {
            int randomType;
            Random random = new Random();

            for (int i = 0; i < amount; i++)
            {
                randomType = random.Next(1, 4);
                ballsBuffer[i].setState(randomType);
            }

            this.drawBuffer(amount);
        }

        /* draw fields for buffer */
        public void initBuffer(Panel buffer)
        {
            for (int i = 0; i < 3; i++)
            {
                ballsBuffer[i] = new Field();
                ballsBuffer[i].Width = 45;
                ballsBuffer[i].Height = 45;
                ballsBuffer[i].FlatStyle = FlatStyle.Flat;
                ballsBuffer[i].FlatAppearance.BorderSize = 1;
                ballsBuffer[i].FlatAppearance.BorderColor = Color.White;
                ballsBuffer[i].FlatAppearance.CheckedBackColor = Color.White;
                ballsBuffer[i].Left = i * ballsBuffer[i].Width + 2;
                ballsBuffer[i].Top = 5;
                ballsBuffer[i].setState(0);

                buffer.Controls.Add(ballsBuffer[i]);
            }

            //draw buffer first time
            this.putBallsToBuffer(3);
            this.drawBuffer(3);
        }

        /* draw balls from buffer */
        public void drawBuffer(int amount)
        {
            for(int i=0;i<amount;i++)
            {
                ballsBuffer[i].BackgroundImage = Ball.getImage(ballsBuffer[i].getState());
            }
        }

        /* Try to remove fields from board */
        public bool tryDeleteNode(int x, int y, int type)
        {
            /* same balls counter */
            int sameBalls = 0;
            List<Point> matchingBalls = new List<Point>();


            /** horizontally **/
            //horizontaly ( right -> left )
            for (int i = x; i >= 0; i--)
                if (fields[i][y].getState() == type)
                {
                    matchingBalls.Add(new Point(i, y));
                    sameBalls++;
                }
                else
                    break;

            //horizontaly ( left -> right )
            for (int i = x; i < Board.BOARD_SIZE; i++)
                if (fields[i][y].getState() == type)
                {
                    matchingBalls.Add(new Point(i, y));
                    sameBalls++;
                }
                else
                    break;

            if (sameBalls > eraseBorder)
            {
                for (int i = 0; i < matchingBalls.Count; i++)
                {
                    this.removeBallFromField(matchingBalls[i].X, matchingBalls[i].Y);
                }
                //addPoints - TODO
                return true;
            }

            /* vertically */
            sameBalls = 0;
            for (int i = y; i >= 0; i--)
                if (fields[x][i].getState() == type)
                {
                    matchingBalls.Add(new Point(x, i));
                    sameBalls++;
                }
                else
                    break;

            for (int i = y; i < Board.BOARD_SIZE; i++)
                if (fields[x][i].getState() == type)
                {
                    matchingBalls.Add(new Point(x, i));
                    sameBalls++;
                }
                else
                    break;

            if (sameBalls > eraseBorder)
            {
                for (int i = 0; i < matchingBalls.Count; i++)
                {
                    this.removeBallFromField(matchingBalls[i].X, matchingBalls[i].Y);
                }
                //addPoints - TODO
                return true;
            }

            /** diagonally - left -> right **/
            sameBalls = 0;
            for (int i = x, j = y; i >= 0 && j >= 0; i--, j--)
                if (fields[i][j].getState() == type)
                {
                    matchingBalls.Add(new Point(i, j));
                    sameBalls++;
                }
                else
                    break;

            for (int i = x, j = y; i < Board.BOARD_SIZE && j < Board.BOARD_SIZE; i++, j++)
                if (fields[i][j].getState() == type)
                {
                    matchingBalls.Add(new Point(i, j));
                    sameBalls++;
                }
                else
                    break;

            if (sameBalls > eraseBorder)
            {
                for (int i = 0; i < matchingBalls.Count; i++)
                {
                    this.removeBallFromField(matchingBalls[i].X, matchingBalls[i].Y);
                }
                //addPoints - TODO
                return true;
            }

            /** diagonally - right -> left **/
            sameBalls = 0;
            for (int i = x, j = y; i < Board.BOARD_SIZE && j > 0; i++, j--)
                if (fields[i][j].getState() == type)
                {
                    matchingBalls.Add(new Point(i, j));
                    sameBalls++;
                }
                else
                    break;

            for (int i = x, j = y; i > 0 && j < Board.BOARD_SIZE; i--, j++)
                if (fields[i][j].getState() == type)
                {
                    matchingBalls.Add(new Point(i, j));
                    sameBalls++;
                }
                else
                    break;

            if (sameBalls > eraseBorder)
            {
                for (int i = 0; i < matchingBalls.Count; i++)
                {
                    this.removeBallFromField(matchingBalls[i].X, matchingBalls[i].Y);
                }
                //addPoints - TODO
                return true;
            }

            return false;
        }

        public void removeBallFromField(int x, int y)
        {
            this.fields[x][y].release();
        }

    }
}
