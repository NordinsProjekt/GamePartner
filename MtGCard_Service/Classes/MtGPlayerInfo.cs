using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Classes
{
    public class MtGPlayerInfo
    {
        private int playerId;
        private string playerName;
        public MtGPlayerInfo(int id, string name)
        {
            playerId = id;
            playerName = name;
        }

        public string Name
        {
            get { return playerName; }
        }

        public int Id { get { return playerId; } }
    }
}
