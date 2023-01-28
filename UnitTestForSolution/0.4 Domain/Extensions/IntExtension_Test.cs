using MtGDomain.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._4_Domain.Extensions
{
    [Trait("Domain", "Int Extension")]
    public class IntExtension_Test
    {
        [Fact]
        public void IntExtensionMethod_IsAboveSetTo5_SendIn4_ShouldFail()
        {
            int test = 4;
            Assert.ThrowsAny<Exception>(() => test.IsAbove(5));
        }

        [Fact]
        public void IntExtensionMethod_IsAboveSetTo5_SendIn5_ShouldFail()
        {
            int test = 5;
            Assert.ThrowsAny<Exception>(() => test.IsAbove(5));
        }

        [Fact]
        public void IntExtensionMethod_IsAboveSetTo5_SendIn6_ShouldPass()
        {
            int test = 6;
            Assert.True(test.IsAbove(5) == 6);
        }
    }
}
