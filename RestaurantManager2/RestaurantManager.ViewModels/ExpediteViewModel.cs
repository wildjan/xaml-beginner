using System.Collections.Generic;
using Windows.UI.Popups;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            NotifyPropertyChanged("OrderItems");
        }

        public List<Order> OrderItems => Repository?.Orders;
    }
}
