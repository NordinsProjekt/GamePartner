﻿using MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using MtGDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Classes
{
    public class MtGCommander
    {
        private MtGCardRecordDTO? commanderCard { get; set; }
        private int diedCounter { get; set; }
        public MtGCommander() { }

        public void SetCommanderCard(MtGCardRecordDTO commanderCard)
        {
            UseCardAsCommander test = new(commanderCard);
            if (test.IsModelValid())
                this.commanderCard = commanderCard;
        }
            
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
        public void CommanderDiedHeal()
        {
            if (diedCounter > 1)
                diedCounter--;
            else
                ResetDiedCounter();
        }
        public void ResetDiedCounter()
            => this.diedCounter = 0;
        public int GetDiedAmount()
            => this.diedCounter;
        public void RemoveCommanderCard() => commanderCard = null;
    }
}
