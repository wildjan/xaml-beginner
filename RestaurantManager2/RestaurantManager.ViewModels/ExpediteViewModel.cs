using System.Collections.Generic;
using Windows.UI.Popups;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using System;
using System.Diagnostics;
using System.Linq;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        private ObservableCollection<Order> _orderItems = new ObservableCollection<Order>();

        public ObservableCollection<Order> OrderItems
        {
            get { return _orderItems; }
            set
            {
                _orderItems = value;
                base.NotifyPropertyChanged();
                ClearAllOrdersCommand?.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand<string> ClearAllOrdersCommand { get; private set; }
        public DelegateCommand<int> DeleteOrderCommand { get; private set; }

        public ExpediteViewModel()
        {
            ClearAllOrdersCommand = new DelegateCommand<string>(ClearAllOrdersExecute, ClearAllOrdersCanExecute);
            DeleteOrderCommand = new DelegateCommand<int>(DeleteOderExecute, DeleteOrderCanExecute);
        }

        private void ClearAllOrdersExecute(string obj)
        {
            this._orderItems.Clear();
            base.Repository.Orders.Clear();
            ClearAllOrdersCommand?.RaiseCanExecuteChanged();
        }

        private bool ClearAllOrdersCanExecute(string obj)
        {
            return this._orderItems.Count > 0;
        }

        private void DeleteOderExecute(int id)
        {
            Order _orderToRemove = new Order();
            Debug.WriteLine("Deleting Id: " + id.ToString());
            _orderToRemove = (Order)OrderItems.Where(item => item.Id == id).Single();
            OrderItems.Remove(_orderToRemove);
        }

        private bool DeleteOrderCanExecute(int id)
        {
            return true;
        }

        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
        }
    }
}
