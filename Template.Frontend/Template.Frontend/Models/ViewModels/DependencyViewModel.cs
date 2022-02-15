using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.Entities;

namespace Template.Frontend.Models.ViewModels
{
    public class DependencyViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }
        private int _projectId;
        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; OnPropertyChanged(nameof(ProjectId)); }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; OnPropertyChanged(nameof(Path)); }
        }

        public static DependencyViewModel FromEntity(DependencyEntity entity)
        {
            return new DependencyViewModel
            {
                Id = entity.Id,
                ProjectId = entity.ProjectId,
                Path = entity.Path
            };
        }

        public DependencyEntity ToEntity()
        {
            return new DependencyEntity
            {
                Id = Id,
                ProjectId = ProjectId,
                Path = Path
            };
        }

        public override string ToString()
        {
            return Path;
        }

    }
}
