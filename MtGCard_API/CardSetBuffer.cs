using Domain.MtGDomain.DTO;
using MtGCard_Service.Interface;
using MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_API
{
    public class CardSetBuffer : ICardSetBuffer
    {
        public List<MtGCardSet> Sets { get; set; } = new List<MtGCardSet>();

        public CardSetBuffer() { }

        public List<MtGCardRecordDTO>? GetSet(string setCode)
        {
            var set = Sets.FirstOrDefault(x => x.SetCode.Equals(setCode));
            if (set == null)
                return null;
            return set.List;
        }


        public bool AddSet(MtGCardSet set)
        {
            var receviedSet = Sets.FirstOrDefault(x => x.SetCode.Equals(set.SetCode));
            if (receviedSet == null)
            {
                Sets.Add(set);
                return true;
            }
            return false;
        }
    }
}
