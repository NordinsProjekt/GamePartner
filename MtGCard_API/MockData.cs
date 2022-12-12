using Application.MtGCard_Service.DTO;
using Application.MtGCard_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_API
{
    public class MockData : IMtGCardRepository
    {
        public async Task<List<MtGCardRecordDTO>> GetCardsByName(string name)
        {
            List<MtGCardRecordDTO> list = new List<MtGCardRecordDTO>()
            {
                new MtGCardRecordDTO("Blood Artist","dpoj3ed3290dn","Lose 1 life",new List<MtGRulingRecord_DTO>(),"https://www.image.com","fjeru5489fdj"),
                new MtGCardRecordDTO("Delver of Secrets","dpoj3e544fwn","Flip for 3/2",new List<MtGRulingRecord_DTO>(),"https://www.image.com","fjer32er9fdj"),
                new MtGCardRecordDTO("Blood Tome","dpoj3e213e2n","Lose 5 life",new List<MtGRulingRecord_DTO>(),"https://www.image.com","fjery6y65j"),
                new MtGCardRecordDTO("Blood Land","dpe3rcfwedn","Get 2 Mana",new List<MtGRulingRecord_DTO>(),"","fjerud3eqwd23j"),
                new MtGCardRecordDTO("Bad Moon","dwqdwq290dn","Black Creature +1/+1",new List<MtGRulingRecord_DTO>(),"https://www.image.com","crfegru5489fdj")
            };
            return list.Where(x=>x.Name.Contains(name)).ToList();
        }
    }
}
