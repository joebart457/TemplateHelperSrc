using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Template.Frontend.Models.ListItems;
using Template.Frontend.Services;

namespace Template.Frontend.DataContexts
{
    class TemplateAssignmentDialogDataContext : INotifyPropertyChanged
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

        public TemplateAssignmentDialogDataContext()
        {
            AssignTemplateCommand = new RelayCommand<ParameterTemplateListItem>(AssignTemplate);
            UnassignTemplateCommand = new RelayCommand<ParameterTemplateListItem>(UnassignTemplate);
        }

        private int _projectId = -1;
        public int ProjectId
        {
            get { return _projectId; }
            set { 
                _projectId = value;
                AssignedTemplates = ContextService.ParameterTemplateRepository.GetAssignedParameterTemplates(_projectId).Select(x => x.ToListItem()).ToList();
                AvailableTemplates = ContextService.ParameterTemplateRepository.GetUnassignedParameterTemplates(_projectId).Select(x => x.ToListItem()).ToList();
                RaisePropertyChanged(nameof(ProjectId)); 
            }
        }

        private List<ParameterTemplateListItem> _availableTemplates = new List<ParameterTemplateListItem>();
        public List<ParameterTemplateListItem> AvailableTemplates
        {
            get { return _availableTemplates; }
            set { _availableTemplates = value; RaisePropertyChanged(nameof(AvailableTemplates)); }
        }

        private List<ParameterTemplateListItem> _assignedTemplates = new List<ParameterTemplateListItem>();
        public List<ParameterTemplateListItem> AssignedTemplates
        {
            get { return _assignedTemplates; }
            set { _assignedTemplates = value; RaisePropertyChanged(nameof(AssignedTemplates)); }
        }

        public RelayCommand<ParameterTemplateListItem> AssignTemplateCommand { get; private set; }
        private void AssignTemplate(ParameterTemplateListItem item)
        {
            if (item != null)
            {
                _availableTemplates.Remove(item);
                var availableTemplates = _availableTemplates;
                AvailableTemplates = null;
                AvailableTemplates = availableTemplates;

                _assignedTemplates.Add(item);
                var assignedTemplates = _assignedTemplates;
                AssignedTemplates = null;
                AssignedTemplates = assignedTemplates;
            }
        }

        public RelayCommand<ParameterTemplateListItem> UnassignTemplateCommand { get; private set; }
        private void UnassignTemplate(ParameterTemplateListItem item)
        {
            if (item != null)
            {
                _assignedTemplates.Remove(item);
                var assignedTemplates = _assignedTemplates;
                AssignedTemplates = null;
                AssignedTemplates = assignedTemplates;

                _availableTemplates.Add(item);
                var availableTemplates = _availableTemplates;
                AvailableTemplates = null;
                AvailableTemplates = availableTemplates;
            }
        }

    }
}
