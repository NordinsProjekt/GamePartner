using MtGCard_Service.DTO;
using Domain.MtGDomain.DTO;
using MtGCard_Service.Interface;

namespace MtGCard_Service
{
    public class MtGCardService
    {
        private readonly IMtGCardRepository _repository;
        public MtGCardService(IMtGCardRepository _rep) =>
            _repository = _rep;

        public async Task<List<MtGCardRecordDTO>> GetCardByName(string name)
        {
            var result = await _repository.GetCardsByName(name);
            //Bara kort som har unikt namn och som har en bild
            return result.Where(img => img.ImageUrl != "").Where(img => img.ImageUrl != null).GroupBy(x => x.Name).Select(f => f.First()).ToList();
        }
    }
}