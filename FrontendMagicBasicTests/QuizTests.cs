
using Portal.Pages.MagicBasic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ApplicationLayer.MtGCard_Service.Interface;
using MtGCard_API;
using Bunit;
using Microsoft.AspNetCore.Components.Web;
using Portal.Pages.MagicBasic.Components;
using MtGCard_Service.Interface;
using Microsoft.AspNetCore.Components.Forms;
using MtGCard_Service;

namespace FrontendMagicBasicTests
{

    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
    /// </summary>
    
    [Trait("Presentation", "Magic Quiz")]
    public class QuizTests : TestContext
    {
        public QuizTests() 
        {
            Services.AddTransient<IMtGCardRepository, MockData>();
            Services.AddSingleton<ICardSetBuffer, MockData>();
            Services.AddTransient<IMtGQuizService, MtGQuizService>();
        }

        [Fact]
        public void DoesQuizHaveA_H1Block_ShouldBeTrue()
        {
            DisposeComponents();
            // Arrange
            var cut = RenderComponent<Quiz>();

            // Assert if renderpage has this matching element
            cut.FindAll("h1");
            Assert.Equal(1, cut.RenderCount);
            
        }

        [Fact]
        public void StartQuiz_CheckIfButtonIsntThereAnymore_ShouldThrowElementNotFound()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>(); 
            var inputselect = quiz.Find("select");
            inputselect.Change<string>("Type");
            var buttonElements = quiz.FindAll("button");

            var button = buttonElements.Where(x => x.Id.Equals("startquiz")).FirstOrDefault();

            Assert.NotNull(button);
            button.Click();

            Assert.Throws<ElementNotFoundException>(() => quiz.Find("#startquiz"));
        }

        [Fact]
        public void StartQuiz_CheckIfButtonIsMissing_ShouldNotContainButton()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>();
            var inputselect = quiz.Find("select");
            inputselect.Change<string>("Type");
            var button = quiz.Find("#startquiz");

            button.Click();

            var html = quiz.Markup;

            Assert.DoesNotContain("#startquiz",html);
        }

        [Fact]
        public void StartQuiz_LandingOnPage_Bool_GameStart_ShouldBeSetToFalse()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>();

            var result = quiz.Instance.State.GameStart;

            Assert.False(result);
        }

        [Fact]
        public async void StartQuiz_ClickStartQuizButton_BoolShouldBeSetToTrue()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>();
            var inputselect = quiz.Find("#QuizSetSelector");
            inputselect.Change<string>("The Brothers' War");

            inputselect = quiz.Find("#QuizTypeSelector");
            inputselect.Change<string>("Type");

            var button = quiz.Find("#startquiz");
            await button.ClickAsync(new MouseEventArgs());
            var result = quiz.Instance.State.GameStart;

            Assert.True(result);
        }

        [Fact]
        public async Task StartQuiz_PressButton_CheckIfCardsIsInList_ShouldBeMoreThanZero()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>();
            var inputselect = quiz.Find("#QuizSetSelector");
            inputselect.Change<string>("The Brothers' War");

            inputselect = quiz.Find("#QuizTypeSelector");
            inputselect.Change<string>("Type");

            var button = quiz.Find("#startquiz");
            await button.ClickAsync(new MouseEventArgs());

            var count = quiz.Instance.State.List.Count;

            Assert.True(count > 0);
        }

        [Fact]
        public async Task StartQuiz_DoesQuestionDivLoad_ShouldReturnTrue()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>();
            var inputselect = quiz.Find("#QuizSetSelector");
            inputselect.Change<string>("The Brothers' War");

            inputselect = quiz.Find("#QuizTypeSelector");
            inputselect.Change<string>("Type");

            var button = quiz.Find("#startquiz");
            await button.ClickAsync(new MouseEventArgs());
            var window = quiz.FindAll("#QuizWindowType");
            
            Assert.True(window.Count() == 1);
        }

        [Fact]
        public async Task StartQuiz_DoesQuestionDivHaveFiveButtons_ShouldReturnTrue()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>();
            var inputselect = quiz.Find("#QuizSetSelector");
            inputselect.Change<string>("The Brothers' War");

            inputselect = quiz.Find("#QuizTypeSelector");
            inputselect.Change<string>("Type");

            var button = quiz.Find("#startquiz");
            await button.ClickAsync(new MouseEventArgs());

            var window = quiz.Find("#QuizWindowType");
            var children = window.ChildNodes.Where(x => x.NodeName.Equals("BUTTON")).ToList();

            Assert.True(children.Count() == 5);
        }

        [Fact]
        public async Task StartQuiz_AnswerWrong_ScoreShouldBeZero()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>();
            var inputselect = quiz.Find("#QuizSetSelector");
            inputselect.Change<string>("The Brothers' War");

            inputselect = quiz.Find("#QuizTypeSelector");
            inputselect.Change<string>("Type");

            var button = quiz.Find("#startquiz");
            await button.ClickAsync(new MouseEventArgs());

            var correctButton = quiz.WaitForElement("#Artefact");            
            
            await correctButton.ClickAsync(new MouseEventArgs());
            int score = quiz.FindComponent<ScoreBoard>().Instance.Score;

            Assert.True(score == 0);
        }

        [Fact]
        public async Task StartQuiz_DoesQuizWindowCmc_ShouldReturnTrue()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>();
            var inputselect = quiz.Find("#QuizSetSelector");
            inputselect.Change<string>("The Brothers' War");

            inputselect = quiz.Find("#QuizTypeSelector");
            inputselect.Change<string>("CMC");

            var button = quiz.Find("#startquiz");
            await button.ClickAsync(new MouseEventArgs());
            var window = quiz.FindAll("#QuizWindowCMC");

            Assert.True(window.Count() == 1);
        }

        [Fact]
        public async Task StartQuizCmc_AnswerWrongOnQuestion1_CountShouldBeZero()
        {
            DisposeComponents();
            var quiz = RenderComponent<Quiz>();
            var inputselect = quiz.Find("#QuizSetSelector");
            inputselect.Change<string>("The Brothers' War");

            inputselect = quiz.Find("#QuizTypeSelector");
            inputselect.Change<string>("CMC");

            var button = quiz.Find("#startquiz");
            await button.ClickAsync(new MouseEventArgs());

            quiz.Find("#inputCmc").Change(100);
            await quiz.Find("#CmcCheck").ClickAsync(new MouseEventArgs());
            int score = quiz.FindComponent<ScoreBoard>().Instance.Score;
            Assert.Equal(0, score);
        }

    }
}