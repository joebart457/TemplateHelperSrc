using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Template.Frontend.Models.ListItems;
using Template.Frontend.Models.ViewModels;
using Template.Frontend.Services;
using Template.Frontend.Windows.Dialogs;

namespace Template.Frontend.DataContexts
{
    class CreateEditProjectDialogDataContext : INotifyPropertyChanged
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

        public CreateEditProjectDialogDataContext()
        {
            BrowseInputDirectoryCommand = new RelayCommand<Window>(BrowseInputDirectory);
            BrowseSandboxDirectoryCommand = new RelayCommand<Window>(BrowseSandboxDirectory);
            ShowMoreActionsCommand = new RelayCommand<Button>(ShowMoreActions);
            EditTemplateAssignmentsCommand = new RelayCommand(EditTemplateAssignments);
            _moreActionsMenu.Items.Add(new MenuItem { Header = "Edit", Command = EditTemplateAssignmentsCommand });
        }

        private ProjectViewModel _project = new ProjectViewModel();
        public ProjectViewModel Project
        {
            get {
                return _project;
            }
            set { 
                Id = value.Id;
                Name = value.Name;
                InputDirectory = value.InputDirectory;
                SandboxDirectory = value.SandboxDirectory;
                CreatedDate = value.CreatedDate;
                AssignedTemplates = value.AssignedTemplates;
                CheckSavable();
            }
        }

        // Unfortunately there is a bug when using INotifyPropertyChanged with nested objects
        // so for now we will just flatten ProjectViewModel into this datacontext

        public int Id
        {
            get { return _project.Id; }
            set { _project.Id = value; RaisePropertyChanged(nameof(Id)); }
        }
        public string Name
        {
            get { return _project.Name; }
            set { _project.Name = value; RaisePropertyChanged(nameof(Name)); CheckSavable(); }
        }
        public string InputDirectory
        {
            get { return _project.InputDirectory; }
            set { _project.InputDirectory = value; RaisePropertyChanged(nameof(InputDirectory)); CheckSavable(); }
        }
        public string SandboxDirectory
        {
            get { return _project.SandboxDirectory; }
            set { _project.SandboxDirectory = value; RaisePropertyChanged(nameof(SandboxDirectory)); CheckSavable(); }
        }
   
        public DateTime CreatedDate
        {
            get { return _project.CreatedDate; }
            set { _project.CreatedDate = value; RaisePropertyChanged(nameof(CreatedDate)); }
        }
        public List<ParameterTemplateListItem> AssignedTemplates
        {
            get { return _project.AssignedTemplates; }
            set { _project.AssignedTemplates = value; RaisePropertyChanged(nameof(AssignedTemplates)); }
        }

        // End ProjectViewModel properties

        private bool _isSavable = false;
        public bool IsSavable
        {
            get { return _isSavable; }
            set { _isSavable = value; RaisePropertyChanged(nameof(IsSavable)); }
        }


        private void CheckSavable()
        {
            if (_project == null) { IsSavable = false; }
            else
            {
                IsSavable = Name.Trim().Length > 0 && SandboxDirectory.Trim().Length > 0 && InputDirectory.Trim().Length > 0;
            }
        }

        public RelayCommand EditTemplateAssignmentsCommand { get; private set; }
        public void EditTemplateAssignments()
        {
            TemplateAssignmentDialog dialog = new TemplateAssignmentDialog(_project.Id);
            if (dialog.ShowDialog().Value)
            {
                this.AssignedTemplates = dialog.Result;
            }
        }

        private ContextMenu _moreActionsMenu = new ContextMenu();

        public RelayCommand<Button> ShowMoreActionsCommand { get; private set; }
        public void ShowMoreActions(Button sender)
        {
            _moreActionsMenu.PlacementTarget = sender;
            _moreActionsMenu.IsOpen = true;
        }

        public RelayCommand<Window> BrowseInputDirectoryCommand { get; private set; }
        public void BrowseInputDirectory(Window callingWin)
        {
            string result = DialogService.FolderBrowser();
            if (result != string.Empty)
            {
                InputDirectory = result;
            }
            callingWin.Focus();
        }

        public RelayCommand<Window> BrowseSandboxDirectoryCommand { get; private set; }
        public void BrowseSandboxDirectory(Window callingWin)
        {
            string result = DialogService.FolderBrowser();
            if (result != string.Empty)
            {
                SandboxDirectory = result;
            }
            callingWin.Focus();
        }
    }
}
