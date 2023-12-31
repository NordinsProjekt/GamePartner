using Domain.MtGDomain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MtGCard_Service.Interface;
using MtGCard_Service.Models;
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

        if (await magicSetRepository.FindSetBySetCode(setCode))
            return Ok("Set already exist");

        try
        {
            await _magicCardService.SaveCardsFromSet(setCode);
            return Ok($"Cards from set {setCode} have been successfully saved.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while saving the cards.");
        }
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
    public async Task<IActionResult> Ping()
    {
        return Ok(new PingResponseRecordDto("Pong"));
    }
}