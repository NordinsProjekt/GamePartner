using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Models;

public sealed record MagicQuizDto(string Name, string SetCode, List<MagicQuizCardDto> Cards);