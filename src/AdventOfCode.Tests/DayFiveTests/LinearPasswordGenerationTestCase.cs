using AdventOfCode.DayFive;
using Xunit;

namespace AdventOfCode.Tests.DayFiveTests
{
    public class LinearPasswordGenerationTestCase
    {
        [Theory]
        [InlineData("abc42", "b75cfd9c08cd241707758160ec138164")]
        public void TestGetMd5Hash(string input, string expected)
        {
            Assert.Equal(expected, (new LinearPasswordGeneration("")).GetMd5Hash(input));
        }
    }
}
