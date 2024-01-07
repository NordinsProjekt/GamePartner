using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using MtGCard_Service.Models;
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


    [HttpGet("GetQuiz/{numOfCards}/{setCode}")]
    [ProducesResponseType(typeof(MagicQuizDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetQuiz(string setCode, int numOfCards)
    {
        var serviceResult = await magicQuizService.GetQuizResult(numOfCards, setCode);
        if (serviceResult == null)
        {
            return NotFound();
        }

        return Ok(serviceResult);
    }
}