using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24ArithmeticLogicUnit.Instructions
{
    public class InstructionFactory
    {
        private readonly Input input;

        public InstructionFactory(Input input)
        {
            this.input = input;
        }

        int inputInstructionCounter = 0;

        public List<List<IInstruction>> CreateInstructionsLists(IEnumerable<string> instructionsInput) 
        {

            var instructionLists = new List<List<IInstruction>>();
            List<IInstruction> instructionList = new List<IInstruction>();
            foreach (var instructionString in instructionsInput)
            {
                var instruction = CreateInstruction(instructionString);
                if (instruction is Inp)
                {
                    if (instructionList.Any())
                    {
                        instructionLists.Add(instructionList);
                        instructionList = new List<IInstruction>();
                    }
                }
                instructionList.Add(instruction);
            }
            instructionLists.Add(instructionList);

            return instructionLists;
        }

        private IInstruction CreateInstruction(string instructionString)
        {
            var instructionParts = instructionString.Split().ToArray();
            string action = instructionParts[0];

            return action switch
            {
                "inp" => new Inp(instructionParts[1], input, inputInstructionCounter++),
                "add" => new Add(instructionParts[1], instructionParts[2]),
                "mul" => new Mul(instructionParts[1], instructionParts[2]),
                "div" => new Div(instructionParts[1], instructionParts[2]),
                "mod" => new Mod(instructionParts[1], instructionParts[2]),
                "eql" => new Eql(instructionParts[1], instructionParts[2]),
                _ => throw new NotImplementedException(action)
            };
        }
    }
}
