using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Template.Frontend.Models.Entities;
using Template.Frontend.Services;
using Template.Frontend.Windows.Dialogs;

namespace Template.Frontend.Models.ViewModels
{
    public class ParameterTemplateViewModel: INotifyPropertyChanged
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

        public ParameterTemplateViewModel(int id, string name)
        {
            _id = id;
            _name = name;
            ToggleParameterListVisibilityCmd = new RelayCommand(ToggleShow);
            AddParameterCommand = new RelayCommand(AddParameter);
            RefreshParameterList();
        }

        // Data
        private int _id;
        private string _name;
        private List<ParameterViewModel> _parameters;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public List<ParameterViewModel> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; RaisePropertyChanged("Parameters"); }
        }

        // View
        private string _toggleVisibilityBtnLabel = "<";
        public string ToggleVisbilityBtnLabel
        {
            get { return _toggleVisibilityBtnLabel; }
            set { _toggleVisibilityBtnLabel = value; RaisePropertyChanged("ToggleVisbilityBtnLabel"); }
        }

        private Visibility _parametersListVisibility = Visibility.Collapsed;

        public Visibility ParametersListVisibility
        {
            get { return _parametersListVisibility; }
            set { _parametersListVisibility = value; RaisePropertyChanged("ParametersListVisibility"); }
        }

        public RelayCommand ToggleParameterListVisibilityCmd{ get; private set; } 

        public void ToggleShow()
        {
            if (ParametersListVisibility == Visibility.Visible)
            {
                ParametersListVisibility = Visibility.Collapsed;
                ToggleVisbilityBtnLabel = "<";
            } else
            {
                ParametersListVisibility = Visibility.Visible;
                ToggleVisbilityBtnLabel = "v";
            }

        }

        public RelayCommand AddParameterCommand { get; private set; }

        public void AddParameter()
        {

            AddParameterDialog dialog = new AddParameterDialog(new ParameterViewModel
            {
                TemplateId = _id,
                Symbol = "!example!",
                Description = "example description",
                Type = Constants.Enums.ParameterTypeEnum.Text
            });
            if (dialog.ShowDialog().Value)
            {
                ContextService.ParameterRepository.InsertParameter(dialog.Result.ToEntity());
                RefreshParameterList();
            }
        }

        public void RefreshParameterList()
        {
            Parameters = ContextService.ParameterRepository.GetParametersByTemplateId(_id)
               .Select(x => ParameterViewModel.FromEntity(x))
               .Select(x => { x.TemplateViewModel = this; return x; })
               .ToList();
        }

        public static ParameterTemplateViewModel FromEntity(ParameterTemplateEntity e)
        {
            return new ParameterTemplateViewModel(e.Id, e.Name);
        }
    }
}
