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

        int[][] fieldsState;
        Field[][] fields;

        /* drawing context */
        Panel drawingArea = null;

        public Board(Panel panel)
        {
            drawingArea = panel;
            fields = new Field[BOARD_SIZE][];
        }

        public void draw()
        {
            this._initFieldStates();
            this._drawFields(BOARD_SIZE);
        }

        /* initialize board fields with state 0 - empty field */
        private void _initFieldStates()
        {
            fieldsState = new int[BOARD_SIZE][];
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                fieldsState[i] = new int[BOARD_SIZE];
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    fieldsState[i][j] = 0;   
                }
            }
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

    }
}
