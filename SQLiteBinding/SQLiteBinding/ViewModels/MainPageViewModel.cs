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

        private Person _selectedPerson;
        private string _editNameText = String.Empty;
        private string _editIDText = String.Empty;

        public Person SelectedPerson
        {
            get { return this._selectedPerson; }
            set
            {
                if (this._selectedPerson != null)
                {
                    this._selectedPerson = value;
                    EditIDText = _selectedPerson.ID.ToString();
                    EditNameText = this._selectedPerson.Name;
                        }
                base.NotifyPropertyChanged("SelectedPerson");
            }
        }

        public string EditNameText
        {
            get { return this._editNameText; }
            set
            {
                if (this._editIDText != value) this._editNameText = value;
                base.NotifyPropertyChanged("EditNameText");
            }
        }

        public string EditIDText
        {
            get { return this._editIDText; }
            private set
            {
                if (this._editIDText != value) this._editIDText = value;
            }
        }
    }
}
