using Domain.MtGDomain.DTO;
using MtGDomain.Enums;
using MtGDomain.Extensions;
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
            var card = new MtGCardRecordDTO("Blood Artist", "dpoj3ed3290dn", "Lose 1 life", new List<MtGRulingRecord_DTO>(),
                new(), "https://www.image.com", "fjeru5489fdj", new string[] { "Creature" }, new string[] { }, 2,
                false, false, "{1}{B}", "", "");

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Black);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInWhiteCard_ShouldReturnTrue()
        {
            var card = new MtGCardRecordDTO("Blood Artist", "dpoj3ed3290dn", "Lose 1 life", new List<MtGRulingRecord_DTO>(),
                new(), "https://www.image.com", "fjeru5489fdj", new string[] { "Creature" }, new string[] { }, 2,
                false, false, "{1}{W}", "", "");

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.White);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInBlueCard_ShouldReturnTrue()
        {
            var card = new MtGCardRecordDTO("Blood Artist", "dpoj3ed3290dn", "Lose 1 life", new List<MtGRulingRecord_DTO>(),
                new(), "https://www.image.com", "fjeru5489fdj", new string[] { "Creature" }, new string[] { }, 2,
                false, false, "{1}{U}", "", "");

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Blue);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInRedCard_ShouldReturnTrue()
        {
            var card = new MtGCardRecordDTO("Blood Artist", "dpoj3ed3290dn", "Lose 1 life", new List<MtGRulingRecord_DTO>(),
                new(), "https://www.image.com", "fjeru5489fdj", new string[] { "Creature" }, new string[] { }, 2,
                false, false, "{1}{R}", "", "");

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Red);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInGreenCard_ShouldReturnTrue()
        {
            var card = new MtGCardRecordDTO("Blood Artist", "dpoj3ed3290dn", "Lose 1 life", new List<MtGRulingRecord_DTO>(),
                new(), "https://www.image.com", "fjeru5489fdj", new string[] { "Creature" }, new string[] { }, 2,
                false, false, "{1}{G}", "", "");

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Green);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInBlackAndRedCard_ShouldReturnTrue()
        {
            var card = new MtGCardRecordDTO("Blood Artist", "dpoj3ed3290dn", "Lose 1 life", new List<MtGRulingRecord_DTO>(),
                new(), "https://www.image.com", "fjeru5489fdj", new string[] { "Creature" }, new string[] { }, 2,
                false, false, "{1}{R}{B}", "", "");

            var result = card.DoesCardHaveThisColor(MtGDomain.Enums.MtGColor.Black);

            Assert.True(result);
        }

        [Fact]
        public void Test_DoesCardHaveThisColor_SendInBlackCard_ShouldReturnFalse()
        {
            var card = new MtGCardRecordDTO("Blood Artist", "dpoj3ed3290dn", "Lose 1 life", new List<MtGRulingRecord_DTO>(),
                new(), "https://www.image.com", "fjeru5489fdj", new string[] { "Creature" }, new string[] { }, 2,
                false, false, "{1}{B}", "", "");

            var result = card.DoesCardHaveThisColor(MtGColor.Green);

            Assert.False(result);
        }
    }
}
