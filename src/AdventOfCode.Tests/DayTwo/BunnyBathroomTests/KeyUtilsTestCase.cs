using AdventOfCode.DayTwo;
using AdventOfCode.Utils;
using Xunit;

namespace AdventOfCode.Tests.DayTwo.BunnyBathroomTests
{
    public class KeyUtilsTestCase
    {
        [Theory]
        [InlineData(Key.One, Direction.Up, Key.One)]
        [InlineData(Key.One, Direction.Down, Key.Four)]
        [InlineData(Key.One, Direction.Left, Key.One)]
        [InlineData(Key.One, Direction.Right, Key.Two)]
        [InlineData(Key.Two, Direction.Up, Key.Two)]
        [InlineData(Key.Two, Direction.Down, Key.Five)]
        [InlineData(Key.Two, Direction.Left, Key.One)]
        [InlineData(Key.Two, Direction.Right, Key.Three)]
        [InlineData(Key.Three, Direction.Up, Key.Three)]
        [InlineData(Key.Three, Direction.Down, Key.Six)]
        [InlineData(Key.Three, Direction.Left, Key.Two)]
        [InlineData(Key.Three, Direction.Right, Key.Three)]
        [InlineData(Key.Four, Direction.Up, Key.One)]
        [InlineData(Key.Four, Direction.Down, Key.Seven)]
        [InlineData(Key.Four, Direction.Left, Key.Four)]
        [InlineData(Key.Four, Direction.Right, Key.Five)]
        [InlineData(Key.Five, Direction.Up, Key.Two)]
        [InlineData(Key.Five, Direction.Down, Key.Eight)]
        [InlineData(Key.Five, Direction.Left, Key.Four)]
        [InlineData(Key.Five, Direction.Right, Key.Six)]
        [InlineData(Key.Six, Direction.Up, Key.Three)]
        [InlineData(Key.Six, Direction.Down, Key.Nine)]
        [InlineData(Key.Six, Direction.Left, Key.Five)]
        [InlineData(Key.Six, Direction.Right, Key.Six)]
        [InlineData(Key.Seven, Direction.Up, Key.Four)]
        [InlineData(Key.Seven, Direction.Down, Key.Seven)]
        [InlineData(Key.Seven, Direction.Left, Key.Seven)]
        [InlineData(Key.Seven, Direction.Right, Key.Eight)]
        [InlineData(Key.Eight, Direction.Up, Key.Five)]
        [InlineData(Key.Eight, Direction.Down, Key.Eight)]
        [InlineData(Key.Eight, Direction.Left, Key.Seven)]
        [InlineData(Key.Eight, Direction.Right, Key.Nine)]
        [InlineData(Key.Nine, Direction.Up, Key.Six)]
        [InlineData(Key.Nine, Direction.Down, Key.Nine)]
        [InlineData(Key.Nine, Direction.Left, Key.Eight)]
        [InlineData(Key.Nine, Direction.Right, Key.Nine)]
        public void TestMove(Key key, Direction direction, Key expected)
        {
            Assert.Equal(expected, KeyUtils.Move(key, direction));
        }
    }
}
