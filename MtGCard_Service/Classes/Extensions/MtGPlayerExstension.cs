using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Classes.Extensions
{
    public static class MtGPlayerExstension
    {
        public static void DoDamage(this MtGPlayer player, int damage) => 
            player.life.PlayerTakeDamage(damage);
        public static void Heal(this MtGPlayer player, int lifeGain) => 
            player.life.PlayerGainsLife(lifeGain);
    }
}
