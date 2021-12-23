using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day22ReactorReboot
{
    public class Cuboid
    {
        protected readonly int x0;
        protected readonly int x1;
        protected readonly int y0;
        protected readonly int y1;
        protected readonly int z0;
        protected readonly int z1;
        protected readonly  string action;

        public Cuboid(string input)
        {
            var inputPattern = new Regex(@"^(?<action>\w*) x=(?<x0>-?\d*)\.\.(?<x1>-?\d*),y=(?<y0>-?\d*)\.\.(?<y1>-?\d*),z=(?<z0>-?\d*)\.\.(?<z1>-?\d*)");
            var match = inputPattern.Match(input);
            x0 = int.Parse(match.Groups["x0"].Value);
            x1 = int.Parse(match.Groups["x1"].Value);
            y0 = int.Parse(match.Groups["y0"].Value);
            y1 = int.Parse(match.Groups["y1"].Value);
            z0 = int.Parse(match.Groups["z0"].Value);
            z1 = int.Parse(match.Groups["z1"].Value);
            action = match.Groups["action"].Value;
        }

        protected Cuboid(int x0, int x1, int y0, int y1, int z0, int z1, string action)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.y0 = y0;
            this.y1 = y1;
            this.z0 = z0;
            this.z1 = z1;
            this.action = action;
        }

        public void ApplyStep(Reactor reactor)
        {
            for (int x = Math.Max(-50, x0); x <= Math.Min(50, x1); x++)
            {
                for (int y = Math.Max(-50, y0); y <= Math.Min(50, y1); y++)
                {
                    for (int z = Math.Max(-50, z0); z <= Math.Min(50, z1); z++)
                    {
                        if (action == "on")
                        {
                            reactor.SetCubeOn(x, y, z);
                        }
                        else
                        {
                            reactor.SetCubeOff(x, y, z);
                        }
                    }
                }
            }
        }
    }
}
