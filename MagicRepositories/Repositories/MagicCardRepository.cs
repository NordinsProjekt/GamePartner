using Microsoft.EntityFrameworkCore;
using MtGCard_Service.Interface;
using MtGDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicRepositories.Repositories
{
    public class MagicCardRepository : IMagicCardRepository
    {
        private readonly PortalContext _context;

        public MagicCardRepository(PortalContext context)
        {
            _context = context;
        }

        // Create
        public async Task AddAsync(MagicCard card)
        {
            _context.MagicCards.Add(card);
            await _context.SaveChangesAsync();
        }

        // Read
        public async Task<MagicCard?> GetByIdAsync(Guid id)
        {
            return await _context.MagicCards
                .Include(c => c.Rulings)
                .Include(c => c.Abilities)
                .Include(c => c.CardTypes)
                .Include(c => c.SuperCardTypes)
                .Include(c => c.MagicLegalities)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        // Update
        public async Task UpdateAsync(MagicCard card)
        {
            _context.MagicCards.Update(card);
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task DeleteAsync(Guid id)
        {
            var card = await _context.MagicCards.FindAsync(id);
            if (card != null)
            {
                _context.MagicCards.Remove(card);
                await _context.SaveChangesAsync();
            }
        }
    }
}
