using Domain.MtGDomain.DTO;
using MtGDomain.Base;
using MtGDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MtGDomain.Enums;
using MtGDomain.Models.Extensions;

namespace MtGDomain.Models
{
    public class MtGCardObject : BaseValidate, IGetDto<MtGCardRecordDTO>
    {
        public string Name { get; set; }
        public string Id { get; set; }
        private string text;
        public List<MtGRulingRecord_DTO> Rulings { get; set; }
        private List<string>? abilities = new();
        public string ImageUrl { get; set; }
        public string MultiverseId { get; set; }
        public string[] Types { get; set; }
        public string[] SuperTypes { get; set; }
        public MtGCardObject() { }

        public string Text
        {
            get => text;
            set
            {
                abilities = CheckIfCreatureAbilityExist.GiveAbilityKeywordsFromText(value).ToList();
                text = value;
            }
        }
        public override bool IsModelValid()
        {
            SetRules();
            base.Validate(this);
            return IsValid;
        }

        public override void SetRules()
        {

        }
        
        public MtGCardRecordDTO GetDTO()
        {
            if (IsModelValid())
            {
                MtGCardRecordDTO dto = new MtGCardRecordDTO(Name, Id, Text, Rulings, abilities, ImageUrl, MultiverseId, Types, SuperTypes);
                return dto;
            }
            return default(MtGCardRecordDTO);

        }

    }
}
