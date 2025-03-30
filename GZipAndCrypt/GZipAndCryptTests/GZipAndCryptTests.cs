namespace GZipAndCrypt
{
    public class GZipAndCryptTests
    {
        [Fact]
        public void CheckForWriteShouldBeEqual()
        {
            MemoryStream stream = new MemoryStream();
            GZipAndCrypt gzipAndCrypt = new GZipAndCrypt();

            gzipAndCrypt.Write(stream, "testData");

            string readData = string.Empty;

            using (StreamReader reader = new StreamReader(stream))
            {
                readData = reader.ReadToEnd();
                reader.Close();
            }

            Assert.Equal("testData", readData);
        }
    }
}