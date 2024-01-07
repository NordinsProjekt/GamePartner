using Microsoft.EntityFrameworkCore;
using MtGDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicRepositories.Includes;

public static class MagicCardIncludes
{
    public static IQueryable<MagicCard> AllIncludes(this IQueryable<MagicCard> query)
    {
        return query.Include(c => c.Rulings)
            .Include(c => c.Abilities)
            .ThenInclude(c => c.MagicAbility)
            .Include(c => c.CardTypes)
            .ThenInclude(c => c.CardType)
            .Include(c => c.SuperCardTypes)
            .ThenInclude(c => c.SuperCardType)
            .Include(c => c.MagicLegalities)
            .ThenInclude(c => c.MagicLegality)
            .Include(st => st.CardSubTypes)
            .ThenInclude(st => st.CardSubType);
    }

    public static IQueryable<MagicCard> QuizVersion(this IQueryable<MagicCard> query)
    {
        return query.Include(c => c.CardTypes)
            .ThenInclude(x => x.CardType);
    }
}