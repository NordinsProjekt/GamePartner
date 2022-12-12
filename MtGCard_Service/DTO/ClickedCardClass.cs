using Application.MtGCard_Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.DTO
{
    public class ClickedCardClass
    {
        public string CardName { get; set; } = "";
        public int NumOfTimesClicked { get; set; }

        public MtGCardRecordDTO Card { get; set; }
        public ClickedCardClass(string cardName,  MtGCardRecordDTO card)
        {
            CardName = cardName;
            Card = card;
            NumOfTimesClicked = 1;
        }
    }
}
