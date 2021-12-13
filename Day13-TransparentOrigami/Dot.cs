namespace Day13_TransparentOrigami
{
    public struct Dot
    {
        public Dot(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        internal Dot MirrorToY(int y)
        {
            return new Dot(X, y - (Y - y));
        }

        internal Dot MirrorToX(int x)
        {
            return new Dot(x - (X - x), Y);
        }
    }
}
