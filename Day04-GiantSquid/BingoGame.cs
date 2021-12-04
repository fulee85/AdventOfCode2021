namespace Day04_GiantSquid
{
    public class BingoGame
    {
        private readonly List<int> drawnNumbers;
        private readonly List<BingoTable> bingoTables;

        public BingoGame(IEnumerable<string> input)
        {
            var enumerator = input.GetEnumerator();
            enumerator.MoveNext();

            drawnNumbers = enumerator.Current.Split(',').Select(int.Parse).ToList();

            bingoTables = new List<BingoTable>();

            while (enumerator.MoveNext())
            {
                var bingoTableNumbers = new List<List<int>>();
                for (int i = 0; i < 5; i++)
                {
                    enumerator.MoveNext();
                    bingoTableNumbers.Add(enumerator.Current.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
                }

                bingoTables.Add(new BingoTable(bingoTableNumbers));
            }
        }

        public int GetFirstWinningTableResult()
        {
            foreach (var drawnNumber in drawnNumbers)
            {
                foreach (var bingoTable in bingoTables)
                {
                    bingoTable.MarkNumber(drawnNumber);
                    if (bingoTable.HasBingo())
                    {
                        return checked(drawnNumber * bingoTable.GetScore());
                    }
                }
            }

            return 0;
        }

        public int GetLastWinningTableResult()
        {
            BingoTable lastWinningTable = bingoTables[0];
            var bingoTablesInGame = bingoTables;
            foreach (var drawnNumber in drawnNumbers)
            {
                var notYetWinningTables = new List<BingoTable>();
                foreach (var bingoTable in bingoTablesInGame)
                {
                    bingoTable.MarkNumber(drawnNumber);
                    if (bingoTable.HasBingo())
                    {
                        lastWinningTable = bingoTable;
                    }
                    else
                    {
                        notYetWinningTables.Add(bingoTable);
                    }
                }

                if (!notYetWinningTables.Any())
                {
                    return checked(drawnNumber * lastWinningTable.GetScore());
                }
                else
                {
                    bingoTablesInGame = notYetWinningTables;
                }
            }

            return 0;
        }
    }
}
