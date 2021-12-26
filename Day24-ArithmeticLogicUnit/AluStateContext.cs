namespace Day24ArithmeticLogicUnit
{
    public class AluStateContext
    {
        public AluStateContext(string maxNumber, AluState aluState, string minNumber)
        {
            MinNumber = minNumber;
            MaxNumber = maxNumber;
            AluState = aluState;
        }

        public AluState AluState { get; set; }
        public string MaxNumber { get; set; }
        public string MinNumber { get; set; }


        public long MaxNumberValue => long.Parse(MaxNumber);

        public long MinNumberValue => long.Parse(MinNumber);

        public override int GetHashCode()
        {
            return AluState.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is not AluStateContext aluSt) { return false; }

            return aluSt.AluState == this.AluState;
        }
    }
}
