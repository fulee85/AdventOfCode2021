namespace Day13_TransparentOrigami
{
    public class Solver
    {
        private TransparentPaper transparentPaper;
        private List<Instruction> instructions;

        public Solver(IEnumerable<string> input)
        {
            transparentPaper = TransparentPaperFactory.CreateTransparentPaper(input.TakeWhile(s => !string.IsNullOrWhiteSpace(s)));
            instructions = input.SkipWhile(s => !s.StartsWith("fold")).Select(s => new Instruction(s)).ToList();
        }

        public int SolveFirstPart()
        {
            return instructions.First().Execute(transparentPaper).DotsCount;
        }

        public string SolveSecondPart()
        {
            var paper = transparentPaper;

            instructions.ForEach(i => paper = i.Execute(paper));

            return paper.ToString();
        }
    }
}
