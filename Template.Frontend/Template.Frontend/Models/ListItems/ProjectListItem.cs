using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.Entities;

namespace Template.Frontend.Models.ListItems
{
    class ProjectListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InputDirectory { get; set; }
        public string SandboxDirectory { get; set; }
        public string SqlDirectory { get; set; }
        public DateTime CreatedDate { get; set; }
        public ProjectEntity ToEntity()
        {
            return new ProjectEntity
            {
                Id = Id,
                Name = Name,
                InputDirectory = InputDirectory,
                SandboxDirectory = SandboxDirectory,
                SqlDirectory = SqlDirectory,
                CreatedDate = CreatedDate
            };
        }

        public override string ToString()
        {
            return $"({Id}) {Name}";
        }
    }
}
