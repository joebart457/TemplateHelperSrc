using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Frontend.Services
{
    static class ListItemService
    {

        public static Ty Convert<Ty>(object item)
        {
            if (item == null) throw new Exception();
            return (Ty)item;
        }
    }
}
