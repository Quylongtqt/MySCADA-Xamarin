using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace MySCADA
{
    public class Tag : INotifyPropertyChanged
    {
        private string _name;
        private string _Quality;
        private object _Value;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Address { get; set; }
        public object Value { get { return _Value; } set { _Value = value; OnPropertyChanged(nameof(Value)); } }
        public string Quality { get { return _Quality; } set { _Quality = value; OnPropertyChanged(nameof(Quality)); } }
        public DateTime TimeStamp;
        public Task Parent;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Tag(string name, string address)
        {
            Name = name;
            Address = address;
        }


    }
}
