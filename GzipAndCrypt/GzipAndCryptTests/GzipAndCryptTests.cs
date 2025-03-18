using System;
using System.IO;
using System.Text;

namespace GzipAndCrypt
{
    public class GzipAndCryptTests
    {
        /*
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
        */

        [Fact]
        public void ReadCheckForAStreamShouldReturnTrue()
        {
            string message = "testData";
            MemoryStream memoryStream = new MemoryStream();

            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8, 1024, leaveOpen: true))
            {
                writer.Write(message);
                writer.Flush();

                memoryStream.Position = 0;
            }

            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();

            Assert.Equal("testData", gzipAndCrypt.Read(memoryStream));
        }

        [Fact]
        public void ReadCheckForAStreamShouldReturnFalse()
        {
            string message = "testData";
            MemoryStream memoryStream = new MemoryStream();

            using (StreamWriter writer = new StreamWriter(memoryStream, Encoding.UTF8, 1024, leaveOpen: true))
            {
                writer.Write(message);
                writer.Flush();

                memoryStream.Position = 0;
            }

            GzipAndCrypt gzipAndCrypt = new GzipAndCrypt();

            Assert.NotEqual("testDat", gzipAndCrypt.Read(memoryStream));
        }
    }
}