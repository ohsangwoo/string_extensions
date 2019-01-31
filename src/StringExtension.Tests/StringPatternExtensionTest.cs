using System;
using Xunit;
using StringExtensions;

namespace StringExtension.Tests
{
    public class StringPatternExtensionTest
    {
        [Fact]
        public void ShouldDetemineIfMatchedWithThePattern()
        {
            var pattern = "Let's go to {place}";

            var valueExpectedToBeMatched = "Let's go to Los Angeles";
            Assert.True(valueExpectedToBeMatched.IsMatchedWith(pattern));

            var valueExpectedToBeNotMatched = "We Should go to Los Angeles";
            Assert.False(valueExpectedToBeNotMatched.IsMatchedWith(pattern));
        }
    }
}

