using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using MtGDomain.Extension;
using MtGDomain.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainValidation
{
    [Trait("Domain", "Validation ExtensionValidating")]
    public class ExtensionTestingValidation
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
