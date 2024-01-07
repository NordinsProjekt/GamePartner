namespace MtGDomain.Models
{
    public class MtGCardColor
    {
        public bool Blue { get; set; } = false;
        public bool White { get; set; } = false;
        public bool Red { get; set; } = false;
        public bool Black { get; set; } = false;
        public bool Green { get; set; } = false;

        public void SetAllToFalse() 
        { Blue = false; White = false; Red = false; Black = false; Green = false; }
    }
}
