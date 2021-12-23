namespace Day22ReactorReboot
{
    public class Reactor
    {
        private readonly int[,,] cubes = new int[101, 101, 101];

        public void SetCubeOn(int x, int y, int z)
        {
            cubes[x + 50, y + 50, z + 50] = 1;
        }

        public void SetCubeOff(int x, int y, int z)
        {
            cubes[x + 50, y + 50, z + 50] = 0;
        }

        public int OnCubesCount => cubes.Cast<int>().Sum();
    }
}
