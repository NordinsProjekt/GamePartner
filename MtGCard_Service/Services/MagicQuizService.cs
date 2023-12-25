using MtGCard_Service.Interface;
using MtGCard_Service.Models;
using MtGDomain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Services;

public class MagicQuizService
{
    private readonly IMagicSetRepository _magicSetRepository;

    public MagicQuizService(IMagicSetRepository magicSetRepository)
    {
        _magicSetRepository = magicSetRepository;
    }

    public async Task<MagicQuizDto?> GetQuizResult(int numOfCards, string setCode)
    {
        var set = await _magicSetRepository.GetSetQuizCardsByCode(setCode);
        if (set == null) { 
            return null; 
        }

        if (set.MagicCards.Count == 0) return null;

        return new MagicQuizDto(
            set.SetName,
            set.SetCode,
            set.MagicCards.Select(x =>
                new MagicQuizCardDto(
                    x.Id,
                    x.Name,
                    x.Cmc,
                    x.ManaCost,
                    x.CardTypes.Select(type => type.CardType.Name).ToList(),
                    x.ImageUrl
                )
            ).ToList().Shuffle().Take(numOfCards).ToList()
        );
    }
}
