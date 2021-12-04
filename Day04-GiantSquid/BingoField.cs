namespace Day04_GiantSquid;

public class BingoField
{
    public BingoField(int number, bool isMarked)
    {
        Number = number;
        IsMarked = isMarked;
    }

    public int Number { get; init; }

    public bool IsMarked { get; set; }

    public override string ToString()
    {
        return $"n:{Number} m:{IsMarked}";
    }
}
