using Day13_TransparentOrigami;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Day13
{
    public class Tests
    {
        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var input = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5".Split(Environment.NewLine);

            var solver = new Solver(input);

            // Act
            var result = solver.SolveFirstPart();

            // Assert
            result.Should().Be(17);
        }
    }
}
