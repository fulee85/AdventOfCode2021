namespace Day19BeaconScanner
{
    public class Vector
    {
        public Vector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public int AbsX => Math.Abs(X);
        public int AbsY => Math.Abs(Y);
        public int AbsZ => Math.Abs(Z);

        public override int GetHashCode()
        {
            return X ^ Y ^ Z;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is not Vector other)
            {
                return false;
            }

            return other.X == this.X && other.Y == this.Y && other.Z == this.Z;
        }

        public override string ToString()
        {
            return string.Join(',', X, Y, Z);
        }

        public static int CalculateManhattanDistance(Vector v1, Vector v2)
        {
            return Math.Abs(v1.X - v2.X) + Math.Abs(v1.Y - v2.Y) + Math.Abs(v1.Z - v2.Z);
        }
    }
}
