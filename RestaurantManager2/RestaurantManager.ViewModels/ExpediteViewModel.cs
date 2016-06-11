using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Popups;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        private ObservableCollection<Order> _orderItems = new ObservableCollection<Order>();
        public DelegateCommand<int> DeleteOrderCommand { get; private set; }
        public DelegateCommand<string> ClearAllOrdersCommand { get; private set; }

        public ExpediteViewModel()
        {
            DeleteOrderCommand = new DelegateCommand<int>(DeleteOrderExecute, DeleteOrderCanExecute);
            ClearAllOrdersCommand = new DelegateCommand<string>(ClearAllOrdersExecute, ClearAllOrdersCanExecute);
        }

        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
            NotifyPropertyChanged("OrderItems");
        }

        //public List<Order> OrderItems => Repository?.Orders;
        //Modern way to implement getter only function-like properties
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

        private bool DeleteOrderCanExecute(int Id)
        {
            return true;
        }

        private void DeleteOrderExecute(int Id)
        {
            Order _orderToRemove = new Order();
            _orderToRemove = (Order)OrderItems.Where(item => item.Id == Id).Single();
            OrderItems.Remove(_orderToRemove);
        }

        private bool ClearAllOrdersCanExecute(string obj)
        {
            return this.OrderItems.Count > 0;
        }

        private void ClearAllOrdersExecute(string obj)
        {
            this.OrderItems.Clear();
            base.Repository.Orders.Clear();
            ClearAllOrdersCommand?.RaiseCanExecuteChanged();
        }
    }
}
