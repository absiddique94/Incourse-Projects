using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawChamber_Final.Models
{
    class CaseRepsitory : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        List<cases> cases;
        int index;
        bool isEditing = false;
        bool isAdding = false;
        public CaseRepsitory()
        {
            cases = new List<cases>()
            {
                new cases {ID=1, Title= "A vs S", Type= "Civil", Fee= "3000" },
                new cases {ID=2, Title= "B vs F", Type= "Civil", Fee= "4000" },
                new cases {ID=3, Title= "C vs Z", Type= "Criminal", Fee= "5000" },
                new cases {ID=4, Title= "D vs Y", Type= "Appeal", Fee= "6000" },
                new cases {ID=5, Title= "E vs X", Type= "Criminal", Fee= "7000" },
                new cases {ID=6, Title= "Aa vs Ss", Type= "Civil", Fee= "8000" }
            };
            index = 0;
        }
        public async Task<List<cases>> GetBooksAsync()
        {
            return await Task.FromResult<List<cases>>(this.cases);
        }
        public cases Current
        {
            get => cases[index];
        }
        public bool IsAddingOrEditing
        {
            get => isEditing || isAdding;
        }
        public bool IsBrowsing
        {
            get => !isAdding && !isEditing;
        }
        public void AddNew()
        {
            this.cases.Add(new cases());
            this.index = this.cases.Count - 1;
            this.isAdding = true;
            this.OnPropertyChanged(nameof(IsAddingOrEditing));
            this.OnPropertyChanged(nameof(Current));

        }
        public void BeginEdit()
        {
            this.isEditing = true;
            this.OnPropertyChanged(nameof(IsAddingOrEditing));
            this.OnPropertyChanged(nameof(IsBrowsing));
        }
        public void Save()
        {
            this.isAdding = false;
            this.isEditing = false;
            this.OnPropertyChanged(nameof(IsAddingOrEditing));
            this.OnPropertyChanged(nameof(IsBrowsing));
        }
        public void Cancel()
        {
            if (this.isAdding)
            {
                this.cases.RemoveAt(this.cases.Count - 1);
                this.index = 0;
                this.OnPropertyChanged(nameof(Current));
            }
            this.isEditing = false;
            this.isAdding = false;
            this.OnPropertyChanged(nameof(IsAddingOrEditing));
            this.OnPropertyChanged(nameof(IsBrowsing));

        }
        public void Next()
        {
            if (index < this.cases.Count - 1)
            {
                index++;
                this.OnPropertyChanged(nameof(Current));
            }
        }
        public void Previous()
        {
            if (index > 0)
            {
                index--;
                this.OnPropertyChanged(nameof(Current));
            }
        }
        public void First()
        {

            index = 0;
            this.OnPropertyChanged(nameof(Current));

        }
        public void Last()
        {

            index = this.cases.Count - 1;
            this.OnPropertyChanged(nameof(Current));

        }
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
