using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13_TransparentOrigami
{
    public static class TransparentPaperFactory
    {
        public static TransparentPaper CreateTransparentPaper(IEnumerable<string> dotStrings)
        {
            var transparentPaper = new TransparentPaper();

            foreach (var dotPosition in dotStrings)
            {
                var xy = dotPosition.Split(',').Select(int.Parse).ToArray();
                transparentPaper.AddDot(new Dot(xy[0], xy[1]));
            }

            return transparentPaper;
        }
    }
}
