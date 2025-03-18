using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public class PlainDataTests
    {
        [Fact]
        public void CheckForPlainDataShouldReturnTrue()
        {
            PlainData plainData = new PlainData();
            string plainDataString = plainData.ProcessData("test");

            Assert.Equal("test", plainDataString);
        }
    }
}
