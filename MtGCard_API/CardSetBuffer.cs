using Domain.MtGDomain.DTO;
using Infrastructure.MtGCard_API;
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
        private List<MtGCardSet> sets { get; set; } = new List<MtGCardSet>();

        public CardSetBuffer() { }

        public List<MtGCardRecordDTO>? GetSet(string setCode)
        {
            var set = sets.FirstOrDefault(x => x.SetCode.Equals(setCode));
            if (set == null)
                return null;

            List<MtGCardRecordDTO> list = new List<MtGCardRecordDTO>();

            foreach (var item in set.List)
            {
                list.Add(MappingFunctions.CloneMtGRecord(item));
            }
            return list;
        }

        public bool AddSet(MtGCardSet set)
        {
            var receviedSet = sets.FirstOrDefault(x => x.SetCode.Equals(set.SetCode));
            if (receviedSet == null)
            {
                List<MtGCardRecordDTO> list = new List<MtGCardRecordDTO>();
                foreach (var item in set.List)
                {
                    list.Add(MappingFunctions.CloneMtGRecord(item));
                }
                MtGCardSet cardSet = new MtGCardSet(list, set.SetName, set.SetCode);
                sets.Add(cardSet);
                return true;
            }
            return false;
        }

        public bool DoesSetExist(string setCode)
            => sets.Any(x=>x.SetCode.Equals(setCode));
    }
}
