using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ballax
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var board = new Board(pBoardArea);
            board.draw();

            Player player = Player.Instance;
            player.init();

            var ball = new Ball();
            player.bindBall(ball);
        }
    }
}
