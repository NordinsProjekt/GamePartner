using MtgApiManager.Lib.Service;
using MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_API.Extensions
{
    public static class IMtgQueryableExtensions
    {
        public static IMtgQueryable<ICardService, CardQueryParameter> AddTypeFilter(this IMtgQueryable<ICardService, CardQueryParameter> mtgQueryable, MtGSearchFilter filter)
        {
            return mtgQueryable.Where(x => x.Type, filter.Type);
        }

        public static IMtgQueryable<ICardService, CardQueryParameter> AddFormatFilter(this IMtgQueryable<ICardService, CardQueryParameter> mtgQueryable, MtGSearchFilter filter)
        {
            return mtgQueryable.Where(x=>x.GameFormat, filter.Format);
        }

        public static IMtgQueryable<ICardService, CardQueryParameter> AddCmcFilter(this IMtgQueryable<ICardService, CardQueryParameter> mtgQueryable, MtGSearchFilter filter)
        {
            return mtgQueryable.Where(x => x.Cmc, filter.CmcFilter.Cmc.ToString());
        }
    }
}
