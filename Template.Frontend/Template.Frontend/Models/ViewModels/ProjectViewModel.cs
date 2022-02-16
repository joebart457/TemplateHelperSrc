using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Template.Frontend.Models.Entities;
using Template.Frontend.Models.ListItems;
using Template.Frontend.Services;
using Template.Frontend.Windows.Dialogs;

namespace Template.Frontend.Models.ViewModels
{
    public class ProjectViewModel: INotifyPropertyChanged
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

        public ProjectViewModel()
        {
            ShowMoreActionsCommand = new RelayCommand<Button>(ShowMoreActions);
            EditProjectCommand = new RelayCommand(EditProject);
            EditDependenciesCommand = new RelayCommand(EditDependencies);
            _moreActionsMenu.Items.Add(new MenuItem { Header = "Edit", Command = EditProjectCommand });
            _moreActionsMenu.Items.Add(new MenuItem { Header = "Dependencies", Command = EditDependenciesCommand });
        }

        private int _id;
        private string _name = "";
        private string _inputDirectory = "";
        private string _sandboxDirectory = "";
        private DateTime _createdDate;
        private List<ParameterTemplateListItem> _assignedTemplates = new List<ParameterTemplateListItem>();
        private string _dependencies;
        public int Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(nameof(Id)); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(nameof(Name)); }
        }
        public string InputDirectory
        {
            get { return _inputDirectory; }
            set { _inputDirectory = value; RaisePropertyChanged(nameof(InputDirectory)); }
        }
        public string SandboxDirectory
        {
            get { return _sandboxDirectory; }
            set { _sandboxDirectory = value; RaisePropertyChanged(nameof(SandboxDirectory)); }
        }
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; RaisePropertyChanged(nameof(CreatedDate)); }
        }
        public List<ParameterTemplateListItem> AssignedTemplates
        {
            get { return _assignedTemplates; }
            set { _assignedTemplates = value; RaisePropertyChanged(nameof(AssignedTemplates)); }
        }
        public string Dependencies
        {
            get { return _dependencies; }
            set { _dependencies = value; RaisePropertyChanged(nameof(Dependencies)); }
        }

        private ContextMenu _moreActionsMenu = new ContextMenu();

        public RelayCommand<Button> ShowMoreActionsCommand { get; private set; }
        public void ShowMoreActions(Button sender)
        {
            _moreActionsMenu.PlacementTarget = sender;
            _moreActionsMenu.IsOpen = true;
        }

        public RelayCommand EditProjectCommand { get; private set; }
        public void EditProject()
        {
            var assignedTemplatesCopy = new List<ParameterTemplateListItem>();
            assignedTemplatesCopy.AddRange(_assignedTemplates);

            CreateEditProjectDialog dialog = new CreateEditProjectDialog(
                new ProjectViewModel
                {
                    Id = _id,
                    Name = _name,
                    InputDirectory = _inputDirectory,
                    SandboxDirectory = _sandboxDirectory,
                    AssignedTemplates = assignedTemplatesCopy
                });


            if (dialog.ShowDialog().Value)
            {
                this.Name = dialog.Result.Name;
                this.InputDirectory = dialog.Result.InputDirectory;
                this.SandboxDirectory = dialog.Result.SandboxDirectory;
                this.AssignedTemplates = dialog.Result.AssignedTemplates;

                ContextService.ProjectRepository.UpsertProject(ToEntity(), _assignedTemplates.Select(x => x.ToEntity()).ToList());
            }
        }

        public RelayCommand EditDependenciesCommand { get; private set; }
        public void EditDependencies()
        {
            var dialog = new CreateEditProjectDependenciesDialog(Id);


            if (dialog.ShowDialog().Value)
            {
                ContextService.DependencyRepository.DeleteDependenciesFromProject(Id);
                ContextService.DependencyRepository.AssignDependenciesToProject(Id, dialog.Result.Select(x => x.ToEntity()).ToList());
                Dependencies = string.Join(";", ContextService.DependencyRepository.GetAllDependenciesForProject(Id).Select(x => x.Path));
            }
        }

        public ProjectEntity ToEntity()
        {
            return new ProjectEntity
            {
                Id = Id,
                Name = Name,
                InputDirectory = InputDirectory,
                SandboxDirectory = SandboxDirectory,
                CreatedDate = CreatedDate
            };
        }

        public static ProjectViewModel FromEntity(ProjectEntity e)
        {
            return new ProjectViewModel
            {
                Id = e.Id,
                Name = e.Name,
                InputDirectory = e.InputDirectory,
                SandboxDirectory = e.SandboxDirectory,
                CreatedDate = e.CreatedDate,
                AssignedTemplates = ContextService.ParameterTemplateRepository.GetAssignedParameterTemplates(e.Id).Select(x => x.ToListItem()).ToList(),
                Dependencies = string.Join(";", ContextService.DependencyRepository.GetAllDependenciesForProject(e.Id).Select(x => x.Path))
            };
        }

    }
}
