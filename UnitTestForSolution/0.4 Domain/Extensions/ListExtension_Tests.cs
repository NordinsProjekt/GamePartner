using Domain.MtGDomain.DTO;
using MtGDomain.Extensions;

namespace UnitTestForSolution._0._4_Domain.Extensions
{
    [Trait("Domain", "List Extension")]
    public class ListExtension_Tests
    {
        private List<MtGCardRecordDTO> GetCards()
        {
            List<MtGCardRecordDTO> list = new List<MtGCardRecordDTO>()
            {
                new MtGCardRecordDTO("Blood Artist","dpoj3ed3290dn","Lose 1 life",new List<MtGRulingRecord_DTO>(),new(),"https://www.image.com","fjeru5489fdj", new string[] { "Creature"}, new string[] { },2,false,false,"{1}{B}"),
                new MtGCardRecordDTO("Delver of Secrets","dpoj3e544fwn","Flip for 3/2",new List<MtGRulingRecord_DTO>(),new(), "https://www.image.com","fjer32er9fdj", new string[] { "Creature" }, new string[] { },1,false,false,"{U}"),
                new MtGCardRecordDTO("Blood Tome","dpoj3e213e2n","Lose 5 life",new List<MtGRulingRecord_DTO>(),new(), "https://www.image.com","fjery6y65j", new string[] { }, new string[] { },3,false,false,"{1}{U}"),
                new MtGCardRecordDTO("Blood Land","dpe3rcfwedn","Get 2 Mana",new List<MtGRulingRecord_DTO>(),new(),"","fjerud3eqwd23j",new string[]{}, new string[] { }, 0,false,false,"{0}"),
                new MtGCardRecordDTO("Bad Moon","dwqdwq290dn","Black Creature +1/+1",new List<MtGRulingRecord_DTO>(),new(), "https://www.image.com","crfegru5489fdj", new string[]{},new string[]{}, 2,false,false,"{1}{B}{B}")
            };
            return list;
        }
        [Fact]
        public void ShuffleList_ShouldReturnANewListOfCards() 
        {
            var cardList = GetCards();
            var shuffledList = cardList.Shuffle();

            Assert.True(shuffledList.Count > 0);
            Assert.NotStrictEqual(cardList, shuffledList);
            Assert.NotEqual(cardList.GetHashCode(), shuffledList.GetHashCode());
        }

        [Fact]
        public void RemoveSpecificTypesFromAList_ShouldReturnNewList_ShouldReduseCountToThree()
        {
            var cardList = GetCards();
            var newList = cardList.RemoveMtGType(new string[] { "creature" });
            Assert.Equal(5,cardList.Count);
            Assert.Equal(3, newList.Count);
            Assert.NotStrictEqual(cardList, newList);
            Assert.NotEqual(cardList.GetHashCode(), newList.GetHashCode());
        }
    }
}
