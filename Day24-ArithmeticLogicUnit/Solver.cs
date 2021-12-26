using Day24ArithmeticLogicUnit;
using Day24ArithmeticLogicUnit.Instructions;

namespace Day24_ArithmeticLogicUnit
{
    public class Solver
    {
        private readonly IEnumerable<string> input;
        private long minValue;

        public Solver(IEnumerable<string> input)
        {
            this.input = input;
        }

        public string SolvePartOne()
        {
            var modelNumber = new Input();
            var instructionsFactory = new InstructionFactory(modelNumber);
            var instructionsLists = instructionsFactory.CreateInstructionsLists(input).ToList();

            var aluStateContexts = new HashSet<AluStateContext> { new AluStateContext("", new AluState(0,0,0), "")};
            for (int i = 0; i < instructionsLists.Count; i++)
            {
                var newAluStateContexts = new HashSet<AluStateContext>();

                for (int digit = 1; digit <= 9; digit++)
                {
                    modelNumber[i] = digit;
                    foreach (var aluStateContext in aluStateContexts)
                    {
                        var alu = new ALU(aluStateContext.AluState);
                        for (int j = 0; j < instructionsLists[i].Count; j++)
                        {
                            var instruction = instructionsLists[i][j];
                            instruction.Execute(alu);
                        }
                        
                        var newAluStateContext = new AluStateContext(
                            aluStateContext.MaxNumber + digit.ToString(),
                            alu.GetAluState(),
                            aluStateContext.MinNumber + digit.ToString());

                        if (newAluStateContexts.TryGetValue(newAluStateContext, out var stateContext))
                        {
                            stateContext.MaxNumber = Math.Max(stateContext.MaxNumberValue, newAluStateContext.MaxNumberValue).ToString();
                            stateContext.MaxNumber = Math.Min(stateContext.MinNumberValue, newAluStateContext.MinNumberValue).ToString();
                        }
                        else
                        {
                            newAluStateContexts.Add(newAluStateContext);
                        }
                    }
                }

                aluStateContexts = newAluStateContexts;
            }

            var maxValue = long.MinValue;
            minValue = long.MaxValue;
            foreach (var aluStateContext in aluStateContexts)
            {
                if (aluStateContext.AluState.Z == 0)
                {
                    if (aluStateContext.MaxNumberValue > maxValue)
                    {
                        maxValue = aluStateContext.MaxNumberValue;
                    }
                    if (aluStateContext.MinNumberValue < minValue)
                    {
                        minValue = aluStateContext.MinNumberValue;
                    }
                }
            }


            return maxValue.ToString();
        }

        public string SolvePartTwo()
        {
            return minValue.ToString();
        }
    }
}
