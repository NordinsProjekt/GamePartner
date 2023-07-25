namespace MtGDomain.DTO
{
    public class MtGSearchFilter
    {
        public string Type { get; set; } = "";
        public string Format { get; set; } = "";
        public MtGCmcFilter CmcFilter {get;set;}
        public MtGColorFilter ColorFilter { get; set; }
    }
}
