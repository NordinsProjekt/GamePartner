using Domain.MtGDomain.DTO;
using MtGDomain.Enums;
using MtGDomain.Extensions;
using MtGDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._4_Domain.Extensions
{
    [Trait("Domain", "MtGCardRecord Extensions")]
    public class MtGCardRecordExtensionsTests
    {
        [Fact]
        public void Test_DoesCardHaveThisColor_SendInBlackCard_ShouldReturnTrue()
        {
            var card = new MtGCardObject() { ManaCost = "{B}" }.GetDTO();

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Black);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInWhiteCard_ShouldReturnTrue()
        {
            var card = new MtGCardObject() { ManaCost = "{1}{W}" }.GetDTO();

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.White);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInBlueCard_ShouldReturnTrue()
        {
            var card = new MtGCardObject() { ManaCost = "{2}{U}" }.GetDTO();

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Blue);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInRedCard_ShouldReturnTrue()
        {
            var card = new MtGCardObject() { ManaCost = "{R}" }.GetDTO();

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Red);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInGreenCard_ShouldReturnTrue()
        {
            var card = new MtGCardObject() { ManaCost = "{G}"}.GetDTO();

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Green);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInBlackAndRedCard_ShouldReturnTrue()
        {
            var card = new MtGCardObject() { ManaCost = "{B}" }.GetDTO();

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Black);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInBlackCard_ShouldReturnFalse()
        {
            var card = new MtGCardObject() { ManaCost = "{B}" }.GetDTO();

            var result = card.DoesCardHaveThisColor(MtGColor.Green);

            Assert.False(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColorWithColorList_SendInBlackCard_ShouldReturnFalse()
        {
            var card = new MtGCardObject() { ManaCost = "{B}" }.GetDTO();
            var colorList = new List<MtGColor>() { MtGColor.Red, MtGColor.Green };

            var result = card.DoesCardHaveThisColor(colorList);

            Assert.False(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColorWithColorList_SendInBlackRedCard_ShouldReturnTrue()
        {
            var card = new MtGCardObject() { ManaCost = "{B}{R}" }.GetDTO();
            var colorList = new List<MtGColor>() { MtGColor.Red, MtGColor.Black };

            var result = card.DoesCardHaveThisColor(colorList);

            Assert.True(result);
        }
    }
}
