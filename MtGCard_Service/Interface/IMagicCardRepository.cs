using MtGDomain.Entities;
using MtGDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Interface;

public interface IMagicCardRepository
{
    Task AddAsync(MagicCard card);
    Task<MagicCard?> GetByIdAsync(Guid id);
    Task UpdateAsync(MagicCard card);
    Task AddAllAsync(List<MagicCard> cards);
    Task<MagicCardLists> GetAllListsForCard();
}