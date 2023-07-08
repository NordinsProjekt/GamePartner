using MtGDomain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._4_Domain.Rules
{
    [Trait("Domain", "StringMatch Rule Validating")]
    public class StringMatch_Test
    {
        [Fact]
        public void StringMatch_SettingHej_ValueIsHej_ShouldMatch()
        {
            StringMatch stringMatch = new("Hej");
            Assert.True(stringMatch.Validate("HEJ"));
        }

        [Fact]
        public void StringMatch_SettingHej_ValueIsHej2_ShouldNotMatch()
        {
            StringMatch stringMatch = new("Hej");
            Assert.False(stringMatch.Validate("Hej2"));
        }

        [Fact]
        public void StringMatch_SettingHej_ValueIsStringArrayWithHejAndHej2_ShouldMatch()
        {
            StringMatch stringMatch = new("Hej");
            Assert.True(stringMatch.Validate(new string[] { "Hej2", "Hej" }));
        }

        [Fact]
        public void StringMatch_SettingHej_ValueIsStringArrayOfRandomText_ShouldNOTMatch()
        {
            StringMatch stringMatch = new("Hejsan");
            Assert.False(stringMatch.Validate(new string[] { "Hej2", "Hej", "TEST", "Apple" }));
        }

        [Fact]
        public void StringMatch_SettingHej_ValueIsIntFive_ShouldNotMatch()
        {
            StringMatch stringMatch = new("Hej");
            Assert.False(stringMatch.Validate(5));
        }

        [Fact]
        public void StringMatch_SendinIntArray__SettingHej_ValueIsIntFive_ShouldThrowException()
        {
            StringMatch stringMatch = new("Hej");

            Action shouldThrow = (() => stringMatch.Validate(new int[] { 1, 2, 3, 4, 5 }));

            Assert.Throws<InvalidCastException>(() => shouldThrow());
        }
    }
}
