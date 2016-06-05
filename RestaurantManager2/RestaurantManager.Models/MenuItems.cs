using System.Collections.Generic;
using System.Collections.Specialized;

namespace RestaurantManager.Models
{
    public class MenuItems : INotifyCollectionChanged
    {
        private List<MenuItem> _items = new List<MenuItem>();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public void FireCollectionChanged(NotifyCollectionChangedAction action, MenuItem changedItem)
        {
            this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, changedItem));
        }
        public void FireCollectionChanged(NotifyCollectionChangedAction action, MenuItem oldItem, MenuItem newItem)
        {
            this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem));
        }

        public MenuItem this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                var _originalItem = _items[index];
                _items[index] = value;
                FireCollectionChanged(NotifyCollectionChangedAction.Replace, _originalItem, value);
            }
        }

        public void Add(MenuItem item)
        {
            _items.Add(item);
            this.FireCollectionChanged(NotifyCollectionChangedAction.Add, item);
        }

        public void Remove(MenuItem item)
        {
            _items.Remove(item);
            this.FireCollectionChanged(NotifyCollectionChangedAction.Remove, item);
        }

    }
}