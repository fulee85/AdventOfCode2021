using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23Amphipod.Amphipods
{
    public class DesertAmphipod : Amphipod
    {
        public DesertAmphipod(int x, int y, char selector, ConsoleColor color) : base(x, y, selector, color)
        {
        }

        public override int StepEnergy => 1000;

        public override char ShowChar => 'D';
    }
}
