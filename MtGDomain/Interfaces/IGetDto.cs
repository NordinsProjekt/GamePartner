using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Interfaces
{
    public interface IGetDto<T>
    {
        public T GetDTO();
    }
}
