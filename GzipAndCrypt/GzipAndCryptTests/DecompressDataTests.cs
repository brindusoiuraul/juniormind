using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public class DecompressDataTests
    {
        [Fact]
        public void CheckForDecompressStringShouldBeEqual()
        {
            string message = "H4sIAAAAAAAACitJLS5xSSxJBABgmdc5CAAAAA==";
            var data = new PlainData();
            var decompressedData = new DecompressData(data);

            Assert.Equal("testData", decompressedData.ProcessData(message));
        }
    }
}
