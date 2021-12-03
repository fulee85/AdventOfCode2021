using Day03_BinaryDiagnostic;
using FluentAssertions;
using System;
using Xunit;

namespace Tests.Day03;

public class Tests
{
    [Fact]
    public void TestFirstPart()
    {
        // Arrange
        var input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

        var decriptor = new DiagnosticDecriptor(input.Split(Environment.NewLine));

        // Act
        var result = decriptor.GetPowerConsumption();

        // Assert
        result.Should().Be(198);
    }

    [Fact]
    public void TestSecondPart()
    {
        // Arrange
        var input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

        var decriptor = new DiagnosticDecriptor(input.Split(Environment.NewLine));

        // Act
        var result = decriptor.GetLifeSupportRating();

        // Assert
        result.Should().Be(230);
    }
}
