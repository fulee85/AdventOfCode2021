using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18Snailfish
{
    public abstract class SnailfishNumber
    {
        public PairNumber? parent;
        public int nestingLevel;

        protected SnailfishNumber(int nestingLevel)
        {
            this.nestingLevel = nestingLevel;
        }

        public static SnailfishNumber operator +(SnailfishNumber a, SnailfishNumber b)
        {
            a.IncrementNestingLevel();
            b.IncrementNestingLevel();
            var result =  new PairNumber(a, b, 0);
            var changeHappened = true;
            while (changeHappened)
            {
                changeHappened = false;
                if (result.Explode().changeHappened)
                {
                    changeHappened = true;
                    continue;
                }
                if (result.Split().changeHappened)
                {
                    changeHappened = true;
                    continue;
                }
            }
            
            return result;
        }

        public abstract (bool changeHappened, SnailfishNumber result) Explode();

        public abstract (bool changeHappened, SnailfishNumber result) Split();

        public abstract long GetMagnitude();

        public virtual void IncrementNestingLevel() => nestingLevel++;


        public static SnailfishNumber Create(string input, int nestingLevel = 0)
        {
            if (int.TryParse(input, out int value))
            {
                return new RegularNumber(value ,nestingLevel);
            }
            else
            {
                var sb = new StringBuilder();
                var middlePart = input[1..^1];
                var level = 0;
                var index = 0;
                var ch = middlePart[index];
                while (ch != ',' || level != 0)
                {
                    if (ch == '[')
                    {
                        level++;
                    }
                    else if (ch == ']')
                    {
                        level--;
                    }
                    sb.Append(ch);
                    index++;
                    ch = middlePart[index];
                }
                var leftPart = sb.ToString();
                var rightPart = middlePart[(index + 1)..];

                var result = new PairNumber(Create(leftPart, nestingLevel + 1), Create(rightPart, nestingLevel + 1), nestingLevel);

                return result;
            }
        }
    }
}
