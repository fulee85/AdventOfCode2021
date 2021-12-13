using Day12_PassagePathing;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Day12
{
    public class Tests
    {
        [Fact]
        public void TestFirstPart()
        {
            // Arrange
            var input = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

            var caves = new Caves(input.Split(Environment.NewLine));

            // Act
            var result = caves.GetPathCount();

            // Assert
            result.Should().Be(226);
        }

        [Fact]
        public void TestSecondPart()
        {
            // Arrange
            var input = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

            var caves = new Caves(input.Split(Environment.NewLine));

            // Act
            var result = caves.GetExtraPathCount();

            // Assert
            result.Should().Be(36);
        }
    }
}
