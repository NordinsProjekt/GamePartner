using MtGDomain.DTO;
using MtGDomain.Enums;
using MtGDomain.States;
using static System.Net.Mime.MediaTypeNames;

namespace MtGDomain.Extensions
{
    public static class MtGQuizStateExtensions
    {
        public static ResultRecord GetColorQuizResult(this MtGQuizState state)
        {
            if (state.QuizCard.IsColorLess)
            {
                if (state.Model.Color.Black || state.Model.Color.Green || state.Model.Color.Red || state.Model.Color.Blue || state.Model.Color.White)
                    return new ResultRecord(false, state.QuizCard.ImageUrl);
            }

            if (state.QuizCard.DoesCardHaveThisColor(MtGColor.Black) != state.Model.Color.Black)
                return new ResultRecord(false, state.QuizCard.ImageUrl);

            if (state.QuizCard.DoesCardHaveThisColor(MtGColor.White) != state.Model.Color.White)
                return new ResultRecord(false, state.QuizCard.ImageUrl);

            if (state.QuizCard.DoesCardHaveThisColor(MtGColor.Red) != state.Model.Color.Red)
                return new ResultRecord(false, state.QuizCard.ImageUrl);

            if (state.QuizCard.DoesCardHaveThisColor(MtGColor.Green) != state.Model.Color.Green)
                return new ResultRecord(false, state.QuizCard.ImageUrl);

            if (state.QuizCard.DoesCardHaveThisColor(MtGColor.Blue) != state.Model.Color.Blue)
                return new ResultRecord(false, state.QuizCard.ImageUrl);

            return new ResultRecord(true, state.QuizCard.ImageUrl);

        }

        public static ResultRecord GetTypeQuizResult(this MtGQuizState state, string text)
        {
            if (state.QuizCard is null)
                throw new NullReferenceException("Card isnt set");
        
            var match = state.QuizCard.Types.Any(x => x.ToLower().Contains(text.ToLower()));
            if (match)
                return new ResultRecord(true, state.QuizCard.ImageUrl);

            return new ResultRecord(false, state.QuizCard.ImageUrl);
        }

        public static ResultRecord GetCmcQuizResult(this MtGQuizState state, int cmc)
        {
            if (state.QuizCard.Cmc == cmc)
                return new ResultRecord(true, state.QuizCard.ImageUrl);

            return new ResultRecord(false, state.QuizCard.ImageUrl);
        }
    }
}
