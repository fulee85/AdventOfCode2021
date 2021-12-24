using Day23Amphipod;

namespace Day23_Amphipod
{
    public class Solver
    {
        private readonly IEnumerable<string> input;

        public Solver(IEnumerable<string> input)
        {
            this.input = input;
        }

        public string SolvePartOne()
        {
            var ch = 'y';
            var record = int.MaxValue;
            while (ch == 'y' || ch == 'Y')
            {
                Console.Clear();
                var amphipodGame = new AmphipodGame(input, record);
                var score = amphipodGame.Play();
                Console.Clear();
                Console.WriteLine($"Game has ended. Your score is: {score}");
                if (score < record)
                {
                    record = score;
                    Console.WriteLine($"This is a new record!");
                }
                else
                {
                    Console.WriteLine($"The record remains: {record}");
                }
                Console.WriteLine("Would you like to play again? (y/n)");
                ch = Console.ReadKey().KeyChar;
            }

            return record.ToString();
        }

        public string SolvePartTwo()
        {
            var input2 = input.ToList();
            input2.Insert(3, "  #D#C#B#A#");
            input2.Insert(4, "  #D#B#A#C#");
            var ch = 'y';
            var record = int.MaxValue;
            while (ch == 'y' || ch == 'Y')
            {
                Console.Clear();
                var amphipodGame = new AmphipodGame2(input2, record);
                var score = amphipodGame.Play();
                Console.Clear();
                Console.WriteLine($"Game has ended. Your score is: {score}");
                if (score < record)
                {
                    record = score;
                    Console.WriteLine($"This is a new record!");
                }
                else
                {
                    Console.WriteLine($"The record remains: {record}");
                }
                Console.WriteLine("Would you like to play again? (y/n)");
                ch = Console.ReadKey().KeyChar;
            }

            return record.ToString();
        }
    }
}
