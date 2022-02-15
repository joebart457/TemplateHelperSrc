using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Frontend.Models.Constants.Enums;
using Template.Frontend.Models.Entities;

namespace Template.Frontend.Models.ListItems
{
    public class ParameterListItem : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }


        private int _id { get; set; }
        private int _templateId { get; set; }
        private string _symbol { get; set; }
        private string _description { get; set; }
        private ParameterTypeEnum _type { get; set; }
        private bool _changed { get; set; }

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

        public ParameterTypeEnum Type
        {
            get { return _type; }
            set { _type = value; Changed = true; OnPropertyChanged("Type"); }
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
    }
}
