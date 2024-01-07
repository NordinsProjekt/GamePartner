using Microsoft.AspNetCore.Mvc;
using MtGCard_Service.Interface;
using MtGCard_Service.Models;
using MtGCard_Service.Services;

namespace Portal.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MagicSetController : Controller
{
    private readonly MagicCardService _magicCardService;
    private readonly IMagicSetRepository _magicSetRepository;

    public MagicSetController(MagicCardService magicCardService, IMagicSetRepository magicSetRepository)
    {
        _magicCardService = magicCardService;
        _magicSetRepository = magicSetRepository;
    }

    [HttpPost("save-set/{setCode}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SaveSet(string setCode)
    {
        if (string.IsNullOrWhiteSpace(setCode))
        {
            return BadRequest("Set code is required.");
        }

        if (await _magicSetRepository.FindSetBySetCode(setCode))
            return Ok("Set already exist");

        try
        {
            var response = await _magicCardService.SaveCardsFromSet(setCode);
            return Ok(response
                ? $"Cards from set {setCode} have been successfully saved."
                : "Got 0 cards from Wizards, not saving");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while saving the cards.");
        }
    }

    [HttpGet("get-set/{setCode}")]
    [ProducesResponseType(typeof(SingleMagicSetResponseRecordDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetSet(string setCode)
    {
        if (setCode.Length != 3) return BadRequest();

        var set = await _magicCardService.GetSetBySetCode(setCode);
        return Ok(new SingleMagicSetResponseRecordDto(set.SetName, set.SetCode, set.List));
    }

    [HttpGet("get-set-list")]
    [ProducesResponseType(typeof(MagicSetResponseRecordDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSetList()
    {
        var result = await _magicCardService.GetSetList();

        return Ok(new MagicSetResponseRecordDto(result.Count, result));
    }

    [HttpGet("Ping")]
    [ProducesResponseType(typeof(PingResponseRecordDto), StatusCodes.Status200OK)]
    public IActionResult Ping()
    {
        return Ok(new PingResponseRecordDto("Pong"));
    }
}