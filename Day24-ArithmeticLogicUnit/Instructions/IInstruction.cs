namespace Day24ArithmeticLogicUnit.Instructions
{
    public interface IInstruction
    {
        public Action<ALU> Execute { get; init; }
    }
}
