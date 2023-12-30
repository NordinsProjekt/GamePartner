using Domain.MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Models;

public sealed record MagicSetResponseRecordDto(int Count, List<MtGSetRecordDTO> Sets);