using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.Constants.Enums;
using Template.Frontend.Models.ListItems;

namespace Template.Frontend.Models.Entities
{
    public class ParameterEntity
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string Symbol { get; set; }
        public ParameterTypeEnum Type { get; set; }
        public string Description { get; set; }

        public ParameterListItem ToListItem()
        {
            return new ParameterListItem
            {
                Id = Id,
                TemplateId = TemplateId,
                Symbol = Symbol,
                Type = Type,
                Description = Description,
                Changed = false
            };
        }
    }
}
