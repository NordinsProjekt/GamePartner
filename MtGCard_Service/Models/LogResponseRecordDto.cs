using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Models;

public sealed record LogResponseRecordDto(List<LogRecordDto> Logs);