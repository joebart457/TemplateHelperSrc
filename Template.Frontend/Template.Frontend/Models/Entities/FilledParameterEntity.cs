using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.Constants.Enums;
using Template.Frontend.Models.ListItems;

namespace Template.Frontend.Models.Entities
{
    class FilledParameterEntity
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public ParameterTypeEnum Type { get; set; }

        public FilledParameterListItem ToListItem()
        {
            return new FilledParameterListItem
            {
                Id = Id,
                TemplateId = TemplateId,
                TemplateName = TemplateName,
                Symbol = Symbol,
                Type = Type,
                Description = Description,
                Value = "",
                Changed = false
            };
        }
    }
}
