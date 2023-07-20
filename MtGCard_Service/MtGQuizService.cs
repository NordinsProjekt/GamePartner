using Application.MtGCard_Service.Interface;
using Domain.MtGDomain.DTO;
using MtGCard_Service.DTO;
using MtGCard_Service.Interface;
using MtGDomain.DTO;
using MtGDomain.Enums;
using MtGDomain.Extensions;
using MtGDomain.States;

namespace MtGCard_Service
{
    public class MtGQuizService : IMtGQuizService
    {
        private readonly ICardSetBuffer buffer;
        private readonly IMtGCardRepository cardRepo;
        private MtGQuizState state = new();

        List<(string Name, string Code)> Sets = new()
            {
                ("The Dark", "DRK" ),
                //("Dark Ascension","DKA"),
                //("Innistrad","ISD")
            };

        public MtGQuizService(ICardSetBuffer buffer, IMtGCardRepository cardRepo)
        {
            this.buffer = buffer;
            this.cardRepo = cardRepo;
        }

        public async Task<List<(string Name, string Code)>> GetSupportedMtGSets()
        {
            List<(string Name, string Code)> newList = new();
            Sets.ForEach(x=> newList.Add(x));
            return newList;
        }

        public async Task<bool> StartQuiz(string setCode)
        {
            await PopulateBuffer();
            state.Score = 0;
            state.Loading = true;
            var cards = await GetCards();
            state.List = cards.Shuffle().Take(20).ToList();
            state.Max = state.List.Count();
            state.Index = 0;
            state.Loading = false;
            SetQuizCard();
            return true;
        }
        private async Task<List<MtGCardRecordDTO>> GetCards()
        {
            List<MtGCardRecordDTO>? cardsFromBuffer = buffer.GetSet("DRK");
            return cardsFromBuffer;
        }

        private async Task PopulateBuffer()
        {
            foreach (var set in Sets)
            {
                if (!buffer.DoesSetExist(set.Code))
                {
                    var cardsFromAPI = await cardRepo.GetAllCardsFromASet(set.Code);
                    var cleanedList = cardsFromAPI.RemoveMtGType(new string[] { "land", "planeswalker", "battle" });
                    buffer.AddSet(new MtGCardSet(cleanedList, set.Name, set.Code));
                }
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
            state.Result = state.GetCmcQuizResult(state.Score);
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
            state.Loading = false;
            return;
        }

        private List<MtGCardRecordDTO> FilterList(List<MtGCardRecordDTO> cards)
        {
            return cards.RemoveMtGType(new string[] { "land", "planeswalker", "battle" });
        }

        public MtGQuizState GetQuizState()
        {
            return state;
        }
    }
}
