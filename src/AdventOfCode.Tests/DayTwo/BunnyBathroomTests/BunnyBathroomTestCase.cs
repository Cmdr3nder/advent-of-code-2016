using System.Collections.Generic;
using Xunit;
using AdventOfCode.DayTwo;

namespace AdventOfCode.Tests.DayTwo.BunnyBathroomTests
{
    public class BunnyBathroomTestCase
    {
        [Fact]
        public void TestGenerateCode()
        {
            var expected = new List<Key>();
            expected.Add(Key.One);
            expected.Add(Key.Nine);
            expected.Add(Key.Eight);
            expected.Add(Key.Five);
            Assert.Equal(expected, (new BunnyBathroom()).GenerateCode("UUL\nRRDDD\nLURDL\nUUUUD", new Key[,] {
                {Key.One, Key.Two, Key.Three},
                {Key.Four, Key.Five, Key.Six},
                {Key.Seven, Key.Eight, Key.Nine}
            }, Key.Five));
        }
    }
}
