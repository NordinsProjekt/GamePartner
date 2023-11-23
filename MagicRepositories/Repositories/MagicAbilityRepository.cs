using MtGCard_Service.Interface;
using MtGDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicRepositories.Repositories
{
    public class MagicAbilityRepository : IMagicAbilityRepository
    {
        private readonly PortalContext _context;

        public MagicAbilityRepository(PortalContext context)
        {
            _context = context;
        }

        public MagicAbility FindOrCreateAbility(string abilityName)
        {
            var ability = _context.MagicAbility.FirstOrDefault(a => a.Name == abilityName);
            if (ability == null)
            {
                ability = new MagicAbility { Id = Guid.NewGuid(), Name = abilityName };
                _context.MagicAbility.Add(ability);
                _context.SaveChanges();  // Synchronous save, consider async in a real-world application
            }
            return ability;
        }

        // Other CRUD operations can be added here
    }
}
