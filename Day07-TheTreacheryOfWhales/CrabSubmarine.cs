namespace Day07_TheTreacheryOfWhales
{
    public class CrabSubmarine
    {
        private readonly int position;

        public CrabSubmarine(int position)
        {
            this.position = position;
        }

        public int GetStepCost(int goalPosition)
        {
            var n = Math.Abs(goalPosition - position);

            return n * (n + 1) / 2;
        }
    }
}
