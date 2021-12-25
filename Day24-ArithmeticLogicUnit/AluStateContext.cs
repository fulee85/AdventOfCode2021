namespace Day24ArithmeticLogicUnit
{
    public class AluStateContext
    {
        public AluStateContext(string maxNumber, AluState aluState)
        {
            MaxNumber = maxNumber;
            AluState = aluState;
        }

        public AluState AluState { get; set; }
        public string MaxNumber { get; set; }

        public long MaxNumberValue => long.Parse(MaxNumber);

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
