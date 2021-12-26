namespace Day25SeaCucumber
{
    public class SeaFloor
    {
        private HashSet<Place> emptyPlaces = new();

        public SeaFloor(IEnumerable<string> input)
        {
            var floorPlaces = input.Select(l => l.Select(ch => new Place(ch)).ToList()).ToList();
            for (int row = 0; row < floorPlaces.Count; row++)
            {
                for (int column = 0; column < floorPlaces[0].Count; column++)
                {
                    floorPlaces[row][column].SetNeighbours(floorPlaces, row, column);
                    if (floorPlaces[row][column].IsEmpty)
                    {
                        emptyPlaces.Add(floorPlaces[row][column]);
                    }
                }
            }
        }

        public bool MakeStep()
        {
            var changedPlaces = new List<Place>();
            foreach (var emptyPlace in emptyPlaces)
            {
                changedPlaces.AddRange(emptyPlace.MakeStep());
            }

            if (changedPlaces.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var changedPlace in changedPlaces)
                {
                    if (changedPlace.IsEmpty)
                    {
                        emptyPlaces.Remove(changedPlace);
                    }

                    changedPlace.MakeChange();

                    if (changedPlace.IsEmpty)
                    {
                        emptyPlaces.Add(changedPlace);
                    }
                }
            }

            return true;
        }
    }
}
