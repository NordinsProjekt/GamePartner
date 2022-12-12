﻿using Application.MtGCard_Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.DTO
{
    public sealed record MtGPlayerWithCardListRecord_DTO(int PlayerIndex, string PlayerName,List<MtGCardRecordDTO> CardList);
}
