using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23Amphipod.Amphipods
{
    public abstract class Amphipod
    {
        public Amphipod(int x, int y, char selector, ConsoleColor color)
        {
            X = x;
            Y = y;
            Selector = selector;
            Color = color;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public char Selector { get; }
        public ConsoleColor Color { get; }
        public abstract int StepEnergy { get; } 
        public abstract char ShowChar { get; } 
    }
}
