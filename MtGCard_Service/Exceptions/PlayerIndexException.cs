using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Exceptions
{
    public class PlayerIndexException : ApplicationException
    {
        public int Index { get; private set; }
        public PlayerIndexException(string message, int index) : base(message, new IndexOutOfRangeException())
            => Index = index;
    }
}
