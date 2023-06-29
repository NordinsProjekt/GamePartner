using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingText.Interfaces
{
    public interface ITextToPropertiesService
    {
        string[] StringToProperty(string Text, string split, string type);
    }
}
