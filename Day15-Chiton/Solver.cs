namespace Day15_Chiton
{
    public class Solver
    {
        private readonly List<List<int>> riskLevels;
        private readonly int xCount, yCount;

        public Solver(IEnumerable<string> input)
        {
            riskLevels = input.Select(line => line.Select(ch => int.Parse(ch.ToString())).ToList()).ToList();
            xCount = riskLevels.Count;
            yCount = riskLevels[0].Count;
        }

        public string SolvePartOne()
        {
            return GetShortestDistance(1).ToString();
        }

        public string SolvePartTwo()
        {
            return GetShortestDistance(5).ToString();
        }

        private int GetShortestDistance(int multiplyer)
        {
            var set = new HashSet<Vertex>();
            for (int x = 0; x < xCount * multiplyer; x++)
            {
                for (int y = 0; y < yCount * multiplyer; y++)
                {
                    set.Add(new Vertex(x, y, GetRiskLevel(x,y)));
                }
            }

            set.TryGetValue(new Vertex(0, 0, 0), out var startVertex);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            startVertex.Dist = 0;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            var underWatch = new HashSet<Vertex>();
            underWatch.Add(startVertex);
            set.TryGetValue(new Vertex(xCount * multiplyer  - 1, yCount * multiplyer - 1), out var endVertex);

            while (underWatch.Any())
            {
                var u = underWatch.MinBy(v => v.Dist);
                set.Remove(u);
                underWatch.Remove(u);

                foreach (var neighbour in GetNeighboursStillInSet(u))
                {
                    var altDist = u.Dist + neighbour.RiskLevel;
                    if (altDist < neighbour.Dist)
                    {
                        neighbour.Dist = altDist;
                        neighbour.Previous = u;
                        underWatch.Add(neighbour);
                    }
                }
            }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return endVertex.Dist;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            IEnumerable<Vertex> GetNeighboursStillInSet(Vertex v)
            {
                Vertex? neighbour; 
                if (set.TryGetValue(new Vertex(v.X - 1, v.Y), out neighbour))
                {
                    yield return neighbour;
                }
                if (set.TryGetValue(new Vertex(v.X + 1, v.Y), out neighbour))
                {
                    yield return neighbour;
                }
                if (set.TryGetValue(new Vertex(v.X, v.Y - 1), out neighbour))
                {
                    yield return neighbour;
                }
                if (set.TryGetValue(new Vertex(v.X, v.Y + 1), out neighbour))
                {
                    yield return neighbour;
                }
            }
        }

        private int GetRiskLevel(int x, int y)
        {
            var diff = (x / xCount) + (y / yCount);
            
            var value = riskLevels[x % xCount][y % yCount] + diff;

            if (value > 9)
            {
                return value - 9;
            }

            return value;
        }
    }
}
