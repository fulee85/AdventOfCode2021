namespace Day06_Lanternfish;

public class Lanternfish
{
    private readonly int internalTimer;
    private readonly int daysToLive;

    private static readonly Dictionary<Lanternfish, long> descendantCountDict = new Dictionary<Lanternfish,long>();

    public Lanternfish(int daysToLive) : this(8, daysToLive)
    {
    }

    public Lanternfish(int internalTimer, int daysToLive)
    {
        this.internalTimer = internalTimer;
        this.daysToLive = daysToLive;
    }

    internal long GetAllDescendantCount()
    {
        if (descendantCountDict.ContainsKey(this))
        {
            return descendantCountDict[this];
        }

        int daysToLiveYet = daysToLive;
        if (daysToLiveYet <= internalTimer)
        {
            return 0;
        }
        daysToLiveYet -= internalTimer + 1;

        long descendantCount = 0;
        while (daysToLiveYet >= 0)
        {
            descendantCount++;
            var descendant = new Lanternfish(daysToLiveYet);
            descendantCount += descendant.GetAllDescendantCount();
            daysToLiveYet -= 7;
        }

        descendantCountDict.Add(this, descendantCount);
        return descendantCount;
    }

    public override int GetHashCode()
    {
        return internalTimer ^ daysToLive;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
            return false;
        if (obj is not Lanternfish lanternfish)
            return false;
            
        return lanternfish.internalTimer == this.internalTimer && lanternfish.daysToLive == this.daysToLive;
    }
}
