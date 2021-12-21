using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21DiracDice
{
    public class Player
    {
        private int currentPosition;
        private int currentScore;

        public Player(int startingPos)
        {
            currentPosition = startingPos;
        }

        public int Score => currentScore;

        public void Move(int moveCount)
        {
            currentPosition += moveCount;
            currentPosition %= 10;
            if (currentPosition == 0)
            {
                currentPosition = 10;
            }
            currentScore += currentPosition;
        }
    }
}
