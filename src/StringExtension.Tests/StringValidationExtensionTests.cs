using Xunit;
using StringExtensions;

namespace StringExtension.Tests
{
    public class StringValidationExtensionTests
    {
        [Theory]
        [InlineData("90017", true)]
        [InlineData("07652", true)]
        [InlineData("90017-5041", true)]
        [InlineData("90017 5041", false)]
        [InlineData("90017-504", false)]
        [InlineData("90017-5041-1", false)]
        [InlineData("90017-", false)]
        [InlineData("9001", false)]
        [InlineData("V5K1A6", false)]
        [InlineData("V5K-1A6", false)]
        [InlineData("V5K 1A6", false)]
        public void ShouldDetermingUsZipCodes(string zipCode, bool expectedResult)
        {
            Assert.Equal(zipCode.IsUsZipCode(), expectedResult);
        }
    }
}

