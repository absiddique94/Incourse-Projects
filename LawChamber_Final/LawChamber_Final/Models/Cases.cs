using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawChamber_Final.Models
{
    class cases : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        int _id;
        public int ID { get => _id; set { _id = value; this.OnPropertyChanged(nameof(ID)); } }
        string _title;
        public string Title { get => _title; set { _title = value; this.OnPropertyChanged(nameof(Title)); } }
        string _type;
        public string Type { get => _type; set { _type = value; this.OnPropertyChanged(nameof(Title)); } }
        string _fee;
        public string Fee { get => _fee; set { _fee = value; this.OnPropertyChanged(nameof(Fee)); } }
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

