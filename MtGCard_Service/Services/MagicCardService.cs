using Domain.MtGDomain.DTO;
using MtGCard_Service.Interface;
using MtGDomain.DTO;
using MtGDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Services;

public class MagicCardService : IMagicCardService
{
    private readonly IMagicCardRepository _cardRepository;
    private readonly IMtGCardRepository _apiMtGCards;
    private readonly IMagicSetRepository _setRepository;
    private readonly ICardTypeRepository _typeRepository;
    private readonly ISuperCardTypeRepository _superTypeRepository;
    private readonly IMagicAbilityRepository _abilityRepository;
    private readonly IMagicLegalityRepository _legalityRepository;

    public MagicCardService(
        IMagicCardRepository cardRepository,
        IMtGCardRepository apiMtGCards,
        IMagicSetRepository setRepository,
        ICardTypeRepository typeRepository,
        ISuperCardTypeRepository superTypeRepository,
        IMagicAbilityRepository abilityRepository,
        IMagicLegalityRepository legalityRepository)
    {
        _cardRepository = cardRepository;
        _apiMtGCards = apiMtGCards;
        _setRepository = setRepository;
        _typeRepository = typeRepository;
        _superTypeRepository = superTypeRepository;
        _abilityRepository = abilityRepository;
        _legalityRepository = legalityRepository;
    }

    public async Task SaveCardsFromSet(string setCode)
    {
        var cards = await _apiMtGCards.GetAllCardsFromASet(setCode);
        foreach (var cardDto in cards)
        {
            try
            {
                var magicCard = await ConvertToMagicCard(cardDto);
                await _cardRepository.AddAsync(magicCard);
            }
            catch (Exception ex)
            {
                //Log
            }
        }
    }

    public async Task<MtGCardSet> LoadCardsFromSet(string setCode)
    {
        var list = new List<MtGCardRecordDTO>();

        var magicSet = await _setRepository.GetSetByCode(setCode);
        if (magicSet is null)
            return null;

        // Convert to RecordDTO
        foreach (var item in magicSet.MagicCards)
        {
            if (item == null) continue; // Skip if item is null

            // Handle potential null values in collections
            var rulings = item.Rulings?.Select(x => new MtGRulingRecord_DTO(
                Date: x.Date.ToString(),
                Text: x.Text)).ToList() ?? new List<MtGRulingRecord_DTO>();

            var abilities = item.Abilities?.Select(x => x.MagicAbility?.Name).ToList() ?? new List<string>();

            var cardTypes = item.CardTypes?.Select(x => x.CardType?.Name).ToArray() ?? Array.Empty<string>();

            var superCardTypes = item.SuperCardTypes?.Select(x => x.SuperCardType?.Name).ToArray() ?? Array.Empty<string>();

            var legalities = item.MagicLegalities?.Select(x => new MtGLegality(
                Format: x.MagicLegality?.Format,
                LegalityName: x.MagicLegality?.LegalityName)).ToList() ?? new List<MtGLegality>();

            // Create DTO object with named arguments for clarity
            try
            {
                var recordDto = new MtGCardRecordDTO(
                    Name: item.Name,
                    Id: item.CardId,
                    Text: item.Text,
                    Rulings: rulings,
                    Abilities: abilities,
                    ImageUrl: item.ImageUrl,
                    MultiverseId: item.MultiverseId,
                    Types: cardTypes,
                    SuperTypes: superCardTypes,
                    Cmc: item.Cmc,
                    IsColorLess: item.IsColorLess,
                    IsMultiColor: item.IsMultiColor,
                    ManaCost: item.ManaCost,
                    SetName: item.MagicSet?.SetName,
                    Set: item.MagicSet?.SetCode,
                    Number: item.CollectingNumber,
                    Legalities: legalities
                );
                list.Add(recordDto);
            }
            catch ( Exception ex ) { }
        }

        return new(list, magicSet.SetName, magicSet.SetCode); 
    }

    private async Task<MagicCard> ConvertToMagicCard(MtGCardRecordDTO cardDto)
    {
        if (cardDto == null)
        {
            return null;
        }

        var cardId = Guid.NewGuid();
        var magicCard = new MagicCard
        {
            Id = cardId,
            Name = cardDto.Name ?? string.Empty,
            CardId = cardDto.Id ?? string.Empty,
            Text = cardDto.Text ?? string.Empty,
            ImageUrl = cardDto.ImageUrl ?? string.Empty,
            MultiverseId = cardDto.MultiverseId ?? string.Empty,
            Cmc = cardDto.Cmc,
            IsColorLess = cardDto.IsColorLess,
            IsMultiColor = cardDto.IsMultiColor,
            ManaCost = cardDto.ManaCost ?? string.Empty,
            CollectingNumber = cardDto.Number ?? string.Empty,
            MagicSetId = await _setRepository.FindOrCreateSet(cardDto.SetName, cardDto.Set),
            Rulings = cardDto.Rulings != null ? cardDto.Rulings.Select(r => new MagicRuling
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Parse(r.Date),
                Text = r.Text ?? string.Empty
            }).ToList() : new List<MagicRuling>(),
            CardTypes = cardDto.Types != null
                ? await Task.WhenAll(cardDto.Types.Select(async t => await _typeRepository.FindOrCreateCardType(t, cardId)))
                : new List<CardTypeMagicCard>(),
            SuperCardTypes = cardDto.SuperTypes != null
                ? await Task.WhenAll(cardDto.SuperTypes.Select(async st => await _superTypeRepository.FindOrCreateSuperCardType(st, cardId)))
                : new List<MagicCardSuperCardType>(),
        };

        var abilities = new List<MagicAbilityMagicCard>();
        if (cardDto.Abilities != null)
        {
            foreach (var ability in cardDto.Abilities)
            {
                var abilityResult = await _abilityRepository.FindOrCreateAbility(ability, cardId);
                abilities.Add(abilityResult);
            }
        }
        magicCard.Abilities = abilities;

        var legalities = new List<MagicCardMagicLegality>();
        if (cardDto.Legalities != null)
        {
            foreach (var legality in cardDto.Legalities)
            {
                var legalityResult = await _legalityRepository.FindOrCreateLegality(legality.Format, legality.LegalityName, cardId);
                legalities.Add(legalityResult);
            }
        }
        magicCard.MagicLegalities = legalities;


        return magicCard;
    }

    public async Task<MtGCardSet> GetSetBySetCode(string setCode)
    {
        return await LoadCardsFromSet(setCode);
    }

    public async Task<List<MtGSetRecordDTO>> GetSetList()
    {
        var list = new List<MtGSetRecordDTO>();
        var result = await _setRepository.GetAll();
        result.ForEach(x=> list.Add(new(x.SetName, x.SetCode)));
        return list;
    }
}
