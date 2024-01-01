using Domain.MtGDomain.DTO;
using MtGCard_Service.Interface;
using MtGDomain.DTO;
using MtGDomain.Entities;
using MtGDomain.Models;

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
    private readonly ILogRepository _logRepository;

    private MagicCardLists? BufferLists;
    private Guid MagicSetId;

    public MagicCardService(
        IMagicCardRepository cardRepository,
        IMtGCardRepository apiMtGCards,
        IMagicSetRepository setRepository,
        ICardTypeRepository typeRepository,
        ISuperCardTypeRepository superTypeRepository,
        IMagicAbilityRepository abilityRepository,
        IMagicLegalityRepository legalityRepository,
        ILogRepository logRepository)
    {
        _cardRepository = cardRepository;
        _apiMtGCards = apiMtGCards;
        _setRepository = setRepository;
        _typeRepository = typeRepository;
        _superTypeRepository = superTypeRepository;
        _abilityRepository = abilityRepository;
        _legalityRepository = legalityRepository;
        _logRepository = logRepository;
    }

    public async Task SaveCardsFromSet(string setCode)
    {
        await _logRepository.CreateLog("Magic", $"Getting Cards from {setCode}");

        var cards = await _apiMtGCards.GetAllCardsFromASet(setCode);

        await _logRepository.CreateLog("Magic", $"Done gettings cards from {setCode}");

        var convertedCards = new List<MagicCard>();

        await _logRepository.CreateLog("Magic", "Starting to convert the cards");

        foreach (var cardDto in cards)
        {
            try
            {
                var magicCard = await ConvertToMagicCard(cardDto);
                convertedCards.Add(magicCard);
            }
            catch (Exception ex)
            {
                //Log
            }
        }

        await _logRepository.CreateLog("Magic", "Saving.....");

        try
        {
            await _cardRepository.AddAllAsync(convertedCards);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        await _logRepository.CreateLog("Magic", "Saving Done!");
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

            var superCardTypes = item.SuperCardTypes?.Select(x => x.SuperCardType?.Name).ToArray() ??
                                 Array.Empty<string>();

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
            catch (Exception ex)
            {
                await _logRepository.CreateLog("Magic", ex.Message);
            }
        }

        return new(list, magicSet.SetName, magicSet.SetCode);
    }

    private async Task<MagicCard> ConvertToMagicCard(MtGCardRecordDTO cardDto)
    {
        if (cardDto == null)
        {
            return null;
        }

        BufferLists = await _cardRepository.GetAllListsForCard();
        MagicSetId = await _setRepository.FindOrCreateSet(cardDto.SetName, cardDto.Set);

        var cardId = Guid.NewGuid();
        var magicCard = new MagicCard
        {
            Id = cardId,
            Name = cardDto.Name,
            CardId = cardDto.Id,
            Text = cardDto.Text,
            ImageUrl = cardDto.ImageUrl,
            MultiverseId = cardDto.MultiverseId,
            Cmc = cardDto.Cmc,
            IsColorLess = cardDto.IsColorLess,
            IsMultiColor = cardDto.IsMultiColor,
            ManaCost = cardDto.ManaCost,
            CollectingNumber = cardDto.Number,
            MagicSetId = MagicSetId,
            Rulings = cardDto.Rulings != null
                ? cardDto.Rulings.Select(r => new MagicRuling
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Parse(r.Date),
                    Text = r.Text
                }).ToList()
                : new List<MagicRuling>(),
            CardTypes = await GetCardTypes(cardDto, cardId),
            SuperCardTypes = await GetCardSuperTypes(cardDto, cardId),
            Abilities = await GetCardAbilities(cardDto, cardId),
            MagicLegalities = await GetCardLegalities(cardDto, cardId)
        };

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
        result.ForEach(x => list.Add(new MtGSetRecordDTO(x.SetName, x.SetCode)));

        return list;
    }

    private async Task<List<CardTypeMagicCard>> GetCardTypes(MtGCardRecordDTO card, Guid cardId)
    {
        var cardTypes = new List<CardTypeMagicCard>();
        if (card.Types is null) return cardTypes;

        foreach (var type in card.Types)
        {
            var temp = BufferLists.CardTypes.FirstOrDefault(x => x.Name.Equals(type));

            if (temp is not null)
            {
                cardTypes.Add(new CardTypeMagicCard() { CardTypeId = temp.Id, MagicCardId = cardId });
            }
            else
            {
                var newCardTypeConnection = await _typeRepository.CreateCardType(type, cardId);

                cardTypes.Add(newCardTypeConnection);

                BufferLists.CardTypes.Add(new CardType() { Id = newCardTypeConnection.Id, Name = type });
            }
        }

        return cardTypes;
    }

    private async Task<List<MagicCardSuperCardType>> GetCardSuperTypes(MtGCardRecordDTO card, Guid cardId)
    {
        var cardSuperTypes = new List<MagicCardSuperCardType>();
        if (card.SuperTypes is null) return cardSuperTypes;

        foreach (var superTypes in card.SuperTypes)
        {
            var temp = BufferLists!.SuperCards.FirstOrDefault(x => x.Name.Equals(superTypes));

            if (temp is not null)
            {
                cardSuperTypes.Add(new MagicCardSuperCardType()
                    { SuperCardTypeId = temp.Id, MagicCardId = cardId });
            }
            else
            {
                var newSuperTypeConnection = await _superTypeRepository.CreateSuperCardType(superTypes, cardId);

                cardSuperTypes.Add(newSuperTypeConnection);

                BufferLists.SuperCards.Add(new SuperCardType() { Id = newSuperTypeConnection.Id, Name = superTypes });
            }
        }

        return cardSuperTypes;
    }

    private async Task<List<MagicAbilityMagicCard>> GetCardAbilities(MtGCardRecordDTO card, Guid cardId)
    {
        var cardAbilities = new List<MagicAbilityMagicCard>();
        if (card.Abilities is null) return cardAbilities;

        foreach (var ability in card.Abilities)
        {
            var temp = BufferLists!.MagicAbilities.FirstOrDefault(x => x.Name.Equals(ability));

            if (temp is not null)
            {
                cardAbilities.Add(new MagicAbilityMagicCard()
                    { MagicAbilityId = temp.Id, MagicCardId = cardId });
            }
            else
            {
                var newAbilityConnection = await _abilityRepository.CreateAbility(ability, cardId);

                cardAbilities.Add(newAbilityConnection);

                BufferLists.MagicAbilities.Add(new MagicAbility()
                    { Id = newAbilityConnection.MagicAbilityId, Name = ability });
            }
        }

        return cardAbilities;
    }

    private async Task<List<MagicCardMagicLegality>> GetCardLegalities(MtGCardRecordDTO card, Guid cardId)
    {
        var cardLegalities = new List<MagicCardMagicLegality>();
        if (card.Legalities is null) return cardLegalities;

        foreach (var legality in card.Legalities)
        {
            var temp = BufferLists.MagicLegality.FirstOrDefault(x =>
                x.Format.Equals(legality.Format) && x.LegalityName.Equals(legality.LegalityName));

            if (temp is not null)
            {
                cardLegalities.Add(new MagicCardMagicLegality()
                    { MagicLegalityId = temp.Id, MagicCardId = cardId });
            }
            else
            {
                var newLegalityConnection =
                    await _legalityRepository.CreateLegality(legality.Format, legality.LegalityName, cardId);

                cardLegalities.Add(newLegalityConnection);

                BufferLists.MagicLegality.Add(new MagicLegality()
                    { Id = newLegalityConnection.Id, Format = legality.Format, LegalityName = legality.LegalityName });
            }
        }

        return cardLegalities;
    }
}