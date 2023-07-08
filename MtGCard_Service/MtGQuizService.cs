using Application.MtGCard_Service.Interface;
using Domain.MtGDomain.DTO;
using MtGCard_Service.Classes;
using MtGCard_Service.DTO;
using MtGCard_Service.Interface;
using MtGDomain.DTO;
using MtGDomain.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service
{
    public class MtGQuizService : IMtGQuizService
    {
        private readonly ICardSetBuffer buffer;
        private readonly IMtGCardRepository cardRepo;
        private MtGQuizModel model;
        public bool GameStart { get; set; } = false;
        public ResultRecord Result { get; set; }
        public List<MtGCardRecordDTO>? List { get; set; }
        public MtGCardRecordDTO? QuizCard { get; set; }
        private int Index { get; set; } = 0;
        private int Max { get; set; } = 0;
        private bool Loading { get; set; } = false;
        private int Score { get; set; } = 0;

        List<(string Name, string Code)> Sets = new()
            {
                ( "The Dark", "DRK" ),
                ("Dark Ascension","DKA"),
                ("Innistrad","ISD")
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
            model = new();
            Score = 0;
            Loading = true;
            var cards = await GetCards();
            List = FilterList(cards);
            List = List.Shuffle().Take(20).ToList();
            Max = List.Count();
            Index = 0;
            Loading = false;
            SetQuizCard();
            return true;
        }
        private async Task<List<MtGCardRecordDTO>> GetCards()
        {
            List<MtGCardRecordDTO>? cardsFromBuffer = buffer.GetSet("DRK");
            return cardsFromBuffer;
        }

        private async Task PopulateBuffer(CancellationToken cancellationToken)
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
        private void CheckAnswerColor()
        {
            //TODO Lägg color kollen innan manacostnaden
            if (QuizCard.ManaCost.Contains("W"))
            {
                if (model.Color.White is not true)
                {
                    Result = new ResultRecord(false, QuizCard.ImageUrl);
                    Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (QuizCard.ManaCost.Contains("B"))
            {
                if (model.Color.Black is not true)
                {
                    Result = new ResultRecord(false, QuizCard.ImageUrl);
                    Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (QuizCard.ManaCost.Contains("U"))
            {
                if (model.Color.Blue is not true)
                {
                    Result = new ResultRecord(false, QuizCard.ImageUrl);
                    Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (QuizCard.ManaCost.Contains("R"))
            {
                if (model.Color.Red is not true)
                {
                    Result = new ResultRecord(false, QuizCard.ImageUrl);
                    Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (QuizCard.ManaCost.Contains("G"))
            {
                if (model.Color.Green is not true)
                {
                    Result = new ResultRecord(false, QuizCard.ImageUrl);
                    Index++;
                    SetQuizCard();
                    return;
                }
            }

            if (QuizCard.IsColorLess)
            {
                if (model.Color.Black || model.Color.Green || model.Color.Red || model.Color.Blue || model.Color.White)
                {
                    Result = new ResultRecord(false, QuizCard.ImageUrl);
                    Index++;
                    SetQuizCard();
                    return;
                }
            }
            Score++;
            Index++;
            Result = new ResultRecord(true, QuizCard.ImageUrl);
            SetQuizCard();
        }

        private void CheckAnswerCmC()
        {
            if (QuizCard.Cmc == model.CmcValue)
            {
                Score++;
                Index++;
                Result = new ResultRecord(true, QuizCard.ImageUrl);
                SetQuizCard();
                return;
            }
            Index++;
            Result = new ResultRecord(false, QuizCard.ImageUrl);
            SetQuizCard();
        }

        private void CheckAnswer(string text)
        {
            var match = QuizCard.Types.Any(x => x.ToLower().Contains(text));
            if (match)
            {
                Score++;
                Index++;
                Result = new ResultRecord(true, QuizCard.ImageUrl);
                SetQuizCard();
                return;
            }
            Index++;
            Result = new ResultRecord(false, QuizCard.ImageUrl);
            SetQuizCard();
        }

        private void SetQuizCard()
        {
            if (Index > Max)
            {
                EndQuiz();
            }
            QuizCard = List[Index];
            Loading = false;
            GameStart = true;
        }

        private void EndQuiz()
        {
            model = new();
            List = new();
            QuizCard = null;
            GameStart = false;
            Loading = false;
            return;
        }

        private List<MtGCardRecordDTO> FilterList(List<MtGCardRecordDTO> cards)
        {
            return cards.RemoveMtGType(new string[] { "land", "planeswalker", "battle" });
        }
    }
}
