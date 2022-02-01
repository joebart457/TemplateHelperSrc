using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Frontend.Models.Entities
{
    class RunSessionEntity
    {
        public int Id { get; set; }
        public int RunDate { get; set; }
        public string OutputDirectory { get; set; }
    }
}
