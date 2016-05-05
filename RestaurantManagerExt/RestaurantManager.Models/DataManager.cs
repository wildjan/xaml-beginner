using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RestaurantManager.Models
{
    public class DataManager
    {
        public DataManager()
        {
            this.OrderItems = new ObservableCollection<string>(
                new List<string>
                {
                    "Steak, Chicken, Peas",
                    "Rice, Chicken",
                    "Hummus, Pita"
                }
            );

            this.MenuItems = new List<string>
            {
                "Steak",
                "Chicken",
                "Peas",
                "Rice",
                "Hummus",
                "Pita"
            };

            this.CurrentlySelectedMenuItems = new ObservableCollection<string>(new List<string>
            {}
            );

        }

        public ObservableCollection<string> OrderItems { get; set; }
        public List<string> MenuItems { get; set; }
        public ObservableCollection<string> CurrentlySelectedMenuItems { get; set; }

        public void submitOrder()
        {
            foreach (string item in CurrentlySelectedMenuItems)
            {
                OrderItems.Add(item);
            }
            CurrentlySelectedMenuItems.Clear();
        }

        public void clearAllOrders()
        {
            OrderItems.Clear();
        }
    }
}