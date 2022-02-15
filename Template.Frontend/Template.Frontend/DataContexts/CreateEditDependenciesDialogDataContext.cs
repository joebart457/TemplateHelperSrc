using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Template.Frontend.Models.ViewModels;
using Template.Frontend.Services;
using Template.Frontend.Windows.Dialogs;

namespace Template.Frontend.DataContexts
{
    public class CreateEditDependenciesDialogDataContext : INotifyPropertyChanged
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

        public CreateEditDependenciesDialogDataContext()
        {
            AddDependencyCommand = new RelayCommand(AddDependency);
            RemoveDependenciesCommand = new RelayCommand(RemoveDependencies);
            ShowMoreActionsCommand = new RelayCommand<Button>(ShowMoreActions);
            _moreActionsMenu.Items.Add(new MenuItem { Header = "Add", Command = AddDependencyCommand });
            _moreActionsMenu.Items.Add(new MenuItem { Header = "Remove Selected", Command = RemoveDependenciesCommand });
        }


        private int _projectId;

        public void Init(int projectId)
        {
            _projectId = projectId;
            ProjectName = ContextService.ProjectRepository.GetProject(projectId).Name;
            Dependencies = ContextService.DependencyRepository.GetAllDependenciesForProject(_projectId).Select(x => DependencyViewModel.FromEntity(x)).ToList(); ShowMoreActionsCommand = new RelayCommand<Button>(ShowMoreActions);
        }

        private List<DependencyViewModel> _dependencies = new List<DependencyViewModel>();
        public List<DependencyViewModel> Dependencies
        {
            get { return _dependencies; }
            set { _dependencies = value; RaisePropertyChanged(nameof(Dependencies)); }
        }


        private string _projectName;
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; RaisePropertyChanged(nameof(ProjectName)); }
        }


        private List<DependencyViewModel> _selectedDependencies = new List<DependencyViewModel>();
        public List<DependencyViewModel> SelectedDependencies
        {
            get { return _selectedDependencies; }
            set { _selectedDependencies = value; RaisePropertyChanged(nameof(SelectedDependencies)); }
        }

        public RelayCommand AddDependencyCommand { get; private set; }
        public void AddDependency()
        {
            var dialog = new AddProjectDependencyDialog(_projectId);
            if (dialog.ShowDialog().Value)
            {
                Dependencies.Add(dialog.Result);
                RefreshDependenciesList();
            }
        }

        public RelayCommand RemoveDependenciesCommand { get; private set; }
        public void RemoveDependencies()
        {
            foreach(var dependency in _selectedDependencies)
            {
                Dependencies.Remove(dependency);
            }
            RefreshDependenciesList();
        }

        private ContextMenu _moreActionsMenu = new ContextMenu();

        public RelayCommand<Button> ShowMoreActionsCommand { get; private set; }
        public void ShowMoreActions(Button sender)
        {
            _moreActionsMenu.PlacementTarget = sender;
            _moreActionsMenu.IsOpen = true;
        }

        public void RefreshDependenciesList()
        {
            var temp = Dependencies;
            Dependencies = null;
            Dependencies = temp;
        }
    }
}
