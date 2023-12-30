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
                .Include(c => c.CardTypes)
                .Include(c => c.SuperCardTypes)
                .Include(c => c.MagicLegalities);
    }

    public static IQueryable<MagicCard> QuizVersion(this IQueryable<MagicCard> query)
    {
        return query.Include(c => c.CardTypes).ThenInclude(x=>x.CardType);
    }
}
