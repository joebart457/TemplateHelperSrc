using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.Constants.Enums;

namespace Template.Frontend.Models
{
    class SymbolMacro
    {
        public string Symbol { get; set; }
        public string Value { get; set; }
        public ParameterTypeEnum Type { get; set; }
        public Func<List<SymbolMacro>, string> Fn { get; set; } = null;
    }
}
