using Xunit;
using StringExtensions;

namespace StringExtension.Tests
{
    public class StringPatternExtensionTests
    {
        [Theory]
        [InlineData("/article/{id}", "/article/1", true)]
        [InlineData("/article/{id}", "/article/1/comments", true)]
        [InlineData("/article/{id}", "/articles/1/", false)]
        [InlineData("/article/{id}/comments/{commentId}", "/article/1/comments/43", true)]
        public void ShouldDetemineIfMatchedWithThePattern(string pattern, string value, bool expectedResult)
        {
            Assert.Equal(expectedResult, value.IsMatchedWith(pattern));
        }
    }
}

