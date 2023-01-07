using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Json.Facts
{
    public class ChoiceFacts
    {
        Choice digit = new Choice(
            new Character('0'),
            new Range('1', '9')
        );

        [Fact]
        public void CheckStringWhenCharacterMatchIsCorrectShouldReturnTrue()
        {
            Assert.True(digit.Match("012"));
        }
    }
}
