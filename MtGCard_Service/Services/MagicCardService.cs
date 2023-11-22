using Domain.MtGDomain.DTO;
using MtGCard_Service.Interface;
using MtGDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtGCard_Service.Services
{
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
                var magicCard = await ConvertToMagicCard(cardDto);
                await _cardRepository.AddAsync(magicCard);
            }
        }

        private async Task<MagicCard> ConvertToMagicCard(MtGCardRecordDTO cardDto)
        {
            var magicCard = new MagicCard
            {
                Id = Guid.NewGuid(),
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
                MagicSet = await _setRepository.FindOrCreateSet(cardDto.SetName, cardDto.Set),
                Rulings = cardDto.Rulings.Select(r => new MagicRuling
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Parse(r.Date),
                    Text = r.Text
                }).ToList(),
                Abilities = cardDto.Abilities.Select(a => _abilityRepository.FindOrCreateAbility(a)).ToList(),
                CardTypes = cardDto.Types.Select(t => _typeRepository.FindOrCreateCardType(t)).ToList(),
                SuperCardTypes = cardDto.SuperTypes.Select(st => _superTypeRepository.FindOrCreateSuperCardType(st)).ToList(),
                MagicLegalities = cardDto.Legalities.Select(l => _legalityRepository.FindOrCreateLegality(l.Format, l.LegalityName)).ToList()
            };

            return magicCard;
        }

    }
}
