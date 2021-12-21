using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21DiracDice
{
    public class QuantumPlayer
    {
        public static decimal Player1WinningCount;
        public static decimal Player2WinningCount;
        private readonly int currentPosition;
        private int currentScore;
        private readonly char id;

        public QuantumPlayer(int position, char id = default, int score = 0)
        {
            currentPosition = position;
            currentScore = score;
            this.id = id;
        }

        public QuantumPlayer QuantumMove(int moveCount)
        {
            var newPosition = currentPosition + moveCount;
            newPosition %= 10;

            if (newPosition == 0)
            {
                newPosition = 10;
            }

            return new QuantumPlayer(newPosition, id, currentScore + newPosition);
        }

        public QuantumPlayer Copy => new(currentPosition, id, currentScore);

        public int Score => currentScore;

        public void Win(long multiplyer)
        {
            if (id == '1')
            {
                Player1WinningCount += multiplyer;
            }
            else
            {
                Player2WinningCount += multiplyer;
            }
        }
    }
}
