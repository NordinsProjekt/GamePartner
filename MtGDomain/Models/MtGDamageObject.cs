using MtGDomain.Enums;
using MtGDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Models
{
    public class MtGDamageObject
    {
        public int Amount { get; private set; }
        public int PlayerId { get; private set; }
        public TypeOfUnit Unit { get; private set; }

        public MtGDamageObject (int amount, int playerId, TypeOfUnit unit)
        {
            if (playerId < 0)
                throw new DamageException("PlayerId not accepted", playerId, amount, unit);
            if (amount <= 0)
                throw new DamageException("Amount cant be zero or below", playerId,amount,unit);
            Amount = amount;
            PlayerId = playerId;
            Unit = unit;
        }
    }
}
