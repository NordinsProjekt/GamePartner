using Microsoft.AspNetCore.Mvc;
using MtGCard_Service.Interface;

namespace MtGApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MagicCardController : Controller
{
    private readonly IMagicCardRepository _cardRepository;

    public MagicCardController(IMagicCardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }
}