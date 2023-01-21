using MtGDomain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainValidation
{
    [Trait("Domain", "IsAbove Rule Validating")]
    public class IsAbove_RuleTestingValidating
    {
        [Fact]
        public void IsAboveINT_SettingFive_ValueIsFour_ShouldReturnFalse()
        {
            IsAbove isAbove = new(5);
            Assert.False(isAbove.Validate(4));
        }

        [Fact]
        public void IsAboveINT_SettingFive_ValueIsFive_ShouldReturnFalse()
        {
            IsAbove isAbove = new(5);
            Assert.False(isAbove.Validate(5));
        }

        [Fact]
        public void IsAboveINT_SettingFive_ValueIsSix_ShouldReturnTrue()
        {
            IsAbove isAbove = new(5);
            Assert.True(isAbove.Validate(6));
        }

        [Fact]
        public void IsAboveDECIMAL_SettingFivePoint5_ValueIsFour_ShouldReturnFalse()
        {
            IsAbove isAbove = new((decimal)5.5);
            Assert.False(isAbove.Validate((decimal)4));
        }

        [Fact]
        public void IsAboveDECIMAL_SettingFivePoint5_ValueIsFIVE_ShouldReturnFalse()
        {
            IsAbove isAbove = new((decimal)5.5);
            Assert.False(isAbove.Validate((decimal)5));
        }

        [Fact]
        public void IsAboveDECIMAL_SettingFivePoint5_ValueIssIX_ShouldReturnTrue()
        {
            IsAbove isAbove = new((decimal)5.5);
            Assert.True(isAbove.Validate((decimal)6));
        }
    }
}
