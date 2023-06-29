using FormattingText.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingText.Services
{
    public class TextToPropertiesService : ITextToPropertiesService
    {
        public string[] StringToProperty(string text, string split, string type)
        {
            var temp = text.Split(split);
            List<string> properties = new List<string>();
            foreach (var item in temp)
            {
                properties.Add($"public {type} {item}" + " { get; set; };");
            }
            return properties.ToArray();
        }
    }
}
