using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template_processor.Services
{
    class SymbolResolverService
    {
        private Dictionary<string, string> Symbols = new Dictionary<string, string>();

        public SymbolResolverService()
        {
            Symbols.Add("{itemname}", "MyItem");
            Symbols.Add("{ctrlName}", "MyItem");
            Symbols.Add("{specificKey}", "!!key!!");
        }
        public void Resolve(ref string str)
        {
            foreach (KeyValuePair<string, string> kv in Symbols)
            {
                str = str.Replace(kv.Key, kv.Value);
            }
        }
    }
}
