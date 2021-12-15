namespace Day15_Chiton
{
    public class Vertex
    {
        public Vertex(int x, int y, int riskLevel = 0)
        {
            X = x;
            Y = y;
            RiskLevel = riskLevel;
            Dist = int.MaxValue;
        }

        public int X { get; }
        public int Y { get; }
        public int RiskLevel { get; }

        public int Dist { get; set; }
        public Vertex? Previous { get; set; }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is not Vertex vertex)
            {
                return false;
            }

            return vertex.X == X && vertex.Y == Y;
        }
    }
}
