using System.Text.RegularExpressions;

namespace Day17_TrickShot
{
    public class Solver
    {
        private int x0, y0;
        private int x1, y1;

        public Solver(IEnumerable<string> input)
        {
            var inputLine = input.First();
            var inputPattern = new Regex(@"target area: x=(?<x0>\d*)\.\.(?<x1>\d*), y=(?<y1>-\d*)\.\.(?<y0>-\d*)");
            var match = inputPattern.Match(inputLine);
            x0 = int.Parse(match.Groups["x0"].Value);
            x1 = int.Parse(match.Groups["x1"].Value);
            y0 = int.Parse(match.Groups["y0"].Value);
            y1 = int.Parse(match.Groups["y1"].Value);
        }

        public string SolvePartOne()
        {
            var yMaxVelocity = Math.Abs(y1) - 1;
            return ((yMaxVelocity * (yMaxVelocity + 1)) / 2).ToString();
        }

        public string SolvePartTwo()
        {
            var xMaxVelocity = x1;
            var xMinVelocity = (int)Math.Sqrt(x0 * 2);
            var yMaxVelocity = Math.Abs(y1) - 1;
            var yMinVelocity = y1;

            var result = 0;
            for (int xVelocity = xMinVelocity; xVelocity <= xMaxVelocity; xVelocity++)
            {
                for (int yVelocity = yMinVelocity; yVelocity <= yMaxVelocity; yVelocity++)
                {
                    if (CanReachAim(xVelocity, yVelocity))
                    {
                        result++;
                    }
                }
            }

            return result.ToString();
        }

        private bool CanReachAim(int xVelocity, int yVelocity)
        {
            var xPos = 0;
            var yPos = 0;
            while (xPos < x0 || yPos > y0)
            {
                if (xPos > x1 || yPos < y1)
                {
                    return false;
                }
                xPos += xVelocity;
                yPos += yVelocity;

                if (xVelocity > 0)
                {
                    xVelocity--;
                }
                yVelocity--;
            }

            if (xPos > x1 || yPos < y1)
            {
                return false;
            }

            return true;
        }
    }
}
