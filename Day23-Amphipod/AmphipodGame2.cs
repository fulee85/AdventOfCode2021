using Day23Amphipod.Amphipods;

namespace Day23Amphipod
{
    public class AmphipodGame2
    {
        private readonly List<List<char>> Goal = @"############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #A#B#C#D#
  #A#B#C#D#
  #########".Split(Environment.NewLine).Select(s => s.ToList()).ToList();
        private readonly int record;
        private List<List<char>> burrow;
        private int score = 0;
        private readonly Dictionary<(char colorCh, char typeCh), Amphipod> amphipods = new Dictionary<(char colorCh, char typeCh), Amphipod>();
        private readonly Dictionary<(int x, int y), Amphipod> amphipodPositions = new Dictionary<(int x, int y), Amphipod>();
        private readonly List<(char ch, ConsoleColor color)> helper = new List<(char, ConsoleColor)>
        {
            ('G',ConsoleColor.Green),
            ('R',ConsoleColor.Red),
            ('Y',ConsoleColor.Yellow),
            ('W',ConsoleColor.White),
        };

        public AmphipodGame2(IEnumerable<string> startInput, int record)
        {
            this.burrow = startInput.Select(s => s.ToList()).ToList();
            this.record = record;
            var helperIndexA = 0;
            var helperIndexB = 0;
            var helperIndexC = 0;
            var helperIndexD = 0;
            for (int x = 0; x < burrow.Count; x++)
            {
                for (int y = 0; y < burrow[x].Count; y++)
                {
                    switch (burrow[x][y])
                    {
                        case 'A':
                            (var ch, var color) = helper[helperIndexA++];
                            Amphipod ap = new AmberAmphipod(x, y, ch, color);
                            amphipods[(ch, 'A')] = ap;
                            amphipodPositions.Add((x, y), ap);
                            break;
                        case 'B':
                            (ch, color) = helper[helperIndexB++];
                            ap = new BronzeAmphipod(x, y, ch, color);
                            amphipods[(ch, 'B')] = ap;
                            amphipodPositions.Add((x, y), ap);
                            break;
                        case 'C':
                            (ch, color) = helper[helperIndexC++];
                            ap = new CopperAmphipod(x, y, ch, color);
                            amphipods[(ch, 'C')] = ap;
                            amphipodPositions.Add((x, y), ap);
                            break;
                        case 'D':
                            (ch, color) = helper[helperIndexD++];
                            ap = new DesertAmphipod(x, y, ch, color);
                            amphipods[(ch, 'D')] = ap;
                            amphipodPositions.Add((x, y), ap);
                            break;
                        default:
                            break;
                    }
                }
            }

            currentAmphipod = amphipods[('G', 'A')];
        }

        public int Play()
        {
            while (!IsGameEnded())
            {
                ShowGame();
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    MoveAmphipodTo(currentAmphipod.X - 1, currentAmphipod.Y);
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    MoveAmphipodTo(currentAmphipod.X + 1, currentAmphipod.Y);
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    MoveAmphipodTo(currentAmphipod.X, currentAmphipod.Y - 1);
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    MoveAmphipodTo(currentAmphipod.X, currentAmphipod.Y + 1);
                }
                else
                {
                    if (char.ToUpper(key.KeyChar) == 'X')
                    {
                        return int.MaxValue;
                    }
                    else
                    {
                        var typeCh = Console.ReadKey().KeyChar;
                        if (amphipods.TryGetValue((char.ToUpper(key.KeyChar), char.ToUpper(typeCh)), out var amphipod))
                        {
                            currentAmphipod = amphipod;
                        }
                    }
                }
            }

            return score;
        }

        private void MoveAmphipodTo(int x, int y)
        {
            if (burrow[x][y] == '.')
            {
                burrow[currentAmphipod.X][currentAmphipod.Y] = '.';
                burrow[x][y] = currentAmphipod.ShowChar;
                score += currentAmphipod.StepEnergy;
                amphipodPositions.Remove((currentAmphipod.X, currentAmphipod.Y));
                currentAmphipod.X = x;
                currentAmphipod.Y = y;
                amphipodPositions.Add((currentAmphipod.X, currentAmphipod.Y), currentAmphipod);
            }
        }

        private bool CanChooseAmphipod = true;
        private Amphipod currentAmphipod;

        private void ShowGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Record score: {record}");
            Console.WriteLine($"Actual score: {score}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int x = 0; x < burrow.Count; x++)
            {
                for (int y = 0; y < burrow[x].Count; y++)
                {
                    if (amphipodPositions.TryGetValue((x, y), out var amphipod))
                    {
                        Console.ForegroundColor = amphipod.Color;
                        Console.Write(burrow[x][y]);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write(burrow[x][y]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            if (CanChooseAmphipod)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Choose Amphipod to move OR move with the selected one.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Move with the selected Amphipod.");
            }

            Console.Write($"Actually selected: ");
            Console.ForegroundColor = currentAmphipod.Color;
            Console.WriteLine("*" + currentAmphipod.ShowChar + "*");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("All amphipods to choose from:");
            foreach (var a in amphipods)
            {
                Console.ForegroundColor = a.Value.Color;
                Console.WriteLine("*" + a.Key);
            }
        }

        private bool IsGameEnded()
        {
            for (int i = 0; i < Goal.Count; i++)
            {
                for (int j = 0; j < Goal[i].Count; j++)
                {
                    if (Goal[i][j] != burrow[i][j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
