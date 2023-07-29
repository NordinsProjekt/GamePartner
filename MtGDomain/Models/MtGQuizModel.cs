using MtGDomain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGDomain.Models
{
    public class MtGQuizModel
    {
        public MtGCardColor Color { get; set; } = new MtGCardColor();
        public QuizType Quiz { get; set; }
        public int CmcValue { get; set; }
        public string QuizSet { get; set; } = "";
    }
}
