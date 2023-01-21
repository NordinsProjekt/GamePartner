using Application.MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using MtGCard_Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MtGCard_Service.Interface
{
    public interface IMtGSearchBuffer
    {
        public List<MtGCardRecordDTO> SearchCard(string searchText);
        public void AddToSearchBuffer(string searchText, List<MtGCardRecordDTO> list);
        public void AddClickedCard(MtGCardRecordDTO card);
        public List<ClickedCardClass> GetClickedCardList();
        public MtGCardRecordDTO GetCardById(string id);
    }
}
