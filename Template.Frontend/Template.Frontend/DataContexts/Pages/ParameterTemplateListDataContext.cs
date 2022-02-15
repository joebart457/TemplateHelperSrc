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
    public class ParameterTemplateListDataContext : INotifyPropertyChanged
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

        public ParameterTemplateListDataContext()
        {
            AddTemplateCommand = new RelayCommand(AddTemplate);
            RefreshTemplateList();
        }

        private List<ParameterTemplateViewModel> _templates = new List<ParameterTemplateViewModel>();
        public List<ParameterTemplateViewModel> Templates
        {
            get { return _templates; }
            set { _templates = value; RaisePropertyChanged(nameof(Templates)); }
        }

        public void RefreshTemplateList()
        {
            Templates = ContextService.ParameterTemplateRepository.GetAllParameterTemplates().Select(x => ParameterTemplateViewModel.FromEntity(x)).ToList();
        }

        public RelayCommand AddTemplateCommand { get; private set; }
        public void AddTemplate()
        {
            var dialog = new AddParameterTemplateDialog();
            if (dialog.ShowDialog().Value)
            {
                ContextService.ParameterTemplateRepository.InsertParameterTemplate(new Models.Entities.ParameterTemplateEntity { Name = dialog.Result });
                RefreshTemplateList();
            }
        }

    }
}