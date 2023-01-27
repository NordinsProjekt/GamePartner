
using Domain.MtGDomain.DTO;
using MtGCard_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest_SearchBuffer_API_Infra
{
    [Trait("ClickedCardObjekt", "SearchBuffer")]
    public class ClickedCardObjekt
    {

        [Fact]
        public void CheckIfClickedCardCounterWorks_AddACardThreeTimes_ShouldReturnCountThree()
        {
            var buffer = new SearchBuffer();
            var card = new MtGCardRecordDTO("testcard","1","hello",null,null,null,null,null,null);
            buffer.AddClickedCard(card);
            buffer.AddClickedCard(card);
            buffer.AddClickedCard(card);

            var list = buffer.GetClickedCardList();
            Assert.True(list.Count == 1);
            Assert.True(list[0].NumOfTimesClicked == 3);
        }
    }
}
