using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteBinding.Models;
using System.Collections.ObjectModel;

namespace SQLiteBinding.ViewModels
{
    class MainPageViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            this.People = base.Repository.people;
            this.PeopleDB = base.Repository.peopleDB;
        }

        private ObservableCollection<Person> _people;
        private ObservableCollection<Person> _peopleDB;

        public ObservableCollection<Person> People
        {
            get { return _people; }
            set
            {
                this._people = value;
                NotifyPropertyChanged("People");
            }
        }

        public ObservableCollection<Person> PeopleDB
        {
            get { return this._peopleDB; }
            set
            {
                this._peopleDB = value;
                NotifyPropertyChanged("PeopleDB");
            }
        }
    }
}
