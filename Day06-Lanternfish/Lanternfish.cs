namespace Day06_Lanternfish;

public class Lanternfish
{
    private int internalTimer;
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

        long descendantCount = 0;
        int daysToLiveYet = daysToLive;
        if (daysToLiveYet <= internalTimer)
        {
            return 0;
        }

        daysToLiveYet -= internalTimer + 1;
        descendantCount++;
        var firstDescendant = new Lanternfish(daysToLiveYet);
        descendantCount += firstDescendant.GetAllDescendantCount();

        while (daysToLiveYet >= 7)
        {
            daysToLiveYet -= 7;
            descendantCount++;
            var descendant = new Lanternfish(daysToLiveYet);
            descendantCount += descendant.GetAllDescendantCount();
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
