namespace Day24ArithmeticLogicUnit.Instructions
{
    public class Div : IInstruction
    {
        public Div(string a, string b)
        {
            if (int.TryParse(b, out var x))
            {
                Execute = alu => alu[a] /= x;
            }
            else
            {
                Execute = alu => alu[a] /= alu[b];
            }
        }

        public Action<ALU> Execute { get; init; }
    }
}