using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteBinding.Models
{
    public class People : INotifyCollectionChanged

    {
        private List<Person> _people = new List<Person>();
        public event NotifyCollectionChangedEventHandler CollectionChanged;

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
                return _people[index];
            }
            set
            {
                var _originalPerson = _people[index];
                _people[index] = value;
                NotifyCollectionChanged(NotifyCollectionChangedAction.Replace, _originalPerson, value);
            }
        }

        public void Add(Person person)
        {
            _people.Add(person);
            this.NotifyCollectionChanged(NotifyCollectionChangedAction.Add, person);
        }

        public void Remove(Person person)
        {
            _people.Remove(person);
            this.NotifyCollectionChanged(NotifyCollectionChangedAction.Remove, person);
        }
    }
}
