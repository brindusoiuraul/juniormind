using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public class EncryptDataTests()
    {
        [Fact]
        public void EncryptionTestShouldReturnTrue()
        {
            string message = "testData";
            var data = new PlainData();
            var encryptedData = new EncryptData(data);

            Assert.Equal("dWZ0dUVidWI=", encryptedData.ProcessData(message));
            Assert.NotEqual("", encryptedData.ProcessData(message));
        }
    }
}
