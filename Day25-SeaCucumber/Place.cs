namespace Day25SeaCucumber
{
    public class Place
    {
        public Place(char ch)
        {
            Ch = ch;
        }

        private Place LeftPlace { get; set; }

        private Place TopPlace { get; set; }

        private char Ch { get; set; }

        private char NextCh { get; set; }

        public bool IsEmpty => Ch == '.';

        public override string ToString()
        {
            return Ch.ToString();
        }

        public void SetNeighbours(List<List<Place>> floorPlaces, int row, int column)
        {
            if (column == 0)
            {
                LeftPlace = floorPlaces[row][^1];
            }
            else
            {
                LeftPlace = floorPlaces[row][column - 1];
            }

            if (row == 0)
            {
                TopPlace = floorPlaces[^1][column];
            }
            else
            {
                TopPlace= floorPlaces[row - 1][column];
            }
        }

        public IEnumerable<Place> MakeStep()
        {
            if (LeftPlace.Ch == '>')
            {
                if (LeftPlace.TopPlace.Ch == 'v')
                {
                    LeftPlace.TopPlace.NextCh = '.';
                    yield return LeftPlace.TopPlace;
                    LeftPlace.NextCh = 'v';
                    yield return LeftPlace;
                    this.NextCh = '>';
                    yield return this;
                }
                else
                {
                    LeftPlace.NextCh = '.';
                    yield return LeftPlace;
                    this.NextCh = '>';
                    yield return this;
                }
            }
            else if (TopPlace.Ch == 'v')
            {
                TopPlace.NextCh = '.';
                yield return TopPlace;
                this.NextCh = 'v';
                yield return this;
            }
            yield break;
        }

        internal void MakeChange()
        {
            Ch = NextCh;
        }
    }
}
