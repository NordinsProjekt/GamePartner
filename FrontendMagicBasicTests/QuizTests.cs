using AngleSharpWrappers;
using Flurl.Http;
using Portal.Pages.MagicBasic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Sdk;
using FluentValidation;
using Application.MtGCard_Service.Interface;
using MtGCard_API;
using Microsoft.Extensions.DependencyInjection;
using AngleSharp.Dom;
using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Portal.Pages.MagicBasic.Components;

namespace FrontendMagicBasicTests
{

    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
    /// </summary>
    
    [Trait("Presentation", "Magic Quiz")]
    public class QuizTests : TestContext
    {

        private IRenderedComponent<Quiz> GetComponent()
        {
            Services.AddTransient<IMtGCardRepository, MockData>();
            return RenderComponent<Quiz>();
        }

        [Fact]
        public void DoesQuizHaveA_H1Block_ShouldBeTrue()
        {
            // Arrange
            var cut = GetComponent();

            // Assert if renderpage has this matching element
            cut.Find("h1").MarkupMatches("<h1>Quiz</h1>");
        }

        [Fact]
        public async Task StartQuiz_CheckIfButtonIsntThereAnymore_ShouldThrowElementNotFound()
        {
            var quiz = GetComponent();
            var buttonElements = quiz.FindAll("button");
            var button = buttonElements.Where(x => x.Id.Equals("startquiz")).FirstOrDefault();

            Assert.NotNull(button);
            button.Click();

            Assert.Throws<ElementNotFoundException>(() => quiz.Find("#startquiz"));
        }

        [Fact]
        public async Task StartQuiz_CheckIfTextIsShowing_ShouldFindTheText()
        {
            var quiz = GetComponent();
            var buttonElement = quiz.Find("button");

            buttonElement.Click();
            int count = quiz.FindAll("p").Where(x => x.InnerHtml.Equals("Quiz time")).Count();

            Assert.Equal(count, 1);

        }

        [Fact]
        public async Task StartQuiz_CheckIfButtonIsMissing_ShouldNotContainButton()
        {
            var quiz = GetComponent();
            var button = quiz.Find("#startquiz");

            button.Click();

            var html = quiz.Markup;

            Assert.DoesNotContain("#startquiz",html);
        }

        [Fact]
        public void StartQuiz_LandingOnPage_Bool_GameStart_ShouldBeSetToFalse()
        {
            var quiz = GetComponent();

            var result = quiz.Instance.GameStart;

            Assert.False(result);
        }

        [Fact]
        public void StartQuiz_ClickStartQuizButton_BoolShouldBeSetToTrue()
        {
            var quiz = GetComponent();
            var buttonElement = quiz.Find("button");

            buttonElement.Click();
            var result = quiz.Instance.GameStart;

            Assert.True(result);
        }

        [Fact]
        public async Task StartQuiz_PressButton_CheckIfCardsIsInList_ShouldBeMoreThanZero()
        {
            var quiz = GetComponent();

            var button = quiz.Find("#startquiz");
            await button.ClickAsync(new MouseEventArgs());

            var count = quiz.Instance.List.Count;

            Assert.True(count > 0);
        }

        [Fact]
        public async Task StartQuiz_DoesQuestionDivLoad_ShouldReturnTrue()
        {
            var quiz = GetComponent();
            var button = quiz.Find("#startquiz");

            await button.ClickAsync(new MouseEventArgs());
            var window = quiz.FindAll("#QuizWindow");
            
            Assert.True(window.Count() == 1);
        }

        [Fact]
        public async Task StartQuiz_DoesQuestionDivHaveFiveButtons_ShouldReturnTrue()
        {
            var quiz = GetComponent();
            var button = quiz.Find("#startquiz");

            await button.ClickAsync(new MouseEventArgs());
            var window = quiz.Find("#QuizWindow");
            var children = window.ChildNodes.Where(x => x.NodeName.Equals("BUTTON")).ToList();

            Assert.True(children.Count() == 5);
        }

        [Fact]
        public async Task StartQuiz_AnswerWrong_ScoreShouldBeZero()
        {
            var quiz = GetComponent();
            var button = quiz.Find("#startquiz");

            await button.ClickAsync(new MouseEventArgs());
            var correctButton = quiz.Find("#Artefact");
            await correctButton.ClickAsync(new MouseEventArgs());
            int score = quiz.FindComponent<ScoreBoard>().Instance.Score;

            Assert.True(score == 0);
        }
        
    }
}