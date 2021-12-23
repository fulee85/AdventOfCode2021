namespace Day22ReactorReboot
{
    public class SmartCuboid : Cuboid
    {
        private readonly HashSet<string> ids;

        public SmartCuboid(string input, string id) : base(input)
        {
            ids = new HashSet<string>();
            ids.Add(id);
        }

        public SmartCuboid(int x0, int x1, int y0, int y1, int z0, int z1, string action, HashSet<string> ids) : base(x0, x1, y0, y1, z0, z1, action)
        {
            this.ids = ids;
        }

        public string Id
        {
            get
            {
                if (ids.Count != 1)
                {
                    throw new Exception();
                }
                return ids.First();
            }
        }

        public bool On => action == "on";

        public SmartCuboid Intersect(SmartCuboid other)
        {
            return Create(
                Math.Max(x0, other.x0),
                Math.Min(x1, other.x1),
                Math.Max(y0, other.y0),
                Math.Min(y1, other.y1),
                Math.Max(z0, other.z0),
                Math.Min(z1, other.z1),
                this.action,
                new HashSet<string>(this.ids.Union(other.ids)));
        }

        public static readonly SmartCuboid EmptyCuboid = new SmartCuboid(1, -1, 1, -1, 1, -1, "", null);

        public static SmartCuboid Create(int x0, int x1, int y0, int y1, int z0, int z1, string action, HashSet<string> ids)
        {
            if (x1 < x0 || y1 < y0 || z1 < z0)
            {
                return EmptyCuboid;
            }
            else
            {
                return new SmartCuboid(x0, x1, y0, y1, z0, z1, action, ids);
            }
        }

        public long GetSize()
        {
            return (long)(x1 - x0 + 1) * (y1 - y0 + 1) * (z1 - z0 + 1);
        }

        public override int GetHashCode()
        {
            return x0 ^ x1 ^ y0 ^ y1 ^ z0 ^ z1;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj is not SmartCuboid sc)
                return false;
            return x0 == sc.x0 && x1 == sc.x1 && y0 == sc.y0 && y1 == sc.y1 && z0 == sc.z0 && z1 == sc.z1;
        }

        public bool NotContainsId(string id)
        {
            return !ids.Contains(id);
        }

        public override string ToString()
        {
            return string.Join('-', ids);
        }

        public static bool operator ==(SmartCuboid lhs, SmartCuboid rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(SmartCuboid lhs, SmartCuboid rhs) => !(lhs == rhs);
    }
}
