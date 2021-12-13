namespace Day13_TransparentOrigami
{
    public class Instruction
    {
        const string FoldUpString = "fold along y=";
        const string FoldLeftString = "fold along x=";
        private readonly string instruction;

        public Instruction(string instruction)
        {
            this.instruction = instruction;
        }

        public TransparentPaper Execute(TransparentPaper transparentPaper)
        {
            if (instruction.StartsWith(FoldUpString))
            {
                return transparentPaper.FoldUpAt(int.Parse(instruction.Substring(FoldUpString.Length)));
            }
            else
            {
                return transparentPaper.FoldLeft(int.Parse(instruction.Substring(FoldUpString.Length)));
            }
        }
    }
}
