using MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using MtGCard_Service.DTO;
using MtGCard_Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_API
{
    public class SearchBuffer : IMtGSearchBuffer
    {
        private List<MtGSearchResultClass_DTO> savedResult = new List<MtGSearchResultClass_DTO>();
        private List<ClickedCardClass> clickedList = new List<ClickedCardClass>();
        public List<MtGCardRecordDTO> SearchCard(string searchText)
        {
            var search = savedResult.Where(x => x.SearchText.ToLower() == searchText.ToLower().Trim()).FirstOrDefault();
            if (search != null)
                return search.SearchResult.ToList();
            return new List<MtGCardRecordDTO>();
        }

        public void AddToSearchBuffer(string searchText, List<MtGCardRecordDTO> list)
            => savedResult.Add (new MtGSearchResultClass_DTO(searchText.ToLower().Trim(), list));

        public void AddClickedCard(MtGCardRecordDTO card)
        {
            var result = clickedList.Where(x=>x.Card == card).FirstOrDefault();
            if (result == null)
                clickedList.Add(new ClickedCardClass(card.Name, card));
            else
                result.NumOfTimesClicked++;
        }
        public List<ClickedCardClass> GetClickedCardList() { return clickedList; }

        public MtGCardRecordDTO? GetCardById(string id)
        {
            var c = clickedList.Where(c=>c.Card.Id == id).FirstOrDefault();
            if (c != null)
                return c.Card;

            return null;
        }
    }
}
