using Domain.MtGDomain.DTO;
using MtGDomain.DTO;

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
                unsortedList.Remove(temp);
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

                if (item.ManaCost is null)
                    continue;

                if (! item.MatchType(types))
                    newList.Add(item);
            }
            return newList;
        }

        public static List<MtGCardRecordDTO> FilterList(this List<MtGCardRecordDTO> list, MtGSearchFilter filter)
        {
            list = list.Where(x => x.DoesCardHaveThisColor(filter.ColorFilter.GetListOfColors())).ToList();

            if (filter.CmcFilter is null)
                return list;

            if (filter.CmcFilter.Cmc >= 0 && filter.CmcFilter.ChoosenSymbol.Equals("="))
                return list;

            switch (filter.CmcFilter.ChoosenSymbol)
            {
                case ">":
                    list = list.Where(x => x.Cmc > filter.CmcFilter.Cmc).ToList();
                    break;
                case "<":
                    list = list.Where(x => x.Cmc < filter.CmcFilter.Cmc).ToList();
                    break;
            }
            return list;
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
