namespace Day11_DumboOctopus
{
    public class Octopus
    {
        private int energyLevel;
        private readonly List<Octopus> adjacentOctopuses = new List<Octopus>();

        public Octopus(int energyLevel)
        {
            this.energyLevel = energyLevel;
        }

        public void AddAdjacentOctopus(Octopus adjacentOctopuse) => adjacentOctopuses.Add(adjacentOctopuse);

        public void IncreaseEnergyLevel()
        {
            energyLevel++;
            if (energyLevel == 10)
            {
                adjacentOctopuses.ForEach(o => o.IncreaseEnergyLevel());
            }
        }

        public int ResetEneryLevel()
        {
            if (energyLevel >= 10)
            {
                energyLevel = 0;
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            return energyLevel.ToString(); 
        }
    }
}
