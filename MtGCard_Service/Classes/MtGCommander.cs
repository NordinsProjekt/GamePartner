using Application.MtGCard_Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Classes
{
    public class MtGCommander
    {
        private MtGCardRecordDTO commanderCard;
        private int diedCounter { get; set; }
        public MtGCommander() { }

        public void SetCommanderCard(MtGCardRecordDTO commanderCard)
            => this.commanderCard = commanderCard;
        public MtGCardRecordDTO GetCommanderCard()
        {
            if (commanderCard != null)
            {
                return commanderCard;
            }
            return default(MtGCardRecordDTO);
        }

        public void CommanderDied()
        => this.diedCounter++;
        public void ResetDiedCounter()
            => this.diedCounter = 0;
        public int GetDiedAmount()
            => this.diedCounter;
    }
}
