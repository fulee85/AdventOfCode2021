using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day09_SmokeBasin
{
    public class HeightMap
    {
        private List<(int row, int column)> lowestPoints = new List<(int,int)>();
        private readonly List<List<int>> heightMatrix;
        private int rowCount, columnCount;
        private bool[,] checkedPoints;

        public HeightMap(IEnumerable<string> input)
        {
            heightMatrix = input.Select(s => s.Select(ch => int.Parse(ch.ToString())).ToList()).ToList();
            rowCount = heightMatrix.Count;
            columnCount = heightMatrix[0].Count;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (IsLowPoint(i,j))
                    {
                        lowestPoints.Add((i,j));
                    }
                }
            }
        }

        public IEnumerable<int> GetLowPointsHeights()
        {
            return lowestPoints.Select(p => heightMatrix[p.row][p.column]);
        }

        public IEnumerable<int> GetBasinSizes()
        {
            checkedPoints = new bool[rowCount,columnCount];
            foreach (var (row,column) in lowestPoints)
            {
                yield return GetBasinSize(row, column);
            }
        }

        private int GetBasinSize(int row, int column)
        {
            if (row < 0 || column < 0 || row >= rowCount || column >= columnCount || heightMatrix[row][column] == 9 || checkedPoints[row,column])
            {
                return 0;
            }

            checkedPoints[row,column] = true;
            return 1 + GetBasinSize(row + 1, column) + GetBasinSize(row - 1, column) + GetBasinSize(row, column - 1) + GetBasinSize(row, column + 1);
        }

        private bool IsLowPoint(int i, int j)
        {
            var point = heightMatrix[i][j];
            return IsPointSmallerThan(point, i + 1, j) &&
                   IsPointSmallerThan(point, i - 1, j) &&
                   IsPointSmallerThan(point, i, j + 1) &&
                   IsPointSmallerThan(point, i, j - 1);
        }

        private bool IsPointSmallerThan(int point, int row, int col)
        {
             return row < 0 || row >= rowCount || col < 0 || col >= columnCount || point < heightMatrix[row][col];
        }
    }
}
