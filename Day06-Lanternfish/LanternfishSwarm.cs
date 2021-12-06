namespace Day06_Lanternfish;

public class LanternfishSwarm
{
    private List<Lanternfish> lanternfishes;

    public LanternfishSwarm(IEnumerable<int> input, int days)
    {
        lanternfishes = input.Select(n => new Lanternfish(n, days)).ToList();
    }

    public long RunSimulation()
    {
        long fishCount = 0;

        foreach (var lanternfish in lanternfishes)
        {
            fishCount++;
            checked { fishCount += lanternfish.GetAllDescendantCount(); }
        }

        return fishCount;
    }
}
