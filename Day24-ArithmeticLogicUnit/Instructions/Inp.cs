namespace Day24ArithmeticLogicUnit.Instructions
{
    public class Inp : IInstruction
    {
        public Inp(string a, Input input, int index)
        {
            Execute = alu => alu[a] = input[index];
        }

        public Action<ALU> Execute { get; init; }
    }
}
