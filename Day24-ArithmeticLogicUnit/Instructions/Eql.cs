namespace Day24ArithmeticLogicUnit.Instructions
{
    public class Eql : IInstruction
    {
        public Eql(string a, string b)
        {
            if (int.TryParse(b, out var x))
            {
                Execute = alu => alu[a] = alu[a] == x ? 1 : 0;
            }
            else
            {
                Execute = alu => alu[a] = alu[a] == alu[b] ? 1 : 0;
            }
        }

        public Action<ALU> Execute { get; init; }
    }
}