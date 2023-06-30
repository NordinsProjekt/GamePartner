using Application.MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MtGCard_Service.Interface
{
    public interface IMtGCardRepository
    {
        public Task<List<MtGCardRecordDTO>> GetCardsByName(string name);
        Task<List<MtGCardRecordDTO>> GetRandomCardsFromApi(string setname);
    }
}
