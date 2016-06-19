using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteBinding.Models
{
    public class PeopleDB : SQLiteAsyncConnection, INotifyCollectionChanged
    {
        private List<Person> _peopleDB;
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
                return _peopleDB[index];
            }
            set
            {
                var _originalPerson = _peopleDB[index];
                _peopleDB[index] = value;
                UpdateAsync(_peopleDB[index]);
                NotifyCollectionChanged(NotifyCollectionChangedAction.Replace, _originalPerson, value);
            }
        }
        public void Create(Person person)
        {
            InsertAsync(person);
            _peopleDB.Add(person);
            this.NotifyCollectionChanged(NotifyCollectionChangedAction.Add, person);
        }
         public void Remove(Person person)
        {
            DeleteAsync(person);
            _peopleDB.Remove(person);
            this.NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, person);
        }
    }
}
