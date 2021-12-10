using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10_SyntaxScoring
{
    public class ChunkLine
    {
        private readonly string line;
        private Stack<char> stack = new(); 
        private bool isLineCorrupted;
        private char corruptChar;

        private static readonly List<char> openingBrackets = new() { '(', '{', '<', '[' };
        private static readonly List<char> closingBrackets = new() { ')', '}', '>', ']' };

        public ChunkLine(string line)
        {
            this.line = line;
            AnalyzeLine();
        }

        private void AnalyzeLine()
        {
            foreach (char ch in line)
            {
                if (openingBrackets.Contains(ch))
                {
                    stack.Push(ch);
                }
                else
                {
                    if (stack.TryPop(out var openingCh))
                    {
                        if (openingBrackets.IndexOf(openingCh) != closingBrackets.IndexOf(ch))
                        {
                            isLineCorrupted = true;
                            corruptChar = ch;
                            return;
                        }
                    }
                }
            }
        }

        public IEnumerable<char> GetCompletingChars()
        {
            while (stack.Count > 0)
            {
                yield return closingBrackets[openingBrackets.IndexOf(stack.Pop())];
            }
        }

        public bool IsLineIncomplete => stack.Count > 0;

        public bool IsLineCorrupted => isLineCorrupted;

        public char CorruptChar => corruptChar;
    }
}
