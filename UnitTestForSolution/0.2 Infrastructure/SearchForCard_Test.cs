using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MtGCard_Service.Interface;
using Domain.MtGDomain.DTO;
using Infrastructure.MtGCard_API;
using NSubstitute;

namespace UnitTestForSolution._0._2_Infrastructure
{
    [Trait("Infrastructure", "SearchForCards")]
    public class SearchForCard_Test
    {
        [Fact]
        public void TryingOutSubstitute_CallingGetCardsByName_ShouldReceive1Call()
        {
            var api = Substitute.For<IMtGCardRepository>();
            api.GetCardsByName("Glissa");
            api.Received(1).GetCardsByName("Glissa");
        }

        [Fact]
        public void TryingOutSubstitute_CallingGetCardsByName_ShouldReturnAListOfCards()
        {
            var api = Substitute.For<IMtGCardRepository>();
            api.GetCardsByName(default).ReturnsForAnyArgs(new List<MtGCardRecordDTO>());
            var result = api.GetCardsByName("").Result;
            Assert.True(result.Count == 0);
        }

        [Fact]
        public void TryingOutSubstitute_CallingGetCardsByName_ShouldReturnAListOfCardsWithCount1()
        {
            var api = Substitute.For<IMtGCardRepository>();
            api.GetCardsByName(default).ReturnsForAnyArgs(new List<MtGCardRecordDTO>()
            { new MtGCardRecordDTO("Glissa", "234", "Deathtouch",null,new(),null,null,null,null) });
            var result = api.GetCardsByName("Gli").Result;
            Assert.True(result.Count == 1);
        }
    }
}
