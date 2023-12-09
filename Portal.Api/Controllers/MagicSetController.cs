using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
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

    [HttpGet("get-set")]
    public async Task<IActionResult> GetSet(string setCode)
    {
        if (string.IsNullOrWhiteSpace(setCode))
        {
            return BadRequest("Set code is required.");
        }
        var result = await _magicCardService.LoadCardsFromSet(setCode);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);

    }

    [HttpGet("get-set-list")]
    public async Task<IActionResult> GetSetList()
    {
        var result = _magicCardService.GetSetList();
        return Ok(result);
    }
}

