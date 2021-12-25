namespace Day24ArithmeticLogicUnit
{
    public class ALU
    {
        private readonly Dictionary<string, long> variables = new Dictionary<string, long>
        {
            ["w"] = 0L,
            ["x"] = 0L,
            ["y"] = 0L,
            ["z"] = 0L,
        };

        public long this[string index]
        {
            get { return variables[index]; }
            set { variables[index] = value; }
        }

        public ALU()
        {
        }

        public ALU(AluState aluState)
        {
            variables["w"] = 0L;
            variables["x"] = aluState.X;
            variables["y"] = aluState.Y;
            variables["z"] = aluState.Z;
        }

        public AluState GetAluState() => new AluState(variables["x"], variables["y"], variables["z"]);
    }
}
