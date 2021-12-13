using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13_TransparentOrigami
{
    public class TransparentPaper
    {
        private HashSet<Dot> dots = new HashSet<Dot>();

        public int DotsCount => dots.Count;

        public void AddDot(Dot dot) => dots.Add(dot);

        public TransparentPaper FoldUpAt(int y)
        {
            var newTransparentPaper = new TransparentPaper();

            foreach (Dot dot in dots)
            {
                if (dot.Y < y)
                {
                    newTransparentPaper.AddDot(dot);
                }
                else if (dot.Y > y)
                {
                    newTransparentPaper.AddDot(dot.MirrorToY(y));
                }
            }

            return newTransparentPaper;
        }

        public TransparentPaper FoldLeft(int x)
        {
            var newTransparentPaper = new TransparentPaper();

            foreach (Dot dot in dots)
            {
                if (dot.X < x)
                {
                    newTransparentPaper.AddDot(dot);
                }
                else if (dot.X > x)
                {
                    newTransparentPaper.AddDot(dot.MirrorToX(x));
                }
            }

            return newTransparentPaper;
        }

        public override string ToString()
        {
            var maxX = dots.Max(d => d.X);
            var maxY = dots.Max(d => d.Y);
            var sb = new StringBuilder();

            for (int y = 0; y <= maxY; y++)
            {
                for (int x = 0; x <= maxX; x++)
                {
                    if (dots.Contains(new Dot(x,y)))
                    {
                        sb.Append('#');
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
