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
using MtGDomain.DTO;

namespace MtGDomain.Models
{
    public class MtGCardObject : BaseValidate, IGetDto<MtGCardRecordDTO>
    {
        public string Name { get; set; } = "";
        public string Id { get; set; } = "";
        private string text;
        public List<MtGRulingRecord_DTO> Rulings { get; set; } = new List<MtGRulingRecord_DTO>();
        private List<string>? abilities = new();
        public string ImageUrl { get; set; } = "";
        public string MultiverseId { get; set; } = "";
        public string[] Types { get; set; } = new string[] { };
        public string[] SubTypes { get; set; } = new string[] { };
        public string[] SuperTypes { get; set; } = new string[] { };
        public int Cmc { get; set; } = -1;
        public string SetName { get; set; } = "";
        public string Set { get; set; } = "";
        public string Number { get; set; } = "";
        public bool IsColorLess { get; set; } = false;
        public bool IsMultiColor { get; set; } = false;
        public string ManaCost { get; set; } = "";
        public List<MtGLegality> Legalities { get; set; } = new();

        public MtGCardObject()
        {
        }

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
                MtGCardRecordDTO dto = new MtGCardRecordDTO(Name, Id, Text, Rulings, abilities, ImageUrl, MultiverseId,
                    SubTypes, Types,
                    SuperTypes, Cmc, IsColorLess, IsMultiColor, ManaCost, SetName, Set, Number, Legalities);
                return dto;
            }

            return default(MtGCardRecordDTO);
        }
    }
}