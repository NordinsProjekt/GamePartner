using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.DTO
{
    public sealed record ResultRecord(bool Correct, string ImageUrl);
}
