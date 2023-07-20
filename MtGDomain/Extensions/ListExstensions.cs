using Domain.MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Extensions
{
    public static class ListExstensions
    {
        public static List<MtGCardRecordDTO> Shuffle(this List<MtGCardRecordDTO> unsortedList)
        {
            Random rnd = new Random();
            List<MtGCardRecordDTO> newList = new();
            int max = unsortedList.Count;
            for (int i = max-1; i > 0; i--)
            {
                var temp = unsortedList[rnd.Next(i)];
                newList.Add(temp);
            }
            return newList;
        }

        public static List<MtGCardRecordDTO> RemoveMtGType(this List<MtGCardRecordDTO> list, string[] types)
        {
            List <MtGCardRecordDTO> newList = new List<MtGCardRecordDTO>();
            int typeCount = types.Count();
            foreach (var item in list)
            {
                if (item.ImageUrl is "" || item.ImageUrl is null)
                    continue;
                if (! item.MatchType(types))
                    newList.Add(item);
            }
            return newList;
        }

        private static bool MatchType(this MtGCardRecordDTO record, string[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (record.Types.Any(x => x.ToLower().Equals(types[i].ToLower())))
                    return true;
            }
            return false;
        }
    }
}
