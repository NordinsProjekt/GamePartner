using MtGDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Exceptions
{
    public class DamageException : ApplicationException
    {
        public int PlayerIndex { get; private set; }
        public int Amount { get; private set; }
        public TypeOfUnit TypeOfUnit { get; private set; }
        public DamageException(string message, int playerIndex, int amount, TypeOfUnit typeOfUnit) : base(message)
        {
            PlayerIndex = playerIndex;
            Amount = amount;
            TypeOfUnit = typeOfUnit;
        }

    }
}
