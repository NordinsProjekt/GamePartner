using Domain.MtGDomain.DTO;
using MtGCard_Service.Classes;
using MtGCard_Service.DTO;
using MtGDomain.Enum;
using MtGDomain.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Interface
{
    public interface IMtGQuizService
    {
        Task<List<(string Name,string Code)>> GetSupportedMtGSets();
        Task<bool> StartQuiz(string setCode);
        MtGQuizState GetQuizState();
        void CheckAnswer(string text);
        void CheckAnswerColor();
        void CheckAnswerCmC();
        void EndQuiz();
    }
}
