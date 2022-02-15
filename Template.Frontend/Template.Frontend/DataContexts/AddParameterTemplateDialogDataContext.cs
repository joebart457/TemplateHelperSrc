using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Frontend.DataContexts
{
    class AddParameterTemplateDialogDataContext : INotifyPropertyChanged
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

        private string _templateName;
        public string TemplateName
        {
            get { return _templateName; }
            set 
            { 
                _templateName = value; 
                RaisePropertyChanged(nameof(TemplateName));
                IsSavable = _templateName.Length > 0;
            }
        }

        private bool _isSavable = false;
        public bool IsSavable
        {
            get { return _isSavable; }
            set { _isSavable = value; RaisePropertyChanged(nameof(IsSavable)); }
        }
    }
}