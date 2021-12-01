using System;
using System.IO;
using System.Linq;

namespace Day01_Sonar_Sweep
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File
                .ReadAllText("input.txt")
                .Split(Environment.NewLine)
                .Select(l => int.Parse(l))
                .ToArray();

            int increaseCount = 0;
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i - 1] < input[i])
                {
                    increaseCount++;
                }
            }

            Console.WriteLine($"{increaseCount} measurements are larger than the previous measurement");

            increaseCount = 0;
            for (int i = 3; i < input.Length; i++)
            {
                if (input[i - 3] < input[i])
                {
                    increaseCount++;
                }
            }

            Console.WriteLine($"{increaseCount} sums are larger than the previous sum");
        }
    }
}
