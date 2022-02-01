using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models;

namespace Template.Frontend.Builders
{
    static class DefaultMacrosBuilder
    {
        private static List<SymbolMacro> _macros = null;
        public static List<SymbolMacro> Macros { get { return Build(); } }
        public static List<SymbolMacro> Build()
        {
            if (_macros != null)
            {
                return _macros;
            }

            _macros = new List<SymbolMacro>();

            _macros.Add(new SymbolMacro
            {
                Symbol = "CreateEFModelFromTSQL",
                Value = "CreateEFModelFromTSQL",
                Fn = (List<SymbolMacro> macros) => { return "teststring"; }
            });

            return _macros;
        }
    }
}
