using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteBinding.Models;
using System.Collections.ObjectModel;
using Windows.UI.Popups;

namespace SQLiteBinding.ViewModels
{
    class MainPageViewModel : ViewModel
    {
        public DelegateCommand<Person> DeleteSelectedCommand { get; private set; }
        public DelegateCommand<string> ClearPeopleCommand { get; private set; }
        public DelegateCommand<string> ResetPeopleCommand { get; private set; }
        public DelegateCommand<Person> UpdateInCollectionCommand { get; private set; }
        public DelegateCommand<Person> AddToCollectionCommand { get; private set; }

        public MainPageViewModel()
        {
            DeleteSelectedCommand = new DelegateCommand<Person>(DeleteSelectedExecute);
            ClearPeopleCommand = new DelegateCommand<string>(ClearPeopleExecute, ClearPeopleCanExecute);
            ResetPeopleCommand = new DelegateCommand<string>(ResetPeopleExecute, ResetPeopleCanExecute);
            UpdateInCollectionCommand = new DelegateCommand<Person>(UpdateInCollectionExecute, UpdateInCollectionCanExecute);
            AddToCollectionCommand = new DelegateCommand<Person>(AddToCollectionExecute, AddToCollectionCanExecute);
        }

        private bool AddToCollectionCanExecute(Person editedPerson)
        {
            return true; // editedPerson == null;
        }

        private void AddToCollectionExecute(Person editedPerson)
        {
            int newID = People.Count;
            string newName = "Edit the new name";
            Person newPerson = new Person() { ID = newID, Name = newName };
            People.Add(newPerson);
            editedPerson = People[newID];
            NotifyPropertyChanged("People");
        }

        private bool UpdateInCollectionCanExecute(Person editCollectionItem)
        {
            return editCollectionItem != null;
        }

        private void UpdateInCollectionExecute(Person editCollectionItem)
        {
            People[editCollectionItem.ID].Name = editCollectionItem.Name;
            NotifyPropertyChanged("People");
        }

        private void DeleteSelectedExecute(Person selectedPerson)
        {
            if (selectedPerson != null)
            {
                People.Remove(selectedPerson);
            }
        }
        private bool ClearPeopleCanExecute(string arg)
        {
            return this._people.Count > 0;
        }

        private void ClearPeopleExecute(string message)
        {
            this._people.Clear();
            new MessageDialog(message).ShowAsync();
            ClearPeopleCommand?.RaiseCanExecuteChanged();
            ResetPeopleCommand?.RaiseCanExecuteChanged();
        }
        private bool ResetPeopleCanExecute(string arg)
        {
            return this._people.Count == 0;
        }

        private void ResetPeopleExecute(string message)
        {
            People = new ObservableCollection<Person>()
            {
                new Person() { ID = 0, Name = "Chris" },
                new Person() { ID = 1, Name = "Sage" },
                new Person() { ID = 2, Name = "Daren"  }
            };
            NotifyPropertyChanged("People");
            new MessageDialog(message).ShowAsync();
            ResetPeopleCommand.RaiseCanExecuteChanged();
            ClearPeopleCommand.RaiseCanExecuteChanged();
        }
        protected override void OnDataLoaded()
        {
            People = base.Repository.people;
            ClearPeopleCommand?.RaiseCanExecuteChanged();
            PeopleDB = base.Repository.peopleDB;
        }

        private ObservableCollection<Person> _people;
        private ObservableCollection<Person> _peopleDB;

        public ObservableCollection<Person> People
        {
            get { return this._people; }
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

        private Person _editCollectionItem;
        public Person EditCollectionItem
        {
            get { return this._editCollectionItem; }
            set
            {
                if (this._editCollectionItem != value) this._editCollectionItem = value;
                base.NotifyPropertyChanged("EditCollectionItem");
            }
        }
    }
}

