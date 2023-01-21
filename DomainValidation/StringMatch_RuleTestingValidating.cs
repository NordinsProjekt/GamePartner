﻿using MtGDomain.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainValidation
{
    [Trait("Domain", "StringMatch Rule Validating")]
    public class StringMatch_RuleTestingValidating
    {
        [Fact]
        public void StringMatch_SettingHej_ValueIsHej_ShouldMatch()
        {
            StringMatch stringMatch = new("Hej");
            Assert.True(stringMatch.Validate("Hej"));
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
            Assert.True(stringMatch.Validate(new string[] {"Hej2","Hej"}));
        }

        [Fact]
        public void StringMatch_SettingHej_ValueIsIntFive_ShouldNotMatch()
        {
            StringMatch stringMatch = new("Hej");
            Assert.False(stringMatch.Validate(5));
        }
    }
}