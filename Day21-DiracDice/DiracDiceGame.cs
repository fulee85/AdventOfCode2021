using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21DiracDice
{
    public static class DiracDiceGame
    {
        static DiracDiceGame()
        {
            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    for (int k = 1; k < 4; k++)
                    {
                        var sum = i + j + k;
                        if (possibleRollsCount.ContainsKey(sum))
                        {
                            possibleRollsCount[sum]++;
                        }
                        else
                        {
                            possibleRollsCount[sum] = 1;
                        }
                    }
                }
            }
        }


        public static void Play(DeterministicDice dice, Player player1, Player player2)
        {
            var player = player2;
            while (player.Score < 1000)
            {
                player = (player == player1) ? player2 : player1;
                var stepsCount = dice.RollThreeTimes();
                player.Move(stepsCount);
            }
        }

        public static void PlayQuantumGame(QuantumPlayer player1, QuantumPlayer player2)
        {
            RollQuantumDice(player2, player1, 1);
        }

        private static readonly Dictionary<int,int> possibleRollsCount = new Dictionary<int,int>();

        private static void RollQuantumDice(QuantumPlayer actualPlayer, QuantumPlayer idlePlayer, long multiplyer)
        {
            if (actualPlayer.Score >= 21)
            {
                actualPlayer.Win(multiplyer);
                return;
            }

            foreach (var possibleTripleRollValue in possibleRollsCount.Keys)
            {
                RollQuantumDice(idlePlayer.QuantumMove(possibleTripleRollValue), actualPlayer.Copy, multiplyer * possibleRollsCount[possibleTripleRollValue]);
            }
        }
    }
}
