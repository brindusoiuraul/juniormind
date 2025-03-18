using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzipAndCrypt
{
    public class CompressDataTests
    {
        [Fact]
        public void CheckForCompressionShouldBeEqual()
        {
            IData data = new PlainData();
            data = new CompressData(data);

            Assert.Equal("H4sIAAAAAAAACipJLS5xSSxJBAAAAP//", data.ProcessData("testData"));
        }
    }
}
