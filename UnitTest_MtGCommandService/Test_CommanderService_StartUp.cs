using Infrastructure.MtGCard_API;
using MtGCard_API;
using MtGCard_Service;

namespace UnitTest_MtGCommandService
{
    [Trait("Init", "StartupCheck")]
    public class Test_CommanderService_StartUp
    {
        [Fact]
        public void CreateCommanderObjectWith4Players_ShouldReturnPlayerListCount4()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep,4);
            Assert.True(mcs.PlayerCount == 4);
        }
        [Fact]
        public void CreateCommanderObjectWith4Players_CheckIfAllPlayersStartWith40Life_ShouldReturn40ForAllPlayers()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            for (int i = 0; i < 4; i++)
                Assert.True(mcs.GetPlayerLifeTotal(i) == 40);          
        }
        [Fact]
        public void CreateCommanderObjectWith4Players_CheckIfAllPlayersStartWith0PoisonCounters_ShouldReturn0ForAllPlayers()
        {
            MockData _rep = new MockData();
            MtGCommanderService mcs = new MtGCommanderService(_rep, 4);
            for (int i = 0; i < 4; i++)
                Assert.True(mcs.GetPlayerPoisonCountTotal(i) == 0);
        }
    }
}