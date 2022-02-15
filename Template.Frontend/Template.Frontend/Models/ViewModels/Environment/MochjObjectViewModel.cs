using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Frontend.Models.ViewModels.Environment
{
    public class MochjObjectViewModel : INotifyPropertyChanged
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

        public MochjObjectViewModel(string description, Mochj.Models.QualifiedObject data)
        {
            Description = description;
            Data = data;
        }

        public MochjObjectViewModel(string description, Mochj.Models.QualifiedObject data, List<MochjObjectViewModel> children)
        {
            Description = description;
            Data = data;
            Children = children;
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged(nameof(Description)); }
        }

        private Mochj.Models.QualifiedObject _data = new();
        public Mochj.Models.QualifiedObject Data
        {
            get { return _data; }
            set 
            { 
                _data = value; 
                RaisePropertyChanged(nameof(Data)); 
                if (_data.Type.Is(Mochj.Enums.DataTypeEnum.Empty))
                {
                    TypeImageSource = "pack://application:,,,/Assets/Images/underscore.png";
                    TypeImageTooltip = "A literal string parameter";
                } 
                else if (_data.Type.Is(Mochj.Enums.DataTypeEnum.Boolean))
                {
                    TypeImageSource = "pack://application:,,,/Assets/Images/checkbox-checked.png";
                    TypeImageTooltip = "A literal string parameter";
                }
                else if (_data.Type.Is(Mochj.Enums.DataTypeEnum.Fn))
                {
                    TypeImageSource = "pack://application:,,,/Assets/Images/lambda.png";
                    TypeImageTooltip = "A literal string parameter";
                }
                else if (_data.Type.Is(Mochj.Enums.DataTypeEnum.Namespace))
                {
                    TypeImageSource = "pack://application:,,,/Assets/Images/curly-brackets.png";
                    TypeImageTooltip = "A literal string parameter";
                }
                else if (_data.Type.Is(Mochj.Enums.DataTypeEnum.Number))
                {
                    TypeImageSource = "pack://application:,,,/Assets/Images/hash.png";
                    TypeImageTooltip = "A literal string parameter";
                }
                else if (_data.Type.Is(Mochj.Enums.DataTypeEnum.String))
                {
                    TypeImageSource = "pack://application:,,,/Assets/Images/str.png";
                    TypeImageTooltip = "A literal string parameter";
                }
                else if (_data.Type.Is(Mochj.Enums.DataTypeEnum.Any))
                {
                    TypeImageSource = "pack://application:,,,/Assets/Images/tilde.png";
                    TypeImageTooltip = "A literal string parameter";
                } else
                {
                    TypeImageSource = "pack://application:,,,/Assets/Images/question-mark.png";
                    TypeImageTooltip = "Unknown";
                }
            }
        }

        private List<MochjObjectViewModel> _children = new();
        public List<MochjObjectViewModel> Children
        {
            get { return _children; }
            set { _children = value; RaisePropertyChanged(nameof(Children)); }
        }

        private string _typeImageSource;
        public string TypeImageSource
        {
            get { return _typeImageSource; }
            set { _typeImageSource = value; OnPropertyChanged(nameof(TypeImageSource)); }
        }

        private string _typeImageTooltip;

        public string TypeImageTooltip
        {
            get { return _typeImageTooltip; }
            set { _typeImageTooltip = value; OnPropertyChanged(nameof(TypeImageTooltip)); }
        }


    }
}
