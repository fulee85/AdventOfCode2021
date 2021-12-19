using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19BeaconScanner
{
    public class Scanner
    {
        private readonly int id;
        private readonly List<Beacon> beacons;
        private readonly Dictionary<long, List<BeaconPair>> beaconPairs = new();

        public IEnumerable<Beacon> Beacons => beacons;

        public bool IsTransformed { get; set; } = false;
        public int Id => id;

        public Vector Vector { get; set; }

        public Scanner(int id, List<Beacon> beacons)
        {
            this.id = id;
            this.beacons = beacons;
            for (int i = 0; i < beacons.Count - 1; i++)
            {
                for (int j = i + 1; j < beacons.Count; j++)
                {
                    var distance = beacons[i].Distance(beacons[j]);
                    if (!beaconPairs.ContainsKey(distance))
                    {
                        beaconPairs[distance] = new List<BeaconPair>();
                    }
                    beaconPairs[distance].Add(new BeaconPair(beacons[i].Distance(beacons[j]), beacons[i], beacons[j]));
                }
            }
        }

        public bool CanOverlapWith(Scanner other)
        {
            var matchingDistanceCount = 0;
            foreach (var beaconPair in beaconPairs)
            {
                var overlapCount = other.MatchingPairsCount(beaconPair.Key, beaconPair.Value.Count);
                matchingDistanceCount += overlapCount;
            }

            return matchingDistanceCount >= 66; // 12 * (12 - 1) / 2
        }

        private int MatchingPairsCount(long beaconPairDist, int count)
        {
            if (beaconPairs.TryGetValue(beaconPairDist, out var beaconPairList))
            {
                return Math.Min(count, beaconPairList.Count);
            }

            return 0;
        }

        public void TransformBeacons(int i)
        {
            if (IsTransformed)
            {
                return;
            }

            var matchingPairsEnumerator = GetMatchingPairs(beacons, i).GetEnumerator();
            matchingPairsEnumerator.MoveNext();
            var firstMatch = matchingPairsEnumerator.Current;
            matchingPairsEnumerator.MoveNext();
            var secondMatch = matchingPairsEnumerator.Current;
            var differenceVectorAbsolut = Beacon.GetDiffernceVector(firstMatch.abs, secondMatch.abs); 
            var differenceVectorRelative = Beacon.GetDiffernceVector(firstMatch.rel, secondMatch.rel);

            var transformationMatrix = new Matrix();
            while (!TryCalculateTransformationMatrix(differenceVectorAbsolut, differenceVectorRelative, transformationMatrix))
            {
                matchingPairsEnumerator.MoveNext();
                secondMatch = matchingPairsEnumerator.Current;
                differenceVectorAbsolut = Beacon.GetDiffernceVector(firstMatch.abs, secondMatch.abs);
                differenceVectorRelative = Beacon.GetDiffernceVector(firstMatch.rel, secondMatch.rel);
            }

            beacons.ForEach(b => b.TransformCoordinates(transformationMatrix));

            var shiftVector = CalculateShiftVector(firstMatch);
            Vector = shiftVector;

            beacons.ForEach(b => b.ShiftCoordinates(shiftVector));

            IsTransformed = true;
        }

        private Vector CalculateShiftVector((Beacon abs, Beacon rel) firstMatch)
        {
            return new Vector(firstMatch.abs.X - firstMatch.rel.X, firstMatch.abs.Y - firstMatch.rel.Y, firstMatch.abs.Z - firstMatch.rel.Z);
        }

        private bool TryCalculateTransformationMatrix(Vector differenceVectorAbsolut, Vector differenceVectorRelative, Matrix transformationMatrix)
        {
            if (differenceVectorAbsolut.AbsX == differenceVectorAbsolut.AbsY || 
                differenceVectorAbsolut.AbsY == differenceVectorAbsolut.AbsZ ||
                differenceVectorAbsolut.AbsX == differenceVectorAbsolut.AbsZ)
            {
                return false;
            }

            if (differenceVectorAbsolut.AbsX == differenceVectorRelative.AbsX)
            {
                transformationMatrix.SetX(0, differenceVectorAbsolut.X != differenceVectorRelative.X);
            }
            else if (differenceVectorAbsolut.AbsX == differenceVectorRelative.AbsY)
            {
                transformationMatrix.SetX(1, differenceVectorAbsolut.X != differenceVectorRelative.Y);
            }
            else if (differenceVectorAbsolut.AbsX == differenceVectorRelative.AbsZ)
            {
                transformationMatrix.SetX(2, differenceVectorAbsolut.X != differenceVectorRelative.Z);
            }
            else
            {
                throw new ArgumentException();
            }

            if (differenceVectorAbsolut.AbsY == differenceVectorRelative.AbsX)
            {
                transformationMatrix.SetY(0, differenceVectorAbsolut.Y != differenceVectorRelative.X);
            }
            else if (differenceVectorAbsolut.AbsY == differenceVectorRelative.AbsY)
            {
                transformationMatrix.SetY(1, differenceVectorAbsolut.Y != differenceVectorRelative.Y);
            }
            else if (differenceVectorAbsolut.AbsY == differenceVectorRelative.AbsZ)
            {
                transformationMatrix.SetY(2, differenceVectorAbsolut.Y != differenceVectorRelative.Z);
            }
            else
            {
                throw new ArgumentException();
            }

            if (differenceVectorAbsolut.AbsZ == differenceVectorRelative.AbsX)
            {
                transformationMatrix.SetZ(0, differenceVectorAbsolut.Z != differenceVectorRelative.X);
            }
            else if (differenceVectorAbsolut.AbsZ == differenceVectorRelative.AbsY)
            {
                transformationMatrix.SetZ(1, differenceVectorAbsolut.Z != differenceVectorRelative.Y);
            }
            else if (differenceVectorAbsolut.AbsZ == differenceVectorRelative.AbsZ)
            {
                transformationMatrix.SetZ(2, differenceVectorAbsolut.Z != differenceVectorRelative.Z);
            }
            else
            {
                throw new ArgumentException();
            }

            return true;
        }

        private IEnumerable<(Beacon abs, Beacon rel)> GetMatchingPairs(List<Beacon> beacons, int i)
        {
            foreach (var beacon in beacons)
            {
                var absolute = beacon.GetMatchWith(i);
                if (absolute == null) continue;
                var relative = beacon;
                
                yield return (absolute, relative);
            }
        }

        public void DoOverlapWith(Scanner otherScanner)
        {
            foreach (var beaconPair in beaconPairs)
            {
                if (otherScanner.beaconPairs.TryGetValue(beaconPair.Key, out var otherPairs))
                {
                    foreach (var otherBeaconPair in otherPairs)
                    {
                        foreach (var thisBeaconPair in beaconPair.Value)
                        {
                            thisBeaconPair.MatchWith(otherBeaconPair, otherScanner.id);
                            otherBeaconPair.MatchWith(thisBeaconPair, this.id);
                        }
                    }
                }
            }
        }
    }
}
