using MtGDomain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._4_Domain.Rules
{
    [Trait("Domain", "IsUnder Rule Validating")]
    public class IsUnder_Test
    {
        [Fact]
        public void IsUnderINT_SettingFive_ValueIsFour_ShouldReturnTrue()
        {
            IsUnder isUnder = new(5);
            Assert.True(isUnder.Validate(4));
        }

        [Fact]
        public void IsUnderINT_SettingFive_ValueIsFive_ShouldReturnFalse()
        {
            IsUnder isUnder = new(5);
            Assert.False(isUnder.Validate(5));
        }

        [Fact]
        public void IsUnderINT_SettingFive_ValueIsSix_ShouldReturnFalse()
        {
            IsUnder isUnder = new(5);
            Assert.False(isUnder.Validate(6));
        }

        [Fact]
        public void IsUnderDECIMAL_SettingFivePoint5_ValueIsFour_ShouldReturnTrue()
        {
            IsUnder isUnder = new((decimal)5.5);
            Assert.True(isUnder.Validate((decimal)4));
        }

        [Fact]
        public void IsUnderDECIMAL_SettingFivePoint5_ValueIsFIVE_ShouldReturnTrue()
        {
            IsUnder isUnder = new((decimal)5.5);
            Assert.True(isUnder.Validate((decimal)5));
        }

        [Fact]
        public void IsUnderDECIMAL_SettingFivePoint5_ValueIssIX_ShouldReturnFalse()
        {
            IsUnder isUnder = new((decimal)5.5);
            Assert.False(isUnder.Validate((decimal)6));
        }

    }
}
