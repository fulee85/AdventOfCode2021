using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11_DumboOctopus
{
    public class OctopusSwarm
    {
        private readonly List<List<Octopus>> swarm = new List<List<Octopus>>();

        public OctopusSwarm(IEnumerable<string> input)
        {
            swarm = input.Select(line => line.Select(ch => new Octopus(int.Parse(ch.ToString()))).ToList()).ToList();
            CreateOctopusConnections();
        }

        private void CreateOctopusConnections()
        {
            for (int row = 0; row < swarm.Count; row++)
            {
                for (int col = 0; col < swarm[0].Count; col++)
                {
                    if (row > 0)
                    {
                        swarm[row][col].AddAdjacentOctopus(swarm[row - 1][col]);
                        swarm[row - 1][col].AddAdjacentOctopus(swarm[row][col]);
                    }
                    if (col > 0)
                    {
                        swarm[row][col].AddAdjacentOctopus(swarm[row][col - 1]);
                        swarm[row][col - 1].AddAdjacentOctopus(swarm[row][col]);
                    }
                    if (col > 0 && row > 0)
                    {
                        swarm[row][col].AddAdjacentOctopus(swarm[row - 1][col - 1]);
                        swarm[row - 1][col - 1].AddAdjacentOctopus(swarm[row][col]);
                    }
                    if (row > 0 && col + 1 < swarm[0].Count)
                    {
                        swarm[row][col].AddAdjacentOctopus(swarm[row - 1][col + 1]);
                        swarm[row - 1][col + 1].AddAdjacentOctopus(swarm[row][col]);
                    }
                }
            }
        }

        public int GetFlashCount(int steps)
        {
            var flashCount = 0;
            for (int i = 0; i < steps; i++)
            {
                swarm.ForEach(ol => ol.ForEach(o => o.IncreaseEnergyLevel()));
                swarm.ForEach(ol => ol.ForEach(o => flashCount += o.ResetEneryLevel()));
            }

            return flashCount;
        }

        public int FirstStepWhenAllOctopusFlashes()
        {
            var stepCount = 0;
            bool allOctopusFlash = false;
            while (!allOctopusFlash)
            {
                stepCount++;
                var flashCount = 0;
                swarm.ForEach(ol => ol.ForEach(o => o.IncreaseEnergyLevel()));
                swarm.ForEach(ol => ol.ForEach(o => flashCount += o.ResetEneryLevel()));

                allOctopusFlash = flashCount == 100;
            }

            return stepCount;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var line in swarm)
            {
                sb.Append(string.Concat(line.Select(o => o.ToString())) + Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
