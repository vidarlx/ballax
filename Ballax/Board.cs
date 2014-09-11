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

        /* drawing context */
        Panel drawingArea = null;

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
            int randomX, randomY, randomType;
            Random random = new Random();

            /* Get random fields for putting new balls.
             * Omit non-empty fields - we can't put there
             */
            for (int i = 0; i < amount; i++)
            {
                randomX = random.Next(0, BOARD_SIZE);
                randomY = random.Next(0, BOARD_SIZE);
                randomType = random.Next(1, 4);

                if (fields[randomX][randomY].getState() == 0)
                {
                    fields[randomX][randomY].putBall(randomType);
                }
                else
                {
                    i--;
                }
                System.Diagnostics.Debug.WriteLine("Put on " + randomX + "," + randomY + " : " + randomType);
            }
            
        }

    }
}
