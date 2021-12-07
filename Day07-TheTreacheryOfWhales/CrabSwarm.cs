namespace Day07_TheTreacheryOfWhales
{
    public class CrabSwarm
    {
        private readonly List<int> crabPositions;
        private readonly List<CrabSubmarine> crabSubmarines;

        public CrabSwarm(IEnumerable<int> crabPositions)
        {
            this.crabPositions = crabPositions.ToList();
            crabSubmarines = crabPositions.Select(c => new CrabSubmarine(c)).ToList();
        }

        public int GetAlignPosition()
        {
            var dict = new SortedDictionary<int, int>();
            foreach (var crabPosition in crabPositions)
            {
                if (dict.ContainsKey(crabPosition))
                {
                    dict[crabPosition]++;
                }
                else
                {
                    dict.Add(crabPosition, 1);
                }
            }

            var crabsBeforeActual = 0;
            var crabsActual = 0;
            var crabsAfterActual = crabPositions.Count;
            var minDifference = int.MaxValue;
            var minPosition = 0;
            foreach (KeyValuePair<int, int> item in dict)
            {
                crabsBeforeActual += crabsActual;
                crabsActual = item.Value;
                crabsAfterActual -= crabsActual;
                var actualDifference = Math.Abs(crabsAfterActual - crabsBeforeActual);
                if (actualDifference <= minDifference)
                {
                    minDifference = actualDifference;
                    minPosition = item.Key;
                }
                else
                {
                    return minPosition;
                }
            }

            return minPosition;
        }

        public int GetFuelConsumtionToPosition(int position)
        {
            return crabPositions.Sum(cp => Math.Abs(cp - position));
        }

        public int GetMinFuelConsumption()
        {
            var position = crabPositions.Min();
            var minConsumtion = int.MaxValue;

            var fuelConsumption = crabSubmarines.Sum(csm => csm.GetStepCost(position));
            while (fuelConsumption < minConsumtion)
            {
                minConsumtion = fuelConsumption;
                position++;
                fuelConsumption = crabSubmarines.Sum(csm => csm.GetStepCost(position));
            }

            return minConsumtion;
        }
    }
}
