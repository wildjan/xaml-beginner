using SQLite;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;

namespace SQLiteBinding.Models
{
    public class PeopleDB : SQLiteAsyncConnection, INotifyCollectionChanged
    {
        private List<Person> _peopleDB = new List<Person>();
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public PeopleDB (string path) : base(path)
        {
            CreateTableAsync<Person>().ContinueWith((results) =>
            {
                Debug.WriteLine("Table people created!");
            });
        }
        public void NotifyCollectionChanged(NotifyCollectionChangedAction action, Person changedItem)
        {
            this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, changedItem));
        }
        public void NotifyCollectionChanged(NotifyCollectionChangedAction action, Person oldPerson, Person newPerson)
        {
            this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, newPerson, oldPerson));
        }
        public Person this[int index]
        {
            get
            {
                return this._peopleDB[index];
            }
            set
            {
                var _originalPerson = _peopleDB[index];
                this._peopleDB[index] = value;
                UpdateAsync(_peopleDB[index]);
                NotifyCollectionChanged(NotifyCollectionChangedAction.Replace, _originalPerson, value);
            }
        }
        public void Create(Person person)
        {
            InsertAsync(person);
            this._peopleDB.Add(person);
            this.NotifyCollectionChanged(NotifyCollectionChangedAction.Add, person);
        }
         public void Remove(Person person)
        {
            DeleteAsync(person);
            this._peopleDB.Remove(person);
            this.NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, person);
        }
    }
}
