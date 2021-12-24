using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23Amphipod.Amphipods
{
    public class CopperAmphipod : Amphipod
    {
        public CopperAmphipod(int x, int y, char selector, ConsoleColor color) : base(x, y, selector, color)
        {
        }

        public override int StepEnergy => 100;

        public override char ShowChar => 'C';
    }
}
