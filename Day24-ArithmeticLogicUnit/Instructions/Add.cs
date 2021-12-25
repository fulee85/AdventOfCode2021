namespace Day24ArithmeticLogicUnit.Instructions
{
    public class Add : IInstruction
    {
        public Add(string a, string b)
        {
            if (int.TryParse(b, out var x))
            {
                Execute = alu => alu[a] += x;
            }
            else
            {
                Execute = alu => alu[a] += alu[b];
            }
        }

        public Action<ALU> Execute { get; init; }
    }
}