using Domain.MtGDomain.DTO;
using MtGDomain.DTO;
using MtGDomain.Models;

namespace MtGDomain.States
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
