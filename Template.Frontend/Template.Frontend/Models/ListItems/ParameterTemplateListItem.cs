using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.Entities;

namespace Template.Frontend.Models.ListItems
{
   public  class ParameterTemplateListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ParameterTemplateEntity ToEntity()
        {
            return new ParameterTemplateEntity
            {
                Id = Id,
                Name = Name
            };
        }

        public override string ToString()
        {
            return $"({Id}) {Name}";
        }
    }
}
