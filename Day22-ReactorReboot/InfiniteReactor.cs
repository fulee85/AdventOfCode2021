namespace Day22ReactorReboot
{
    public class InfiniteReactor
    {
        private Dictionary<int, List<SmartCuboid>> cuboidSets = new Dictionary<int, List<SmartCuboid>>();

        public InfiniteReactor(SmartCuboid first)
        {
            cuboidSets[1] = new List<SmartCuboid> { first };
        }

        public void MakeStep(SmartCuboid smartCuboid)
        {
            var previousIntersects = smartCuboid.On ? new List<SmartCuboid> { smartCuboid } : new List<SmartCuboid>();
            int i = 1;
            for (; i <= cuboidSets.Keys.Count; i++)
            {
                var newIntersects=new List<SmartCuboid>();
                for (int j = 0; j < cuboidSets[i].Count; j++)
                {
                    var cuboid = cuboidSets[i][j];
                    var intersectCuboid = smartCuboid.Intersect(cuboid);
                    if (intersectCuboid != SmartCuboid.EmptyCuboid)
                    {
                        if (i == 1)
                        {
                            if (smartCuboid.On && smartCuboid == intersectCuboid)
                            {
                                return;
                            }
                            else if (cuboid == intersectCuboid)
                            {
                                cuboidSets[i][j] = SmartCuboid.EmptyCuboid;
                                RemoveCuboidIntersects(cuboid.Id);
                            }
                            else
                            {
                                newIntersects.Add(intersectCuboid);
                            }
                        }
                        else
                        {
                            newIntersects.Add(intersectCuboid);
                        }
                    }
                }

                if (i == 1)
                {
                    cuboidSets[i] = cuboidSets[i].Where(c => c != SmartCuboid.EmptyCuboid).ToList();
                }
                cuboidSets[i].AddRange(previousIntersects);
                previousIntersects = newIntersects;
            }

            if (previousIntersects.Any())
            {
                cuboidSets[i] = previousIntersects;
            }
        }

        private void RemoveCuboidIntersects(string id)
        {
            for (int i = 2; i <= cuboidSets.Keys.Count; i++)
            {
                cuboidSets[i] = cuboidSets[i].Where(cs => cs.NotContainsId(id)).ToList();
            }
        }

        public string GetOnCubeCount()
        {
            int sign = 1;

            long count = 0L;
            for(int i = 1;i <= cuboidSets.Keys.Count; i++)
            {
                foreach (var cuboid in cuboidSets[i])
                {
                    count += sign * cuboid.GetSize();
                }
                sign *= -1;
            }

            return count.ToString();
        }
    }
}
