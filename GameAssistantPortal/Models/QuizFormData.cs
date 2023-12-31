using System.ComponentModel.DataAnnotations;
using MtGDomain.Enums;
using RazorSharedLib.Api;

namespace GameAssistantPortal.Models;

public class QuizFormData
{
    [Required(ErrorMessage = "Please select a magic set.")]
    public string MagicSet { get; set; }

    [Required(ErrorMessage = "Please select a quiz type.")]
    public QuizType QuizType { get; set; }
}