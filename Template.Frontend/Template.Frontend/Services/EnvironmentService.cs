using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.ViewModels.Environment;

namespace Template.Frontend.Services
{
    class EnvironmentService
    {
        public static List<MochjObjectViewModel> Flatten(Mochj._Storage.Environment environment)
        {
            List<MochjObjectViewModel> values = new();
            if (environment == null)
            {
                return values;
            }
            var lookup = environment.Lookup;
            foreach(var kv in lookup)
            {
                if (kv.Value.Type.Is(Mochj.Enums.DataTypeEnum.Namespace))
                {
                    var children = Flatten(Mochj.Services.TypeMediatorService.ToNativeType<Mochj._Storage.Environment>(kv.Value));
                    values.Add(new MochjObjectViewModel(kv.Key, kv.Value, children));
                } else
                {
                    values.Add(new MochjObjectViewModel(kv.Key, kv.Value));
                }
            }
            values.Sort((a, b) => { return a.Data.Type.Is(Mochj.Enums.DataTypeEnum.Namespace) ? -1 : 1; });

            return values;
        }

    }
}
