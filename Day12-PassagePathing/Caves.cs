using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_PassagePathing
{
    public class Caves
    {
        private Cave startCave;
        private Cave endCave;
        private Dictionary<string, Cave> caves = new Dictionary<string, Cave>();


        public Caves(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                var lineParts = line.Split(new char[] { '-' });
                if (!caves.TryGetValue(lineParts[0], out var firstCave))
                {
                    firstCave = new Cave(lineParts[0]);
                    caves.Add(lineParts[0], firstCave);
                }
                if (!caves.TryGetValue(lineParts[1], out var secondCave))
                {
                    secondCave = new Cave(lineParts[1]);
                    caves.Add(lineParts[1], secondCave);
                }
                firstCave.AddCave(secondCave);
                secondCave.AddCave(firstCave);
            }
            startCave = caves["start"];
            endCave = caves["end"];
        }

        public int GetExtraPathCount()
        {
            return startCave.FindAllExtraPaths(new HashSet<Cave> { }, new HashSet<Cave> { });
        }

        public int GetPathCount()
        {
            return startCave.FindAllPaths(new HashSet<Cave>());
        }
    }
}
