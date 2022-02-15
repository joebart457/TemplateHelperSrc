using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Template.Frontend.Models.Constants.Enums;
using Template.Frontend.Models.ViewModels;

namespace Template.Frontend.DataContexts
{
    class CreateParameterDialogDataContext : INotifyPropertyChanged
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

        private ParameterViewModel _parameter;
        public ParameterViewModel Parameter
        {
            get { return _parameter; }
            set 
            { 
                _parameter = value;
                RaisePropertyChanged(nameof(Parameter)); 
            }
        }

        public List<ParameterTypeEnum> ParameterTypesList { get; set; } = Enum.GetValues(typeof(ParameterTypeEnum)).Cast<ParameterTypeEnum>().ToList();

    }
}
