using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MtGCard_Service.Interface;
using MtGCard_Service.Services;
using MtGDomain.DTO;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MagicSetController : Controller
{
    private readonly MagicCardService _magicCardService;
    private readonly IMagicSetRepository magicSetRepository;

    public MagicSetController(MagicCardService magicCardService, IMagicSetRepository magicSetRepository)
    {
        _magicCardService = magicCardService;
        this.magicSetRepository = magicSetRepository;
    }

    [HttpPost("save-set")]
    public async Task<IActionResult> SaveSet(string setCode)
    {
        if (string.IsNullOrWhiteSpace(setCode))
        {
            return BadRequest("Set code is required.");
        }

        if (await magicSetRepository.FindSetBySetCode(setCode))
            return Ok("Set already exist");

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

