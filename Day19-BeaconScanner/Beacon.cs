namespace Day19BeaconScanner
{
    public class Beacon
    {
        private int x;
        private int y;
        private int z;

        private Dictionary<int, HashSet<Beacon>> CanMatchingBeacons = new Dictionary<int, HashSet<Beacon>>();

        public int X => x;
        public int Y => y;
        public int Z => z;

        public Beacon(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public long Distance(Beacon other)
        {
            return (other.x - this.x) * (other.x - this.x) + (other.y - this.y) * (other.y - this.y) + (other.z - this.z) * (other.z - this.z);
        }

        public void MatchWith(int id, params Beacon[] other)
        {
            if (!CanMatchingBeacons.ContainsKey(id))
            {
                CanMatchingBeacons[id] = new HashSet<Beacon>(other);
            }
            else
            {
                CanMatchingBeacons[id].IntersectWith(other);
            }
        }

        public override string ToString()
        {
            var s = string.Join(',', x, y, z);
            if (CanMatchingBeacons is not null)
            {
                s += " Matching: ";
                foreach (var match in CanMatchingBeacons)
                {
                    s += $"({match.Key})" + string.Join(',', match.Value.First().x, match.Value.First().y, match.Value.First().z) + " / ";
                }
            }

            return s;
        }

        public static Vector GetDiffernceVector(Beacon first, Beacon second)
        {
            return new Vector(first.x - second.x, first.y - second.y, first.z - second.z);
        } 

        public void TransformCoordinates(Matrix matrix)
        {
            var xNew = matrix.values[0,0] * x + matrix.values[0, 1] * y + matrix.values[0, 2] * z;
            var yNew = matrix.values[1,0] * x + matrix.values[1, 1] * y + matrix.values[1, 2] * z;
            var zNew = matrix.values[2,0] * x + matrix.values[2, 1] * y + matrix.values[2, 2] * z;
            x = xNew;
            y = yNew;
            z = zNew;
        }

        internal Beacon? GetMatchWith(int i)
        {
            if (CanMatchingBeacons.ContainsKey(i))
            {
                return CanMatchingBeacons[i].First();
            }

            return null;
        }

        public void ShiftCoordinates(Vector vector)
        {
            x += vector.X;
            y += vector.Y;
            z += vector.Z;
        }

        public Vector Vector => new Vector(x, y, z);
    }
}
