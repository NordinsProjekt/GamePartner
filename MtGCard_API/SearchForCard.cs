using ApplicationLayer.MtGCard_Service.Interface;
using Domain.MtGDomain.DTO;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using MtGCard_API.Extensions;
using MtGDomain.DTO;
using MtGDomain.Extensions;
using System.Collections.Generic;

namespace Infrastructure.MtGCard_API
{
    public class SearchForCard : IMtGCardRepository
    {
        private readonly IMtgServiceProvider mtgServiceProvider;

        public SearchForCard(IMtgServiceProvider mtgServiceProvider) 
        {
            this.mtgServiceProvider = mtgServiceProvider;
        }
        public async Task<List<MtGCardRecordDTO>> GetCardsByName(string name)
        {
            ICardService service = mtgServiceProvider.GetCardService();
            try
            {
                var result = await service.Where(x => x.Name, name)
                    .AllAsync();
                return ConvertICardToDTO(result);
            }
            catch (Exception)
            {
                return new List<MtGCardRecordDTO>();
            }
        }

        public async Task<List<MtGCardRecordDTO>> GetCardsByName(string name, MtGSearchFilter filter)
        {
            ICardService service = mtgServiceProvider.GetCardService();
            try
            {
                List<MtGCardRecordDTO> list = new List<MtGCardRecordDTO>();
                var temp = AddLevelOneFilters(service, filter);

                var result = await service.Where(x=>x.Name, name)
                    .Where(x => x.Page, 1)
                    .Where(x => x.PageSize, 100)
                    .AllAsync();
                int pageCount = result.PagingInfo.TotalPages;
                if (pageCount > 9) 
                {
                    return ConvertICardToDTO(result);
                }

                list.AddRange(ConvertICardToDTO(result));

                for (int i = 2; i <= pageCount; i++)
                {
                    var newCards = await service.Where(x => x.Name, name)
                    .Where(x => x.Page, i)
                    .Where(x => x.PageSize, 100)
                    .AllAsync();
                    list.AddRange(ConvertICardToDTO(newCards));
                }
                return list.FilterList(filter);
            }
            catch (Exception)
            {
                return new List<MtGCardRecordDTO>();
            }
        }

        public async Task<List<MtGCardRecordDTO>> GetRandomCardsFromApi(string setCode)
        {
            ICardService service = mtgServiceProvider.GetCardService();
            try
            {
                var result = await service.Where(x => x.Set, setCode)
                    .Where(x => x.Page, 1)
                    .Where(x => x.PageSize, 100)
                    .AllAsync();
                return ConvertICardToDTO(result);
            }
            catch (Exception)
            {
                return new List<MtGCardRecordDTO>();
            }
        }

        public async Task<List<MtGCardRecordDTO>> GetBoosterPackFromSet(string setcode)
        {
            ISetService serviceSet = mtgServiceProvider.GetSetService();
            var cards = await serviceSet.GenerateBoosterAsync(setcode);
            return ConvertICardToDTO(cards);
        }

        public async Task<List<MtGSetRecordDTO>> GetAllSets()
        {
            ISetService serviceSet = mtgServiceProvider.GetSetService();
            return ConvertISettoDTO(await serviceSet.AllAsync());
        }

        private List<MtGCardRecordDTO> ConvertICardToDTO(IOperationResult<List<ICard>> list)
        {
            List<MtGCardRecordDTO> dtoList = new();
            if (list.IsSuccess == false)
                return dtoList;
            
            foreach (var card in list.Value)
            {
                var convertedCard = MappingFunctions.MapICardToMtGCardObject(card).GetDTO();
                if (convertedCard != null)
                {
                    dtoList.Add(convertedCard);
                }
            }
            return dtoList;
        }

        private List<MtGSetRecordDTO> ConvertISettoDTO(IOperationResult<List<ISet>> list)
        {
            List<MtGSetRecordDTO> mtGSets = new List<MtGSetRecordDTO>();
            if (list.IsSuccess == false)
                return mtGSets;

            foreach (var set in list.Value)
            {
                mtGSets.Add(new MtGSetRecordDTO(set.Name,set.Code));
            }

            return mtGSets;
        }

        public async Task<List<MtGCardRecordDTO>> GetAllCardsFromASet(string setCode)
        {
            ICardService service = mtgServiceProvider.GetCardService();
            List<MtGCardRecordDTO> list = new List<MtGCardRecordDTO>();
            try
            {
                var result = await service.Where(x => x.Set, setCode)
                    .Where(x => x.Page, 1)
                    .Where(x => x.PageSize, 100)
                    .AllAsync();
                int pageCount = result.PagingInfo.TotalPages;
                list.AddRange(ConvertICardToDTO(result));
                for (int i = 2; i <= pageCount; i++)
                {
                    var newCards = await service.Where(x => x.Set, setCode)
                    .Where(x => x.Page, i)
                    .Where(x => x.PageSize, 100)
                    .AllAsync();
                    list.AddRange(ConvertICardToDTO(newCards));
                }
                return list;
            }
            catch (Exception ex)
            {
                return new List<MtGCardRecordDTO>();
            }
        }

        private IMtgQueryable<ICardService, CardQueryParameter> AddLevelOneFilters(
            IMtgQueryable<ICardService, CardQueryParameter> mtgQueryable, MtGSearchFilter filter)
        {
            var result = mtgQueryable.AddTypeFilter(filter);
            result = result.AddFormatFilter(filter);
            if (filter.CmcFilter is not null && 
                filter.CmcFilter.Cmc >= 0 && 
                filter.CmcFilter.ChoosenSymbol.Equals("=")) 
            {
                result = result.AddCmcFilter(filter);
            }

            return result;
        }
        
    }
}