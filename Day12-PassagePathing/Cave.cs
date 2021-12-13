using System.Text;

namespace Day12_PassagePathing
{
    public class Cave
    {
        private readonly string id;
        private List<Cave> connectedCaves = new List<Cave>();

        public Cave(string id)
        {
            this.id = id;
            IsSmallCave = id.All(char.IsLower);
        }

        public bool IsSmallCave { get; init; }

        internal void AddCave(Cave cave)
        {
            connectedCaves.Add(cave);
        }

        public override string ToString()
        {
            return id;
        }

        public int FindAllPaths(HashSet<Cave> caves)
        {
            if (id == "end")
            {
                return 1;
            }

            if (IsSmallCave && caves.Contains(this))
            {
                return 0;
            }

            var count = 0;
            foreach (var connectedCave in connectedCaves)
            {
                if (IsSmallCave)
                {
                    caves.Add(this);
                    count += connectedCave.FindAllPaths(caves);
                    caves.Remove(this);
                }
                else
                {
                    count += connectedCave.FindAllPaths(caves);
                }
            }

            return count;
        }

        public static HashSet<string> sb = new();

        internal int FindAllExtraPaths(HashSet<Cave> containsOnce, HashSet<Cave> containsTwice, List<string> Path = null)
        {
            if (Path == null )
            {
                Path = new List<string>();
            }

            if (id == "end")
            {
                sb.Add("start," + string.Join(',', Path) + ",end");
                return 1;
            }

            if (id == "start")
            {
                if (containsOnce.Contains(this))
                {
                    return 0;
                }
                else
                {
                    containsOnce.Add(this);
                    connectedCaves.ForEach(c => c.FindAllExtraPaths(containsOnce, containsTwice, Path));
                    Console.WriteLine(string.Join(Environment.NewLine, sb));
                    return sb.Count;
                }
            }

            if (IsSmallCave && containsOnce.Contains(this) && containsTwice.Any())
            {
                return 0;
            }

            var count = 0;
            foreach (var connectedCave in connectedCaves)
            {
                Path.Add(this.id);

                if (IsSmallCave)
                {
                    if (containsOnce.Contains(this))
                    {
                        containsTwice.Add(this);
                    }
                    else
                    {
                        containsOnce.Add(this);
                    }

                    count += connectedCave.FindAllExtraPaths(containsOnce, containsTwice, Path);

                    if (containsTwice.Contains(this))
                    {
                        containsTwice.Remove(this);
                    }
                    else
                    {
                        containsOnce.Remove(this);
                    }
                }
                else
                {
                    count += connectedCave.FindAllExtraPaths(containsOnce, containsTwice, Path);
                }

                Path.RemoveAt(Path.Count - 1);
            }

            return count;
        }
    }
}
