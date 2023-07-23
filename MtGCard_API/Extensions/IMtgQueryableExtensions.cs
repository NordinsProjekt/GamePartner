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
            if (filter.Types.Creature) 
            {
                mtgQueryable.Where(x => x.Types, "Creature");
            }

            if (filter.Types.Enchantment)
            {
                mtgQueryable.Where(x => x.Types, "Enchantment");
            }

            if (filter.Types.Instant)
            {
                mtgQueryable.Where(x => x.Types, "Instant");
            }

            if (filter.Types.Sorcery)
            {
                mtgQueryable.Where(x => x.Types, "Sorcery");
            }

            if (filter.Types.Artefact)
            {
                mtgQueryable.Where(x => x.Types, "Artefact");
            }

            if (filter.Types.Battle)
            {
                mtgQueryable.Where(x => x.Types, "Battle");
            }

            if (filter.Types.Planeswalker)
            {
                mtgQueryable.Where(x => x.Types, "Planeswalker");
            }

            if (filter.Types.Land)
            {
                mtgQueryable.Where(x => x.Types, "Land");
            }

            return mtgQueryable;
        }
    }
}
