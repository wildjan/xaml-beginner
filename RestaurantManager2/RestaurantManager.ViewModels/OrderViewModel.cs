using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private ObservableCollection<MenuItem> _menuItems = new ObservableCollection<MenuItem>();
        private ObservableCollection<MenuItem> _selectedMenuItem = new ObservableCollection<MenuItem>();
        private string _specialRequestText = string.Empty;
        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; private set; }
        public DelegateCommand<int> AddToOrderCommand { get; private set; }
        public DelegateCommand<string> SubmitOrderCommand { get; private set; }

        public OrderViewModel()
        {
            AddToOrderCommand = new DelegateCommand<int>(AddToOrderExecute, AddToOrderCanExecute);
            SubmitOrderCommand = new DelegateCommand<string>(SubmitOrderExecute, SubmitOrderCanExecute);
            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        private void AddToOrderExecute(int index)
        {
            if (index >= 0) this.CurrentlySelectedMenuItems.Add(this.MenuItems[index]);
        }

        private bool AddToOrderCanExecute(int id)
        {
            if (id >= 0) return true;
            return false;
        }

        private void SubmitOrderExecute(string obj)
        {
            var rnd = new Random();
            int tableIndex = rnd.Next((int)base.Repository.Tables.Count());

            base.Repository.Orders.Add(
                new Order()
                {
                    Complete = false,
                    Expedite = true,
                    SpecialRequests = this.SpecialRequestText,
                    Table = base.Repository.Tables[tableIndex],
                    Items = CurrentlySelectedMenuItems.ToList<MenuItem>()
                });
            this.CurrentlySelectedMenuItems.Clear();
            SpecialRequestText = String.Empty;
            // SubmitOrderCommand.RaiseCanExecuteChanged(); 
            // Not sure that this is a right place for this.Maybe it will be better to put in a CurrentlySelectedMenuItems setter
            // TODO:Have to navigate to Expedite page I guess... Should I Use button event?

            // Explanation: This is a bad idea with a true MVVM app (seperation of view concerns from logic) but for simplicity sake:
            new Windows.UI.Popups.MessageDialog("Order has been submitted").ShowAsync();
        }

        private bool SubmitOrderCanExecute(string obj)
        {
            return this.CurrentlySelectedMenuItems.Count > 0;
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5],
                this.MenuItems[7],
            };
        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<MenuItem> SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                NotifyPropertyChanged();
            }
        }

        public string SpecialRequestText
        {
            get { return _specialRequestText; }
            set
            {
                if (_specialRequestText != value) _specialRequestText = value;
                base.NotifyPropertyChanged();
            }
        }
    }
}
