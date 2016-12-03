using Xunit;
using AdventOfCode.DayOne.EasterNavigation;
using System.Collections.Generic;
using AdventOfCode.Utils;

namespace AdventOfCode.Tests.DayOne.EasterNavigationTests
{
    public class EasterNavigationTestCase
    {
        [Fact]
        public void TestConvertInstruction()
        {
            var expected = new Instruction(Turn.R, 5);
            var actual = (new EasterNavigation()).ConvertInstruction("R5");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestConvertInstructions()
        {
            var expected = new List<Instruction>();
            expected.Add(new Instruction(Turn.R, 5));
            expected.Add(new Instruction(Turn.L, 2));
            expected.Add(new Instruction(Turn.R, 3));
            var actual = (new EasterNavigation()).ConvertInstructions("R5, L2, R3");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestApplyInstructions()
        {
            var expected = new Position(8, 2, Cardinal.East);
            var instructions = new List<Instruction>();
            instructions.Add(new Instruction(Turn.R, 5));
            instructions.Add(new Instruction(Turn.L, 2));
            instructions.Add(new Instruction(Turn.R, 3));
            var actual = (new EasterNavigation()).ApplyInstructions(new Position(0, 0, Cardinal.North), instructions);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Cardinal.North, 8, 0, 8)]
        [InlineData(Cardinal.South, 8, 0, -8)]
        [InlineData(Cardinal.East, 8, 8, 0)]
        [InlineData(Cardinal.West, 8, -8, 0)]
        public void TestApplyMagnitude(Cardinal direction, int magnitude, int x, int y)
        {
            var expected = new Position(x, y, direction);
            var actual = (new EasterNavigation()).ApplyMagnitude(new Position(0, 0, direction), magnitude);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(Turn.L, Cardinal.North, Cardinal.West)]
        [InlineData(Turn.L, Cardinal.South, Cardinal.East)]
        [InlineData(Turn.L, Cardinal.East, Cardinal.North)]
        [InlineData(Turn.L, Cardinal.West, Cardinal.South)]
        public void TestApplyTurn(Turn turn, Cardinal a, Cardinal b)
        {
            var expected = new Position(0, 0, b);
            var actual = (new EasterNavigation()).ApplyTurn(new Position(0, 0, a), turn);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestFindRepeatPosition()
        {
            var expected = new Position(5, 42, Cardinal.North);
            var positions = new List<Position>();
            positions.Add(expected);
            positions.Add(new Position(6, 33, Cardinal.South));
            positions.Add(new Position(5, 42, Cardinal.South));
            positions.Add(new Position(6, 32, Cardinal.South));
            positions.Add(new Position(6, 33, Cardinal.South));
            var actual = (new EasterNavigation()).FindRepeatPosition(positions);
            Assert.Equal(expected, actual);
        }
    }
}
