using Portal.Pages.MagicBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bunit;
using System.Threading.Tasks;
using Portal.Pages.MagicBasic;
using Portal.Pages.Magic;
using FluentValidation;

namespace FrontendMagicBasicTests.LifeCounter
{
    [Trait("Presentation", "Magic - LifeCounter")]

    public class LifeCounterTests : TestContext
    {

        [Theory]
        [InlineData(20, 21)]
        [InlineData(10, 11)]

        public void LifeCounter_AddLifeForPlayer1_ResultShouldBeExceptedResult(int start,int excepted)
        {
            var cut = RenderComponent<Portal.Pages.MagicBasic.LifeCounter>();
            cut.Instance.PlayersLifeTotal[0] = start;

            var clickableArea = cut.Find("#playerOneAddLife");
            clickableArea.Click();

            var result = cut.Instance.PlayersLifeTotal[0];

            Assert.Equal(excepted, result);
        }

        [Theory]
        [InlineData(20, 21)]
        [InlineData(10, 11)]

        public void LifeCounter_AddLifeForPlayer2_ResultShouldBeExceptedResult(int start, int excepted)
        {
            var cut = RenderComponent<Portal.Pages.MagicBasic.LifeCounter>();
            cut.Instance.PlayersLifeTotal[1] = start;

            var clickableArea = cut.Find("#playerTwoAddLife");
            clickableArea.Click();

            var result = cut.Instance.PlayersLifeTotal[1];

            Assert.Equal(excepted, result);
        }

        [Theory]
        [InlineData(20, 19)]
        [InlineData(10, 9)]

        public void LifeCounter_SubLifeForPlayer1_ResultShouldBeExceptedResult(int start, int excepted)
        {
            var cut = RenderComponent<Portal.Pages.MagicBasic.LifeCounter>();
            cut.Instance.PlayersLifeTotal[0] = start;

            var clickableArea = cut.Find("#playerOneSubLife");
            clickableArea.Click();

            var result = cut.Instance.PlayersLifeTotal[0];

            Assert.Equal(excepted, result);
        }

        [Theory]
        [InlineData(20, 19)]
        [InlineData(10, 9)]

        public void LifeCounter_SubLifeForPlayer2_ResultShouldBeExceptedResult(int start, int excepted)
        {
            var cut = RenderComponent<Portal.Pages.MagicBasic.LifeCounter>();
            cut.Instance.PlayersLifeTotal[1] = start;

            var clickableArea = cut.Find("#playerTwoSubLife");
            clickableArea.Click();

            var result = cut.Instance.PlayersLifeTotal[1];

            Assert.Equal(excepted, result);
        }

    }
}
