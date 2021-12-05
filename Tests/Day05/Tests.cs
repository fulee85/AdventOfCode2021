using Day05_HydrothermalVenture;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace Tests.Day05;

public class Tests
{
    [Fact]
    public void TestFirstPart()
    {
        // Arrange
        var input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

        var oceanFloor = new OceanFloor(input.Split(Environment.NewLine).Select(Line.Create).Where(l => l is not DiagonalLine));

        // Act
        var result = oceanFloor.GetCountOfPointsWhereAtLeastTwoLinesOverlap();

        // Assert
        result.Should().Be(5);
    }

    [Fact]
    public void TestSecondPart()
    {
        // Arrange
        var input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

        var oceanFloor = new OceanFloor(input.Split(Environment.NewLine).Select(Line.Create));

        // Act
        var result = oceanFloor.GetCountOfPointsWhereAtLeastTwoLinesOverlap();

        // Assert
        result.Should().Be(12);
    }
}
