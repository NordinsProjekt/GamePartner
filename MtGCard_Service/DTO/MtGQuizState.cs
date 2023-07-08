using Domain.MtGDomain.DTO;
using MtGCard_Service.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.DTO
{
    public class MtGQuizState
    {
        public MtGQuizModel Model { get; set; } = new();
        public bool GameStart { get; set; } = false;
        public ResultRecord? Result { get; set; }
        public List<MtGCardRecordDTO>? List { get; set; }
        public MtGCardRecordDTO? QuizCard { get; set; }
        public int Index { get; set; } = 0;
        public int Max { get; set; } = 0;
        public bool Loading { get; set; } = false;
        public int Score { get; set; } = 0;
    }
}
