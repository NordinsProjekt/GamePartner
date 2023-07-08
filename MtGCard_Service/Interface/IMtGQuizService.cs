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
    }
}
