using Domain.MtGDomain.DTO;
using MtGCard_Service.Interface;
using MtGDomain.DTO;
using MtGDomain.Extensions;
using MtGDomain.Hashmaps;
using MtGDomain.States;

namespace MtGCard_Service
{
    public class MtGQuizService : IMtGQuizService
    {
        private readonly ICardSetBuffer buffer;
        private readonly IMtGCardRepository cardRepo;
        private readonly IMagicCardService magicCardService;
        private MtGQuizState state = new();

        public MtGQuizService(ICardSetBuffer buffer, IMtGCardRepository cardRepo, IMagicCardService magicCardService)
        {
            this.buffer = buffer;
            this.cardRepo = cardRepo;
            this.magicCardService = magicCardService;
        }

        public async Task<List<MtGSetRecordDTO>> GetSupportedMtGSets()
        {
            var cardSets = await magicCardService.GetSetList();
            return cardSets.Select(x => new MtGSetRecordDTO(x.SetName, x.SetCode)).ToList();
        }

        public async Task<bool> StartQuiz(string setCode)
        {
            await AddSetToBuffer(setCode);
            state.Score = 0;
            state.Loading = true;
            state.Heading = state.Model.QuizSet +" Edition";
            var cards = await GetCards(setCode);
            state.List = cards.RemoveMtGType(new string[] { "land", "planeswalker", "battle" }).Shuffle().Take(20).ToList();
            state.Max = state.List.Count();
            state.Index = 0;
            state.Loading = false;
            SetQuizCard();
            return true;
        }
        private async Task<List<MtGCardRecordDTO>> GetCards(string setCode)
        {
            List<MtGCardRecordDTO>? cardsFromBuffer = buffer.GetSet(setCode);
            return await Task.FromResult(cardsFromBuffer);
        }

        private async Task AddSetToBuffer(string setCode)
        {
            if (!buffer.DoesSetExist(setCode))
            {
                var cardsFromAPI = await cardRepo.GetAllCardsFromASet(setCode);
                buffer.AddSet(new MtGCardSet(cardsFromAPI, setCode, ""));
            }
        }

        public void CheckAnswerColor()
        {
            state.Result = state.GetColorQuizResult();
            if (state.Result.Correct)
            {
                state.Score++;
                state.Index++;
                SetQuizCard();
                return;
            }
            state.Index++;
            SetQuizCard();
            return;
        }

        public void CheckAnswerCmC()
        {
            state.Result = state.GetCmcQuizResult(state.Model.CmcValue);
            if (state.Result.Correct)
            {
                state.Score++;
                state.Index++;
                SetQuizCard();
                return;
            }
            state.Index++;
            SetQuizCard();
        }

        public void CheckAnswer(string text)
        {
            state.Result = state.GetTypeQuizResult(text);
            if (state.Result.Correct)
            {
                state.Score++;
                state.Index++;
                SetQuizCard();
                return;
            }
            state.Index++;
            SetQuizCard();
        }

        private void SetQuizCard()
        {
            if (state.Index >= state.Max)
            {
                EndQuiz();
                return;
            }
            state.Model.Color.SetAllToFalse();
            state.QuizCard = state.List[state.Index];
            state.Loading = false;
            state.GameStart = true;
        }

        public void EndQuiz()
        {
            state.Model = new();
            state.List = new();
            state.QuizCard = null;
            state.GameStart = false;
            state.Result = null;
            state.Loading = false;
        }

        public MtGQuizState GetQuizState()
        {
            return state;
        }
    }
}
