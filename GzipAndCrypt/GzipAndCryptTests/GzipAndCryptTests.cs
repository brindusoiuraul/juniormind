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

        [Fact]
        public void TestForReturningASimpleStringShouldReturnFalse()
        {
            string testString = "tes";
            GzipAndCrypt readTest = new GzipAndCrypt();

            Assert.NotEqual(testString, readTest.Read());
        }
    }
}