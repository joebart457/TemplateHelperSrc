using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.ListItems;
using Template.Frontend.Models.ViewModels;
using Template.Frontend.Services;
using Template.Frontend.Windows.Dialogs;

namespace Template.Frontend.DataContexts.Pages
{
    class ProjectListDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
        }

        private void RaisePropertyChanged(string info = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        public ProjectListDataContext()
        {
            CreateProjectCommand = new RelayCommand(CreateProject);
            RefreshProjectList();
        }


        private List<ProjectViewModel> _projects = new List<ProjectViewModel>();
        public List<ProjectViewModel> Projects
        {
            get { return _projects; }
            set { _projects = value; RaisePropertyChanged(nameof(Projects)); }
        }

        public RelayCommand CreateProjectCommand { get; private set; }
        private void CreateProject()
        {
            CreateEditProjectDialog dialog = new CreateEditProjectDialog(new ProjectViewModel
            {
                Id = -1,
                Name = "",
                InputDirectory = "",
                SandboxDirectory = "",
                AssignedTemplates = new List<ParameterTemplateListItem>(),
                CreatedDate = DateTime.Now
            });
            if (dialog.ShowDialog().Value)
            {
              
                ContextService.ProjectRepository.UpsertProject(dialog.Result.ToEntity(), dialog.Result.AssignedTemplates.Select(x => x.ToEntity()).ToList());
                RefreshProjectList();
            }
        }

        public void RefreshProjectList()
        {
            Projects = ContextService.ProjectRepository.GetAllProjects().Select(x => ProjectViewModel.FromEntity(x)).ToList();
        }

    }
}
