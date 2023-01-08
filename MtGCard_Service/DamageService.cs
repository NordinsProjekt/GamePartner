using MtGDomain.Enums;
using MtGDomain.Exceptions;
using MtGDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service
{
    public class DamageService
    {
        public MtGDamageObject GetDamageObject(int amount, int playerId, TypeOfUnit unit)
            => new MtGDamageObject(amount, playerId, unit);
    }
}
