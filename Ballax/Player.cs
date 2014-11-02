using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ballax
{
    public class Player
    {
        /* picked up the ball? */
        public bool PICKED_UP;
        public Ball ball;

        /* player's score */
        public int score;

        //singleton
        private static Player instance = null;
        private Player() {}

        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();
                }

                return instance;
            }
        }

        public void init()
        {
            PICKED_UP = false;
            this.score = 0;
        }

        public void bindBall(Ball ball)
        {
            this.ball = ball;
        }

        public Ball getBindedBall()
        {
            return this.ball;
        }
    }
}
