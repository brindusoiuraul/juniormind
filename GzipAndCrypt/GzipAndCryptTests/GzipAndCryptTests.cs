using System;

namespace GzipAndCrypt
{
    public class GzipAndCryptTests
    {
        [Fact]
        public void TestForReturningASimpleStringShouldReturnTrue()
        {
            string testString = "test";
            GzipAndCrypt readTest = new GzipAndCrypt();

            Assert.Equal(testString, readTest.Read());
        }
    }
}