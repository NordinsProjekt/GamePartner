using Domain.MtGDomain.DTO;
using MtGDomain.Extensions;
using MtGDomain.Models;
using MtGDomain.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._4_Domain.Extensions
{
    [Trait("Domain", "MtGQuizState Extensions")]
    public class MtGQuizStateExtensionTests
    {
        [Fact]
        public void CheckAnswerColor_SetBlackCard_GuessRed_ShouldReturnFalseResult()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { ManaCost = "{B}" }.GetDTO();

            state.QuizCard = testCard;
            state.Model.Color.Red = true;

            var result = state.GetColorQuizResult();

            Assert.False(result.Correct);
        }

        [Fact]
        public void CheckAnswerColor_SetBlackCard_GuessBlack_ShouldReturnTrueResult()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { ManaCost = "{B}" }.GetDTO();

            state.QuizCard = testCard;
            state.Model.Color.Black = true;

            var result = state.GetColorQuizResult();

            Assert.True(result.Correct);
        }

        [Fact]
        public void CheckAnswerColor_SetBlackWhiteCard_GuessBlack_ShouldReturnFalseResult()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { ManaCost = "{B}{W}" }.GetDTO();

            state.QuizCard = testCard;
            state.Model.Color.Black = true;

            var result = state.GetColorQuizResult();

            Assert.False(result.Correct);
        }

        [Fact]
        public void CheckAnswerColor_SetBlackWhiteCard_GuessBlackWhite_ShouldReturnTrueResult()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { ManaCost = "{B}{W}" }.GetDTO();

            state.QuizCard = testCard;
            state.Model.Color.Black = true;
            state.Model.Color.White = true;

            var result = state.GetColorQuizResult();

            Assert.True(result.Correct);
        }

        [Fact]
        public void CheckCmcQuiz_SetCardWithCMc3_Guess3_ShouldReturnTrue()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Cmc = 3 }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetCmcQuizResult(3);

            Assert.True(result.Correct);
        }

        [Fact]
        public void CheckCmcQuiz_SetCardWithCMc3_Guess2_ShouldReturnFalse()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Cmc = 3}.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetCmcQuizResult(2);

            Assert.False(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsCreature_GuessArtefact_ShouldReturnFalse()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Creature" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("artefact");

            Assert.False(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsCreature_GuessCreature_ShouldReturnTrue()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Creature" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("creature");

            Assert.True(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsArtefact_GuessArtefact_ShouldReturnTrue()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Artefact" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("artefact");

            Assert.True(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsArtefact_GuessCreature_ShouldReturnFalse()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Artefact" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("creature");

            Assert.False(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsInstant_GuessInstant_ShouldReturnTrue()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Instant" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("instant");

            Assert.True(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsInstant_GuessCreature_ShouldReturnFalse()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Instant" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("creature");

            Assert.False(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsSorcery_GuessSorcery_ShouldReturnTrue()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Sorcery" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("sorcery");

            Assert.True(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsSorcery_GuessCreature_ShouldReturnFalse()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Sorcery" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("creature");

            Assert.False(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsEnchantment_GuessEnchantment_ShouldReturnTrue()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Enchantment" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("enchantment");

            Assert.True(result.Correct);
        }

        [Fact]
        public void CheckTypeQuiz_SetCardAsEnchantment_GuessEnchantment_ShouldReturnFalse()
        {
            var state = new MtGQuizState();
            var testCard = new MtGCardObject() { Types = new string[] { "Enchantment" } }.GetDTO();

            state.QuizCard = testCard;
            var result = state.GetTypeQuizResult("creature");

            Assert.False(result.Correct);
        }
    }
}
