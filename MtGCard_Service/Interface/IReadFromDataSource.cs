﻿using MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Interface
{
    public interface IReadFromDataSource
    {
        List<MtGCardRecordDTO> GetCardList();
    }
}
