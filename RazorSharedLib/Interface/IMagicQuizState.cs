using MtGDomain.DTO;
using MtGDomain.Enums;
using MtGDomain.Models;
using RazorSharedLib.Api;

namespace RazorSharedLib.States.Quiz;

public interface IMagicQuizState
{
    List<MtGSetRecordDTO>? MagicSets { get; set; }
    MtGSetRecordDTO? SelectedSet { get; set; }
    QuizType? SelectedQuizType { get; set; }
    MagicQuizDto? QuizDto { get; set; }
    List<(string Name, QuizType Type)> QuizList { get; }
    bool QuizStarted { get; set; }
    int NumOfCards { get; set; }
    bool QuizReady { get; set; }
    int QuizScore { get; set; }
    int QuizIndex { get; set; }
    ResultRecord? Result { get; set; }
    MtGQuizModel Model { get; set; }
    MagicQuizCardDto? CurrentCard { get; }
    bool SetSelectedSet(string setCode);
    Task SetQuiz();
    void NextCard();
    void CheckAnswer(string cardtype);
    void CheckAnswerColor();
    void CheckAnswerCmC();
    void EndQuiz();
}