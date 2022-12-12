using Application.MtGCard_Service.DTO;
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
    }
}
