using Domain.MtGDomain.DTO;
using MtGCard_Service.DTO;
using MtGCard_Service.Interface;
using MtGDomain.DTO;

namespace MtGCard_API
{
    public class MockData : IMtGCardRepository, ICardSetBuffer
    {
        private List<MtGCardRecordDTO> GetCardList()
        {
            List<MtGCardRecordDTO> list = new List<MtGCardRecordDTO>()
            {
                new MtGCardRecordDTO("Blood Artist","dpoj3ed3290dn","Lose 1 life",new List<MtGRulingRecord_DTO>(),new(),"https://www.image.com","fjeru5489fdj", new string[] { "Creature"}, new string[] { },2,false,false,"{1}{B}", "","","", new()),
                new MtGCardRecordDTO("Delver of Secrets","dpoj3e544fwn","Flip for 3/2",new List<MtGRulingRecord_DTO>(),new(), "https://www.image.com","fjer32er9fdj", new string[] { "Creature" }, new string[] { },1,false,false,"{U}", "","", "", new()),
                new MtGCardRecordDTO("Blood Tome","dpoj3e213e2n","Lose 5 life",new List<MtGRulingRecord_DTO>(),new(), "https://www.image.com","fjery6y65j", new string[] { }, new string[] { },3,false,false,"{1}{U}", "","", "", new()),
                new MtGCardRecordDTO("Blood Land","dpe3rcfwedn","Get 2 Mana",new List<MtGRulingRecord_DTO>(),new(),"","fjerud3eqwd23j",new string[]{}, new string[] { }, 0,false,false,"{0}", "","","", new()),
                new MtGCardRecordDTO("Bad Moon","dwqdwq290dn","Black Creature +1/+1",new List<MtGRulingRecord_DTO>(),new(), "https://www.image.com","crfegru5489fdj", new string[]{},new string[]{}, 2,false,false,"{1}{B}{B}", "","", "",new())
            };
            return list;
        }
        public async Task<List<MtGCardRecordDTO>> GetCardsByName(string name)
        {
            var list = GetCardList();
            var result = list.Where(x => x.Name.Contains(name)).ToList();

            return await Task.FromResult(result);
        }

        public async Task<List<MtGCardRecordDTO>> GetRandomCardsFromApi(string setname)
            => await Task.FromResult(GetCardList());

        public async Task<List<MtGSetRecordDTO>> GetAllSets()
        {
            var list = new List<MtGSetRecordDTO>()
            {
                new MtGSetRecordDTO("Innistrad","ISD"),
                new MtGSetRecordDTO("The Dark","DRK")
            };

            return await Task.FromResult(list);
        }

        public async Task<List<MtGCardRecordDTO>> GetBoosterPackFromSet(string setcode)
            => await Task.FromResult(GetCardList());

        public async Task<List<MtGCardRecordDTO>> GetAllCardsFromASet(string setCode)
            => await Task.FromResult(GetCardList());

        public List<MtGCardRecordDTO> GetSet(string SetCode)
            => GetCardList();

        public bool AddSet(MtGCardSet set)
        {
            return true;
        }

        public bool DoesSetExist(string setCode)
        {
            return true;
        }

        public Task<List<MtGCardRecordDTO>> GetCardsByName(string name, MtGSearchFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}
