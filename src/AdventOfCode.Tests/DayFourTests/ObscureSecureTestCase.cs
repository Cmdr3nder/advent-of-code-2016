using Xunit;
using AdventOfCode.DayFour;

namespace AdventOfCode.Tests.DayFourTests
{
    public class ObscureSecureTestCase
    {
        [Theory]
        [InlineData("aaaaa-bbb-z-y-x", "abxyz")]
        [InlineData("a-b-c-d-e-f-g-h", "abcde")]
        [InlineData("not-a-real-room", "oarel")]
        public void TestHashRoom(string name, string expected)
        {
            Assert.Equal(expected, (new ObscureSecure()).HashRoom(new Room(name, 0, null)));
        }
    }
}
