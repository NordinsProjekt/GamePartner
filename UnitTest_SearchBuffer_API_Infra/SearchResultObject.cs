using Application.MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using MtGCard_API;
using MtGCard_Service.DTO;

namespace UnitTest_SearchBuffer_API_Infra
{
    [Trait("SearchResultObjekt", "SearchBuffer")]
    public class SearchResultObject
    {
        
        [Fact]
        public void AddASearchResult_GetItThreeTimes_CheckNumOfUses_ShouldBeThree()
        {
            MtGSearchResultClass_DTO msr = new MtGSearchResultClass_DTO("test",new List<MtGCardRecordDTO>());
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