using Microsoft.AspNetCore.Mvc;
using MtGCard_Service.Services;
using MtGDomain.DTO;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MagicSetController : Controller
{
    private readonly MagicCardService _magicCardService;

    public MagicSetController(MagicCardService magicCardService)
    {
        _magicCardService = magicCardService;
    }

    [HttpPost("save-set")]
    public async Task<IActionResult> SaveSet(string setCode)
    {
        if (string.IsNullOrWhiteSpace(setCode))
        {
            return BadRequest("Set code is required.");
        }

        try
        {
            await _magicCardService.SaveCardsFromSet(setCode);
            return Ok($"Cards from set {setCode} have been successfully saved.");
        }
        catch (Exception ex)
        {
            // Log the exception details
            return StatusCode(500, "An error occurred while saving the cards.");
        }
    }
}

