using ApplicationLayer.MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using MtGCard_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service
{
    public class MtGCardBufferService
    {
        private IMtGCardRepository _context;
        private List<MtGCardRecordDTO> savedCards = new List<MtGCardRecordDTO>();
        public MtGCardBufferService(IMtGCardRepository _rep) => _context = _rep;

        public async Task PopulateCardList(string searchText)
        {
            var result = await _context.GetCardsByName(searchText);
            savedCards = result.Where(img => img.ImageUrl != "").Where(img => img.ImageUrl != null).GroupBy(x => x.Name).Select(f => f.First()).ToList();
        }

        public IEnumerable<MtGCardRecordDTO> GetCards(int index,int jump)
        {
            List<MtGCardRecordDTO> list = new();
            list = savedCards.OrderBy(x=>x.Name).Skip(index - jump).Take(jump).ToList();
            return list;
        }

        public List<MtGCardRecordDTO> GetCardList() => savedCards.ToList();

        public int Count
        {
            get
            {
                return savedCards.Count();
            }
        }
    }
}
