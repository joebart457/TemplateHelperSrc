using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Template.Frontend.Models.Constants.Enums;
using Template.Frontend.Models.Entities;
using Template.Frontend.Services;
using Template.Frontend.Windows.Dialogs;

namespace Template.Frontend.Models.ViewModels
{
    public class ParameterViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public ParameterViewModel()
        {
            DeleteCommand = new RelayCommand(Delete);
            SaveCommand = new RelayCommand(Save);
            ShowMoreActionsCommand = new RelayCommand<Button>(ShowMoreActions);
            OpenEditDialogCommand = new RelayCommand(OpenEditDialog);
            _moreActionsMenu.Items.Add(new MenuItem { Command = OpenEditDialogCommand, Header = "Edit" });
            _moreActionsMenu.Items.Add(new MenuItem { Command = DeleteCommand, Header = "Delete" });
        }


        private int _id;
        private int _templateId;
        private string _symbol;
        private string _description;
        private ParameterTypeEnum _type;
        private bool _changed;

        private string _typeImageSource;
        private string _typeImageTooltip;

        private ContextMenu _moreActionsMenu = new ContextMenu();

        public ParameterTemplateViewModel TemplateViewModel = null;

        public RelayCommand DeleteCommand { get; private set; } 

        public void Delete()
        {
            ContextService.ParameterRepository.DeleteParameter(ToEntity());
            if (TemplateViewModel != null)
            {
                TemplateViewModel.RefreshParameterList();
            }
        }

        public RelayCommand SaveCommand { get; private set; }

        public void Save()
        {
            ContextService.ParameterRepository.UpdateParameter(ToEntity());
            if (TemplateViewModel != null)
            {
                TemplateViewModel.RefreshParameterList();
            }
        }

        public RelayCommand<Button> ShowMoreActionsCommand { get; private set; }

        public void ShowMoreActions(Button sender)
        {
            _moreActionsMenu.PlacementTarget = sender;
            _moreActionsMenu.IsOpen = true;
        }

        public RelayCommand OpenEditDialogCommand { get; private set; }

        public void OpenEditDialog()
        {
            AddParameterDialog dialog = new AddParameterDialog(new ParameterViewModel
            {
                Id = _id,
                TemplateId = _templateId,
                Symbol = _symbol,
                Type = _type,
                Description = _description,
            });
            if (dialog.ShowDialog().Value)
            {
                Id = dialog.Result.Id;
                TemplateId = dialog.Result.TemplateId;
                Symbol = dialog.Result.Symbol;
                Type = dialog.Result.Type;
                Description = dialog.Result.Description;
                ContextService.ParameterRepository.UpdateParameter(ToEntity());
            }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; Changed = true; OnPropertyChanged("Id"); }
        }
        public int TemplateId
        {
            get { return _templateId; }
            set { _templateId = value; Changed = true; OnPropertyChanged("TemplateId"); }
        }
        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; Changed = true; OnPropertyChanged("Symbol"); }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; Changed = true; OnPropertyChanged("Description"); }
        }

        public string TypeImageSource
        {
            get { return _typeImageSource; }
            set { _typeImageSource = value; Changed = true; OnPropertyChanged("TypeImageSource"); }
        }

        public string TypeImageTooltip
        {
            get { return _typeImageTooltip; }
            set { _typeImageTooltip = value; Changed = true; OnPropertyChanged("TypeImageTooltip"); }
        }

        public ParameterTypeEnum Type
        {
            get { return _type; }
            set 
            { 
                _type = value; 
                switch (_type)
                {
                    case ParameterTypeEnum.Text:
                        {
                            TypeImageSource = "pack://application:,,,/Assets/Images/text-icon.png";
                            TypeImageTooltip = "A literal string parameter";
                        }
                        break;
                    case ParameterTypeEnum.CommaDelimitedList:
                        {
                            TypeImageSource = "pack://application:,,,/Assets/Images/three-commas.png";
                            TypeImageTooltip = "A list of comma seperated values";
                        }
                        break;
                    default:
                        break;
                }
                Changed = true; 
                OnPropertyChanged("Type"); 
            }
        }

        public bool Changed
        {
            get { return _changed; }
            set { _changed = value; OnPropertyChanged("Changed"); }
        }

        public override string ToString()
        {
            return _symbol;
        }

        public ParameterEntity ToEntity()
        {
            return new ParameterEntity
            {
                Id = _id,
                TemplateId = _templateId,
                Symbol = _symbol,
                Type = _type,
                Description = _description
            };
        }

        public static ParameterViewModel FromEntity(ParameterEntity e)
        {
            return new ParameterViewModel()
            {

                Id = e.Id,
                TemplateId = e.TemplateId,
                Symbol = e.Symbol,
                Type = e.Type,
                Description = e.Description
            };
        }
    }
}
