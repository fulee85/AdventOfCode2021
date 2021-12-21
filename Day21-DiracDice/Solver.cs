using Day21DiracDice;
using System.Text.RegularExpressions;

namespace Day21_DiracDice
{
    public class Solver
    {
        private int player1StartPos, player2StartPos;
        public Solver(IEnumerable<string> input)
        {
            var inputEnumerator = input.GetEnumerator();
            inputEnumerator.MoveNext();
            player1StartPos = GetStartingPosition(inputEnumerator.Current);
            inputEnumerator.MoveNext();
            player2StartPos = GetStartingPosition(inputEnumerator.Current);
        }

        private int GetStartingPosition(string current)
        {
            var regex = new Regex(@"\d$");
            var match = regex.Match(current);
            return int.Parse(match.Value);
        }

        public string SolvePartOne()
        {
            var player1 = new Player(player1StartPos);
            var player2 = new Player(player2StartPos);
            var dice = new DeterministicDice();
            
            DiracDiceGame.Play(dice, player1, player2);

            var loserPlayer = player1.Score < player2.Score ? player1 : player2;
            return (loserPlayer.Score * dice.RollCount).ToString();
        }

        public string SolvePartTwo()
        {
            var player1 = new QuantumPlayer(player1StartPos, '1');
            var player2 = new QuantumPlayer(player2StartPos, '2');

            DiracDiceGame.PlayQuantumGame(player1, player2);

            return QuantumPlayer.Player1WinningCount > QuantumPlayer.Player2WinningCount ?
                QuantumPlayer.Player1WinningCount.ToString() 
                : QuantumPlayer.Player2WinningCount.ToString();
        }
    }
}
