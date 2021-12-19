using Day19BeaconScanner;
using System.Text;

namespace Day19_BeaconScanner
{
    public class Solver
    {
        private readonly List<Scanner> scanners = new List<Scanner>();
        public Solver(IEnumerable<string> input)
        {
            var inputEnumerator = input.GetEnumerator();
            Scanner scanner;
            while (inputEnumerator.MoveNext())
            {
                if (inputEnumerator.Current.StartsWith("---"))
                {
                    var beacons = new List<Beacon>();
                    
                    while (inputEnumerator.MoveNext() && !string.IsNullOrEmpty(inputEnumerator.Current))
                    {
                        var parts = inputEnumerator.Current.Split(',').Select(int.Parse).ToArray();
                        var beacon = new Beacon(parts[0],parts[1],parts[2]);
                        beacons.Add(beacon);
                    }

                    scanner = new Scanner(scanners.Count, beacons);
                    scanners.Add(scanner);
                }
            }
        }

        public string SolvePartOne()
        {
            // Find pair of scanners with overlapping regions with 12 beacons

            scanners[0].IsTransformed = true;
            scanners[0].Vector = new Vector(0, 0, 0);
            var transformedScannersQueue = new Queue<Scanner>();
            transformedScannersQueue.Enqueue(scanners[0]);
            var notTransformedScanners = new HashSet<Scanner>(scanners.Skip(1));
            while (notTransformedScanners.Count > 0 && transformedScannersQueue.Count > 0)
            {
                var transformedScanner = transformedScannersQueue.Dequeue();
                var newTransformedScanners = new List<Scanner>();
                foreach (var notTransformedScanner in notTransformedScanners)
                {
                    if (transformedScanner.CanOverlapWith(notTransformedScanner))
                    {
                        transformedScanner.DoOverlapWith(notTransformedScanner);
                        notTransformedScanner.TransformBeacons(transformedScanner.Id);
                        transformedScannersQueue.Enqueue(notTransformedScanner);
                        newTransformedScanners.Add(notTransformedScanner);
                    }
                }

                notTransformedScanners.ExceptWith(newTransformedScanners);
            }


            scanners[0].IsTransformed = true;
            for (int i = 0; i < scanners.Count - 1; i++)
            {
                for (int j = i + 1; j < scanners.Count; j++)
                {
                    if (scanners[i].CanOverlapWith(scanners[j]))
                    {
                        scanners[i].DoOverlapWith(scanners[j]);
                        if (scanners[i].IsTransformed)
                        {
                            scanners[j].TransformBeacons(i);
                        }
                        else if (scanners[j].IsTransformed)
                        {
                            scanners[i].TransformBeacons(j);
                        }
                        else
                        {
                            throw new Exception("");
                        }
                    }
                }
            }

            var vectors = new HashSet<Vector>();
            foreach (var scanner in scanners)
            {
                foreach (var vector in scanner.Beacons.Select(b => b.Vector))
                {
                    vectors.Add(vector);
                }
            }

            return vectors.Count.ToString();
        }

        public string SolvePartTwo()
        {
            SolvePartOne();

            var maxDist = int.MinValue;
            for (int i = 0; i < scanners.Count - 1; i++)
            {
                for (int j = i; j < scanners.Count; j++)
                {
                    var dist = Vector.CalculateManhattanDistance(scanners[i].Vector, scanners[j].Vector);
                    if (maxDist < dist)
                    {
                        maxDist = dist;
                    }
                }
            }

            return maxDist.ToString();
        }
    }
}
