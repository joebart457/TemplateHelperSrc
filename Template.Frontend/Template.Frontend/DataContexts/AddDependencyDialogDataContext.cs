using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Template.Frontend.Models.ViewModels;
using Template.Frontend.Models.ViewModels.Environment;
using Template.Frontend.Services;

namespace Template.Frontend.DataContexts
{
    class AddDependencyDialogDataContext : INotifyPropertyChanged
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


        public AddDependencyDialogDataContext()
        {
            BrowseFilesCommand = new RelayCommand<Window>(BrowseFiles);
        }

        private int _projectId;
        public void Init(int projectId)
        {
            _projectId = projectId;
            _dependency.ProjectId = projectId;
            ProjectName = ContextService.ProjectRepository.GetProject(projectId).Name;
        }


        private DependencyViewModel _dependency = new DependencyViewModel();
        public DependencyViewModel Dependency
        {
            get { return _dependency; }
            set { _dependency = value; RaisePropertyChanged(nameof(Dependency)); }
        }

        public string Path
        {
            get { return _dependency.Path; }
            set 
            { 
                _dependency.Path = value;
                if (File.Exists(_dependency.Path))
                {

                    Mochj._Storage.Environment env = new Mochj._Storage.Environment();
                    try
                    {
                        if (System.IO.Path.GetExtension(_dependency.Path).ToLower() == ".dll")
                        {
                            Mochj._Interpreter.Helpers.LoadFileHelper.LoadFromAssembly(env, _dependency.Path);
                        }
                        else
                        {
                            Mochj._Interpreter.Helpers.LoadFileHelper.LoadFromRawCode(env, _dependency.Path);
                        }
                        MochjObjectViewModels = EnvironmentService.Flatten(env);
                        IsSavable = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString(), "Failed loading from dll");
                        IsSavable = false;
                    }
                }
                else
                {
                    IsSavable = false;
                }
                RaisePropertyChanged(nameof(Path)); 
            }
        }

        private string _projectName;
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; RaisePropertyChanged(nameof(ProjectName)); }
        }

        private List<MochjObjectViewModel> _mochjObjectViewModels;
        public List<MochjObjectViewModel> MochjObjectViewModels
        {
            get { return _mochjObjectViewModels; }
            set { _mochjObjectViewModels = value; RaisePropertyChanged(nameof(MochjObjectViewModels)); }
        }

        private bool _isSavable = false;
        public bool IsSavable
        {
            get { return _isSavable; }
            set { _isSavable = value; RaisePropertyChanged(nameof(IsSavable)); }
        }

        public RelayCommand<Window> BrowseFilesCommand { get; private set; }
        public void BrowseFiles(Window callingWin)
        {
            string path = DialogService.LibraryFileBrowser();
            if (path != string.Empty)
            {
                Path = path;
            }
            callingWin.Focus();
        }

    }
}
