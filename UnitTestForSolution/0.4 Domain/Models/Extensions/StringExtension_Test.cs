using MtGDomain.Models.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._4_Domain.Models.Extensions
{
    [Trait("Domain", "StringExtension")]
    public class StringExtension_Test
    {
        [Fact]
        public void Test_FirstLetterToUpper_ShouldReturnStringWithFirstLetterUppercase()
        {
            string testString = "hejsan";
            Assert.True("Hejsan" == testString.FirstCharToUpper());
        }

        [Fact]
        public void Test_FirstLetterToUpper_TestingWithStringWithoutUpperCase_ShouldFail()
        {
            string testString = "hejsan";
            Assert.False("hejsan" == testString.FirstCharToUpper());
        }
    }
}
