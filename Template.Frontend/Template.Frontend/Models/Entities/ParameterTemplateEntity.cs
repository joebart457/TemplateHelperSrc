using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.ListItems;

namespace Template.Frontend.Models.Entities
{
    public class ParameterTemplateEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ParameterTemplateListItem ToListItem()
        {
            return new ParameterTemplateListItem
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
