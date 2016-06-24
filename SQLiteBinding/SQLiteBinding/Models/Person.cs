using SQLite;
using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;

namespace SQLiteBinding.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string _name;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public Person() { }

        [PrimaryKey]
        public int ID { get; set; }
        public string Name
        {
            get { return this._name; }
            set
            {
                this._name = value;
                this.OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
