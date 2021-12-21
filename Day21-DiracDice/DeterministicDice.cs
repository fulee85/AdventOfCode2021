using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21DiracDice
{
    public class DeterministicDice
    {
        private int number = 1;
        private int rollCount = 0;

        public int RollCount => rollCount;

        public int Roll()
        {
            rollCount++;

            if (number == 101)
            {
                number = 1;
            }

            return number++;
        }

        public int RollThreeTimes()
        {
            return Enumerable.Repeat(0,3).Sum(_ => Roll());
        }
    }
}
