using Domain.MtGDomain.DTO;
using MtGCard_API;
using MtGCard_Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._2_Infrastructure
{
    [Trait("Infrastructure", "SearchBuffer")]
    public class SearchBuffer_Test
    {
        [Fact]
        public void CheckIfClickedCardCounterWorks_AddACardThreeTimes_ShouldReturnCountThree()
        {
            var buffer = new SearchBuffer();
            var card = new MtGCardRecordDTO("testcard", "1", "hello", null, null, null, null, null, null,0, false, false, "{1}{B}");
            buffer.AddClickedCard(card);
            buffer.AddClickedCard(card);
            buffer.AddClickedCard(card);

            var list = buffer.GetClickedCardList();
            Assert.True(list.Count == 1);
            Assert.True(list[0].NumOfTimesClicked == 3);
        }

        [Fact]
        public void AddASearchResult_GetItThreeTimes_CheckNumOfUses_ShouldBeThree()
        {
            MtGSearchResultClass_DTO msr = new MtGSearchResultClass_DTO("test", new List<MtGCardRecordDTO>());
            _ = msr.SearchResult;
            _ = msr.SearchResult;
            _ = msr.SearchResult;
            Assert.True(msr.NumberOfUses == 3);
        }

        [Fact]
        public void AddASearchResult_GetItThreeTimes_CheckNumOfUses_ShouldNOTBeTwo()
        {
            MtGSearchResultClass_DTO msr = new MtGSearchResultClass_DTO("test", new List<MtGCardRecordDTO>());
            _ = msr.SearchResult;
            _ = msr.SearchResult;
            _ = msr.SearchResult;
            Assert.False(msr.NumberOfUses == 2);
        }
    }
}
