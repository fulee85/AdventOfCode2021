namespace Day19BeaconScanner
{
    public class Matrix
    {
        public int[,] values = new int[3, 3];

        public Matrix()
        {

        }

        public void SetX(int x, bool negate)
        {
            values[0, x] = negate ? -1 : 1;
        }

        public void SetY(int y, bool negate)
        {
            values[1, y] = negate ? -1 : 1;
        }

        public void SetZ(int z, bool negate)
        {
            values[2, z] = negate ? -1 : 1;
        }
    }
}
