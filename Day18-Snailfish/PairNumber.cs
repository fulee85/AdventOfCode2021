namespace Day18Snailfish
{
    public class PairNumber : SnailfishNumber
    {
        private SnailfishNumber left;
        private SnailfishNumber right;

        public SnailfishNumber Left 
        { 
            get => left; 
            set 
            {
                left = value;
                value.parent = this;
            } 
        }

        public SnailfishNumber Right
        {
            get => right;
            set
            {
                right = value;
                value.parent = this;
            }
        }

        public PairNumber(SnailfishNumber left, SnailfishNumber right, int nestingLevel) : base(nestingLevel)
        {
            this.Left = left;
            this.Right = right;
        }

        public PairNumber(int left, int right, int nestingLevel) : base(nestingLevel)
        {
            this.Left = new RegularNumber(left, nestingLevel + 1);
            this.Right = new RegularNumber(right, nestingLevel + 1);
        }

        public override (bool changeHappened, SnailfishNumber result) Explode()
        {
            if (nestingLevel >= 4)
            {
                MakeExplode();
                var num = new RegularNumber(0, nestingLevel);
                num.parent = this.parent;
                return (true, new RegularNumber(0, nestingLevel));
            }
            else
            {
                var leftResult = Left.Explode();
                if (leftResult.changeHappened)
                {
                    Left = leftResult.result;
                    return (true, this);
                }
                var rightResult = Right.Explode();
                if (rightResult.changeHappened)
                {
                    Right = rightResult.result;
                    return (true, this);
                }

                return (false, this);
            }
        }

        private void MakeExplode()
        {
            parent?.AddLeft(Left as RegularNumber, this);
            parent?.AddRight(Right as RegularNumber, this);
        }

        private void AddLeft(RegularNumber? regularNumber, PairNumber child, bool force = false)
        {
            if (Left is RegularNumber leftNum)
            {
                leftNum.Add(regularNumber.Value);
            }
            else if (Left == child)
            {
                parent?.AddLeft(regularNumber, this);
            }
            else
            {
                if (force)
                {
                    (Left as PairNumber)?.AddLeft(regularNumber, this, force);
                }
                else
                {
                    (Left as PairNumber)?.AddRight(regularNumber, this, true);
                }
            }
        }

        private void AddRight(RegularNumber? regularNumber, PairNumber child, bool force = false)
        {
            if (Right is RegularNumber rightNum)
            {
                rightNum.Add(regularNumber.Value);
            }
            else if (Right == child)
            {
                parent?.AddRight(regularNumber, this);
            }
            else
            {
                if (force)
                {
                    (Right as PairNumber)?.AddRight(regularNumber, this, true);
                }
                else
                {
                    (Right as PairNumber)?.AddLeft(regularNumber, this, true);
                }
            }
        }

        public override void IncrementNestingLevel()
        {
            base.IncrementNestingLevel();
            Left.IncrementNestingLevel();
            Right.IncrementNestingLevel();
        }

        public override long GetMagnitude()
        {
            return Left.GetMagnitude() * 3 + Right.GetMagnitude() * 2;
        }

        public override string ToString()
        {
            return '[' + Left.ToString() + ',' + Right.ToString() + ']';
        }

        public override (bool changeHappened, SnailfishNumber result) Split()
        {
            var leftResult = Left.Split();
            if (leftResult.changeHappened)
            {
                Left = leftResult.result;
                return (true, this);
            }
            var rightResult = Right.Split();
            if (rightResult.changeHappened)
            {
                Right = rightResult.result;
                return (true, this);
            }

            return (false, this);
        }
    }
}
