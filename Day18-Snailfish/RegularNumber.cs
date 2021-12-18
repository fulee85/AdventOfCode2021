namespace Day18Snailfish
{
    public class RegularNumber : SnailfishNumber
    {
        private int value;

        public RegularNumber(int value, int nestingLevel) : base(nestingLevel)
        {
            this.value = value;
        }

        public int Value => value;

        public override (bool changeHappened, SnailfishNumber result) Split()
        {
            if (value >= 10)
            {
                return (true, new PairNumber(value / 2, (value + 1) / 2, nestingLevel));
            }

            return (false, this);
        }



        public void Add(int value)
        {
            this.value += value;
        }

        public override long GetMagnitude()
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public override (bool changeHappened, SnailfishNumber result) Explode()
        {
            return (false, this);
        }
    }
}
