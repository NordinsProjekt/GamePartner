using MtGCard_API;
using MtGCard_Service;
using MtGCard_Service.Classes;
using MtGCard_Service.Classes.Extensions;
using MtGCard_Service.Extensions;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowTests.StepDefinitions
{
    [Binding]
    public class MtGCommanderServiceStepDefinitions
    {
        public MtGCommanderService MtGCommanderService { get; set; }
        public MtGPlayer PlayerOne { get; set; }

        public MtGCommanderServiceStepDefinitions()
        {
            MockData mockCardRepository = new MockData();
            MtGCommanderService = new(mockCardRepository, 4);
            PlayerOne = MtGCommanderService.GetPlayer(1);
        }

        [Given(@"A Player has (.*) life")]
        public void GivenAPlayerHasLife(int lifeTotal)
        {
            PlayerOne.LifeTotal = lifeTotal;
        }

        [When(@"Player takes (.*) damage")]
        public void WhenPlayerTakesDamage(int damage)
        {
            PlayerOne.DoDamage(damage);
        }

        [Then(@"Lifetotal should be (.*)")]
        public void ThenLifetotalShouldBe(int exceptedLife)
        {
            PlayerOne.LifeTotal.Should().Be(exceptedLife);
        }
    }
}
