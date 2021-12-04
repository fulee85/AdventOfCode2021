namespace Day04_GiantSquid;

public class BingoTable
{
    private readonly List<List<BingoField>> bingoFields;

    public BingoTable(List<List<int>> numbers)
    {
        this.bingoFields = numbers.Select(row => row.Select(num => new BingoField(num, false)).ToList()).ToList();
    }

    public void MarkNumber(int number)
    {
        foreach (var row in bingoFields)
        {
            foreach (var bingoField in row)
            {
                if (bingoField.Number == number)
                {
                    bingoField.IsMarked = true;
                }
            }
        }
    }

    public bool HasBingo()
    {
        for (int column = 0; column < 5; column++)
        {
            bool allMarked = true;
            for (int row = 0; row < 5; row++)
            {
                if (!bingoFields[row][column].IsMarked)
                {
                    allMarked = false;
                }
            }

            if (allMarked == true)
                return true;
        }

        return bingoFields.Any(rows => rows.All(field => field.IsMarked));
    }

    public int GetScore()
    {
        var score = 0;
        foreach (var row in bingoFields)
        {
            foreach (var bingoField in row)
            {
                if (!bingoField.IsMarked)
                {
                    score += bingoField.Number;
                }
            }
        }

        return score;
    }
}
