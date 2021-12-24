using Day23Amphipod.Amphipods;

namespace Day23Amphipod
{
    public class AmphipodGame
    {
        private readonly List<List<char>> Goal = @"############
#...........#
###A#B#C#D###
  #A#B#C#D#
  #########".Split(Environment.NewLine).Select(s => s.ToList()).ToList();
        private readonly int record;
        private List<List<char>> burrow;
        private int score = 0;
        private readonly Dictionary<char, Amphipod> amphipods = new Dictionary<char, Amphipod>();
        private readonly Dictionary<(int x, int y), Amphipod> amphipodPositions = new Dictionary<(int x, int y), Amphipod>();
        private readonly List<(char ch, ConsoleColor color)> helper = new List<(char, ConsoleColor)>
        {
            ('G',ConsoleColor.Green),
            ('R',ConsoleColor.Red),
            ('Y',ConsoleColor.Yellow),
            ('B',ConsoleColor.Blue),
            ('M',ConsoleColor.Magenta),
            ('W',ConsoleColor.White),
            ('C',ConsoleColor.Cyan),
            ('D',ConsoleColor.DarkBlue)
        };

        public AmphipodGame(IEnumerable<string> startInput, int record)
        {
            this.burrow = startInput.Select(s => s.ToList()).ToList();
            this.record = record;
            var helperIndex = 0;
            for (int x = 0; x < burrow.Count && helperIndex < helper.Count; x++)
            {
                for (int y = 0; y < burrow[x].Count && helperIndex < helper.Count; y++)
                {
                    (var ch, var color) = helper[helperIndex];
                    switch (burrow[x][y])
                    {
                        case 'A':
                            amphipods[ch] = new AmberAmphipod(x, y, ch, color);
                            amphipodPositions.Add((x, y), amphipods[ch]);
                            helperIndex++;
                            break;
                        case 'B':
                            amphipods[ch] = new BronzeAmphipod(x, y, ch, color);
                            amphipodPositions.Add((x, y), amphipods[ch]);
                            helperIndex++;
                            break;
                        case 'C':
                            amphipods[ch] = new CopperAmphipod(x, y, ch, color);
                            amphipodPositions.Add((x, y), amphipods[ch]);
                            helperIndex++;
                            break;
                        case 'D':
                            amphipods[ch] = new DesertAmphipod(x, y, ch, color);
                            amphipodPositions.Add((x, y), amphipods[ch]);
                            helperIndex++;
                            break;
                        default:
                            break;
                    }
                }
            }

            currentAmphipod = amphipods['G'];
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
                    if (amphipods.TryGetValue(char.ToUpper(key.KeyChar), out var amphipod))
                    {
                        currentAmphipod = amphipod;
                    }
                    else if (char.ToUpper(key.KeyChar) == 'X')
                    {
                        return int.MaxValue;
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
                amphipodPositions.Remove((currentAmphipod.X,currentAmphipod.Y));
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
                    if (amphipodPositions.TryGetValue((x,y), out var amphipod))
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
                Console.ForegroundColor= ConsoleColor.White;
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
