using System.Text;

namespace Day20TrenchMap
{
    public class Image
    {
        private readonly char[,] imageMap;
        private readonly char frameChar;

        public Image(List<List<char>> map, char frameChar)
        {
            imageMap = new char[map.Count + 2, map[0].Count + 2];

            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    if (row == 0 || column == 0 || row >= RowCount - 1 || column >= ColumnCount - 1)
                    {
                        imageMap[row, column] = frameChar;
                    }
                    else
                    {
                        imageMap[row,column] = map[row - 1][column - 1];
                    }
                }
            }

            this.frameChar = frameChar;
        }

        public int RowCount => imageMap.GetLength(0);
        public int ColumnCount => imageMap.GetLength(1);

        public char FrameChar => frameChar;

        public char GetChar(int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= RowCount || colIndex < 0 || colIndex >= ColumnCount)
            {
                return frameChar;
            }

            return imageMap[rowIndex, colIndex];
        }

        public int GetLitPixelsCount() => imageMap.Cast<char>().Count(ch => ch == '#');

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    sb.Append(GetChar(i,j));
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
