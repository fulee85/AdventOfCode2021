namespace Day19BeaconScanner
{
    public class BeaconPair
    {
        private readonly Beacon beacon1;
        private readonly Beacon beacon2;

        public BeaconPair(Beacon beacon1, Beacon beacon2)
        {
            Distance = beacon1.Distance(beacon2);
            this.beacon1 = beacon1;
            this.beacon2 = beacon2;
        }

        public long Distance { get; }

        public void MatchWith(BeaconPair otherBeaconPair, int id)
        {
            beacon1.MatchWith(id, otherBeaconPair.beacon1, otherBeaconPair.beacon2);
            beacon2.MatchWith(id, otherBeaconPair.beacon1, otherBeaconPair.beacon2);
        }
    }
}
