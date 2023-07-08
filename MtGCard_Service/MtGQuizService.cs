using Application.MtGCard_Service.Interface;
using Domain.MtGDomain.DTO;
using MtGCard_Service.DTO;
using MtGCard_Service.Interface;
using MtGDomain.DTO;
using MtGDomain.Extensions;

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
            state.List = FilterList(cards);
            state.List = state.List.Shuffle().Take(20).ToList();
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
                    buffer.AddSet(new MtGCardSet(cardsFromAPI, set.Name, set.Code));
                }
            }
        }
        public void CheckAnswerColor()
        {
            //TODO Lägg color kollen innan manacostnaden
            if (state.QuizCard.ManaCost.Contains("W"))
            {
                if (state.Model.Color.White is not true)
                {
                    state.Result = new ResultRecord(false, state.QuizCard.ImageUrl);
                    state.Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (state.QuizCard.ManaCost.Contains("B"))
            {
                if (state.Model.Color.Black is not true)
                {
                    state.Result = new ResultRecord(false, state.QuizCard.ImageUrl);
                    state.Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (state.QuizCard.ManaCost.Contains("U"))
            {
                if (state.Model.Color.Blue is not true)
                {
                    state.Result = new ResultRecord(false, state.QuizCard.ImageUrl);
                    state.Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (state.QuizCard.ManaCost.Contains("R"))
            {
                if (state.Model.Color.Red is not true)
                {
                    state.Result = new ResultRecord(false, state.QuizCard.ImageUrl);
                    state.Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (state.QuizCard.ManaCost.Contains("G"))
            {
                if (state.Model.Color.Green is not true)
                {
                    state.Result = new ResultRecord(false, state.QuizCard.ImageUrl);
                    state.Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (state.QuizCard.IsColorLess)
            {
                if (state.Model.Color.Black || state.Model.Color.Green || state.Model.Color.Red || state.Model.Color.Blue || state.Model.Color.White)
                {
                    state.Result = new ResultRecord(false, state.QuizCard.ImageUrl);
                    state.Index++;
                    SetQuizCard();
                    return;
                }
            }
            state.Score++;
            state.Index++;
            state.Result = new ResultRecord(true, state.QuizCard.ImageUrl);
            SetQuizCard();
        }

        public void CheckAnswerCmC()
        {
            if (state.QuizCard.Cmc == state.Model.CmcValue)
            {
                state.Score++;
                state.Index++;
                state.Result = new ResultRecord(true, state.QuizCard.ImageUrl);
                SetQuizCard();
                return;
            }
            state.Index++;
            state.Result = new ResultRecord(false, state.QuizCard.ImageUrl);
            SetQuizCard();
        }

        public void CheckAnswer(string text)
        {
            var match = state.QuizCard.Types.Any(x => x.ToLower().Contains(text));
            if (match)
            {
                state.Score++;
                state.Index++;
                state.Result = new ResultRecord(true, state.QuizCard.ImageUrl);
                SetQuizCard();
                return;
            }
            state.Index++;
            state.Result = new ResultRecord(false, state.QuizCard.ImageUrl);
            SetQuizCard();
        }

        private void SetQuizCard()
        {
            if (state.Index > state.Max)
            {
                EndQuiz();
            }
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
