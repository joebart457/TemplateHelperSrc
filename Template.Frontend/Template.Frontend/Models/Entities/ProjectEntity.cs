using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.ListItems;

namespace Template.Frontend.Models.Entities
{
    public class ProjectEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InputDirectory { get; set; }
        public string SandboxDirectory { get; set; }
        public DateTime CreatedDate { get; set; }

        public ProjectListItem ToListitem()
        {
            return new ProjectListItem
            {
                Id = Id,
                Name = Name,
                InputDirectory = InputDirectory,
                SandboxDirectory = SandboxDirectory,
                CreatedDate = CreatedDate
            };
        }
    }
}
