using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    class OrderDataManager : DataManager
    {
        private List<MenuItem> _menuItems;
        private List<MenuItem> _currentlySelectedMenuItems;

        public List<MenuItem> MenuItems
        {
            get { return this._menuItems; }
            set
            {
                this._menuItems = value;
                NotifyPropertyChanged("MenuItems");
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return this._currentlySelectedMenuItems; }
            set
            {
                this._currentlySelectedMenuItems = value;
                NotifyPropertyChanged("CurrentItems");
            }
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }
    }
}
