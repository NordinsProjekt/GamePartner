using Application.MtGCard_Service.DTO;
using Application.MtGCard_Service.Interface;
using Domain.MtGDomain.DTO;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;

namespace Infrastructure.MtGCard_API
{
    public class SearchForCard : IMtGCardRepository
    {
        public async Task<List<MtGCardRecordDTO>> GetCardsByName(string name)
        {
            IMtgServiceProvider serviceProvider = new MtgServiceProvider();
            ICardService service = serviceProvider.GetCardService();
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

        private List<MtGCardRecordDTO> ConvertICardToDTO(IOperationResult<List<ICard>> list)
        {
            if (list.IsSuccess == false)
                return default;
            List<MtGCardRecordDTO> dtoList = new();
            foreach (var card in list.Value)
                dtoList.Add(MappingFunctions.MapICardToNewDto(card));
            return dtoList;
        }
    }
}