using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Models;

public sealed record MagicQuizCardDto(Guid Id, string Name, int Cmc, string Color, List<string> CardTypes, string ImageUrl);
