using MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.DTO
{
    public class MtGSearchResultClass_DTO
    {
        private string searchString;
        private int numOfUses;
        private List<MtGCardRecordDTO> cardList;

        public MtGSearchResultClass_DTO(string searchString,List<MtGCardRecordDTO> list) 
        { 
            this.searchString = searchString;
            numOfUses = 0;
            cardList = list;
        }

        public List<MtGCardRecordDTO> SearchResult { 
            get 
            { 
                numOfUses++;
                return cardList;
            } 
        }
        public string SearchText
        {
            get { return searchString; }
        }
        public int NumberOfUses
        {
            get { return numOfUses; }
        }

    }
}
