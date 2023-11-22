using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Interface;

public interface IMagicCardService
{
    Task SaveCardsFromSet(string setCode);
}
