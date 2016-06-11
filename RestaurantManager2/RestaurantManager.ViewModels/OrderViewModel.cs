using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        public DelegateCommand<MenuItem> AddToOrderCommand { get; private set; }
        public DelegateCommand<string> SubmitOrderCommand { get; private set; }

        private string _specialRequestsText = String.Empty;

        public OrderViewModel()
        {
            AddToOrderCommand = new DelegateCommand<MenuItem>(AddToOrderExecute);
            SubmitOrderCommand = new DelegateCommand<string>(SubmitOrderExecute);
        }

        private void AddToOrderExecute(MenuItem ChosenItem)
        {
            CurrentlySelectedMenuItems.Add(ChosenItem);
        }

        private void SubmitOrderExecute(string message)
        {
            Order NewOrder = new Order { Complete = false,
                                         Expedite = false,
                                         SpecialRequests = SpecialRequestsText,
                                         Table = new Table { Description = "Test table" },
                                         Items = CurrentlySelectedMenuItems.ToList() };
            Repository.Orders.Add(NewOrder);
            new MessageDialog(message).ShowAsync();
            CurrentlySelectedMenuItems.Clear();
            SpecialRequestsText = String.Empty;
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem> { };
        }

        private ObservableCollection<MenuItem> _menuItems;
        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return this._menuItems; }
            set
            {
                if (value != this._menuItems)
                {
                    this._menuItems = value;
                    NotifyPropertyChanged("MenuItems");
                }
            }
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return this._currentlySelectedMenuItems; }
            set
            {
                if (value != this._currentlySelectedMenuItems)
                {
                    this._currentlySelectedMenuItems = value;
                    NotifyPropertyChanged("CurrentlySelectedMenuItems");
                }
            }
        }

        public string SpecialRequestsText
        {
            get { return this._specialRequestsText; }
            set
            {
                if (this._specialRequestsText != value) this._specialRequestsText = value;
                base.NotifyPropertyChanged("SpecialRequestsText");
            }
        }

    }
}
