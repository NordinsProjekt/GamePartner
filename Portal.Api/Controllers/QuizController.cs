using Microsoft.AspNetCore.Mvc;
using MtGCard_Service.Services;

namespace MtGApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : Controller
{
    private readonly MagicQuizService magicQuizService;

    public QuizController(MagicQuizService magicQuizService)
    {
        this.magicQuizService = magicQuizService;
    }


    [HttpGet("GetQuiz")]
    public IActionResult GetQuiz(string setCode, int numOfCards)
    {
        var serviceResult = magicQuizService.GetQuizResult(numOfCards, setCode);
        if (serviceResult == null) { return NotFound(); }

        return Ok(serviceResult);
    }
}
