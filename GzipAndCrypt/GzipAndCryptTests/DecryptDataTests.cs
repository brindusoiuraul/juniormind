using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public class DecryptDataTests
    {
        [Fact]
        public void CheckForDecryptDataShouldBeEqual()
        {
            string message = "dWZ0dUVidWI=";
            var data = new PlainData();
            var encryptedData = new DecryptData(data);

            Assert.Equal("testData", encryptedData.ProcessData(message));
        }
    }
}
