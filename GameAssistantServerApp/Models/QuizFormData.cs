using System.ComponentModel.DataAnnotations;
using MtGDomain.Enums;

namespace GameAssistantServerApp.Models;

public class QuizFormData
{
    [Required(ErrorMessage = "Please select a magic set.")]
    public string MagicSet { get; set; }

    [Required(ErrorMessage = "Please select a quiz type.")]
    public QuizType QuizType { get; set; }
}