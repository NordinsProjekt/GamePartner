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
            catch (Exception ex)
            {
                return new List<MtGCardRecordDTO>();
            }
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
    }
}