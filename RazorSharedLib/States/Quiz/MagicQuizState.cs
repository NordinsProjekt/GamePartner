using MtGDomain.DTO;
using MtGDomain.Enums;
using MtGDomain.Models;
using RazorSharedLib.Api;
using RazorSharedLib.States.Buffer;
using RazorSharedLib.Extensions;

namespace RazorSharedLib.States.Quiz;

public class MagicQuizState : IMagicQuizState
{
    private readonly ApiClient _apiClient;
    private readonly IMagicBufferState _buffer;

    public List<MtGSetRecordDTO>? MagicSets { get; set; }
    public MtGSetRecordDTO? SelectedSet { get; set; }
    public QuizType? SelectedQuizType { get; set; }
    public MagicQuizDto? QuizDto { get; set; }
    public bool QuizStarted { get; set; }

    public int NumOfCards { get; set; } = 20;
    public bool QuizReady { get; set; }
    public int QuizScore { get; set; } = 0;
    public int QuizIndex { get; set; } = 0;
    public ResultRecord? Result { get; set; }
    public MtGQuizModel Model { get; set; } = new MtGQuizModel();
    public MagicQuizCardDto? CurrentCard => QuizDto.Cards.Skip(QuizIndex).Take(1).FirstOrDefault();


    public List<(string Name, QuizType Type)> QuizList { get; } = new()
    {
        ("Cmc", QuizType.CMC),
        ("Type", QuizType.Type),
        ("Color", QuizType.Color)
    };

    public MagicQuizState(ApiClient apiClient, IMagicBufferState buffer)
    {
        _apiClient = apiClient;
        _buffer = buffer;
        MagicSets = _buffer.GetMagicSetList();
    }

    public bool SetSelectedSet(string setCode)
    {
        var set = MagicSets.FirstOrDefault(x => x.SetCode.Equals(setCode));
        if (set is null) return false;

        SelectedSet = set;
        return true;
    }

    public async Task SetQuiz()
    {
        var quiz = await _apiClient.GetQuizAsync(SelectedSet!.SetCode, NumOfCards);
        if (quiz is null) return;

        var list = quiz.Cards.SelectMany(card => card.CardTypes).ToList();


        QuizDto = quiz;
        QuizScore = 0;
        QuizReady = true;
    }

    public void NextCard()
    {
        Result = null;
        Model = new MtGQuizModel();

        if (++QuizIndex != NumOfCards) return;
        EndQuiz();
    }

    public void CheckAnswer(string cardtype)
    {
        if (Result is not null) return;

        Result = new ResultRecord(CurrentCard.CardTypes.Contains(cardtype), CurrentCard.ImageUrl);
        if (Result.Correct) QuizScore++;
    }

    public void CheckAnswerColor()
    {
        if (Result is not null) return;

        var cardColor = CurrentCard.GetColorFromCard();
        var userAnswer = Model.GetColorFromUser();

        Result = new ResultRecord(cardColor == userAnswer, CurrentCard.ImageUrl);
        if (Result.Correct) QuizScore++;
    }

    public void CheckAnswerCmC()
    {
        if (Result is not null) return;

        Result = new ResultRecord(CurrentCard.Cmc == Model.CmcValue, CurrentCard.ImageUrl);
        if (Result.Correct) QuizScore++;
    }

    public void EndQuiz()
    {
        QuizReady = false;
        QuizIndex = 0;
        QuizScore = 0;
        SelectedQuizType = null;
        SelectedSet = null;
        Result = null;
        QuizDto = null;
        QuizStarted = false;
    }
}