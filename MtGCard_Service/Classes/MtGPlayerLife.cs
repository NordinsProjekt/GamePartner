using MtGCard_Service.Exceptions;

namespace MtGCard_Service.Classes
{
    public class MtGPlayerLife
    {
        private int playerLife;
        private int playerPoisonCount;
        private int[] playerCommanderDmg;

        public MtGPlayerLife(int playerLife, int playerPoisonCount, int numOfPlayers)
        {
            this.playerLife = playerLife;
            this.playerPoisonCount = playerPoisonCount;
            playerCommanderDmg = new int[numOfPlayers];
            for (int i = 0; i < numOfPlayers; i++)
            {
                playerCommanderDmg[i] = new();
            }
        }

        public int PlayerLife
        {
            get { return playerLife; }
            set { playerLife = value; }
        }
        public int PlayerPoisonCount
        {
            get { return playerPoisonCount; }
        }

        public int GetPlayerCommanderDamage(int commanderPlayerIndex)
        {
            CheckPlayerIndex(commanderPlayerIndex);
            return playerCommanderDmg[commanderPlayerIndex];
        }
        public void PlayerTakeDamage(int dmg) => playerLife -= dmg;
        public void PlayerTakePoisonDamage(int poison) => playerPoisonCount += poison;
        public void PlayerGainsLife(int lifeGain) => playerLife += lifeGain;
        public void PlayerRemovePoisonCounters(int poisonReduce)
        {
            if (PlayerPoisonCount >= poisonReduce)
                playerPoisonCount -= poisonReduce;
            else
                playerPoisonCount = 0;
        }
        public void PlayerTakesCommanderDamage(int playerCommanderIndex,int damageAmount) 
        { 
            CheckPlayerIndex(playerCommanderIndex);
            playerCommanderDmg[playerCommanderIndex] += damageAmount;
        }

        public void PlayerHealsCommanderDamage(int playerCommanderIndex,int healAmount)
        {
            CheckPlayerIndex(playerCommanderIndex);
            if (healAmount >= playerCommanderDmg[playerCommanderIndex])
                playerCommanderDmg[playerCommanderIndex] = 0;
            else
                playerCommanderDmg[playerCommanderIndex]-=healAmount;
        }
        private void CheckPlayerIndex(int playerIndex)
        {
            if (playerIndex > playerCommanderDmg.Length - 1 && playerIndex < 0)
                throw new PlayerIndexException("Commander Player doesnt exist", playerIndex);
        }
    }
}
