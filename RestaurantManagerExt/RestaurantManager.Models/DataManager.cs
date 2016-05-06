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
            { }
            );

        }

        public ObservableCollection<string> OrderItems { get; set; }
        public List<string> MenuItems { get; set; }
        public ObservableCollection<string> CurrentlySelectedMenuItems { get; set; }

        public void submitOrder()
        {
            string order = "";
            foreach (string item in CurrentlySelectedMenuItems)
            {
                order += item + ", ";
            }
            order = order.Substring(0, order.Length - 2);
            OrderItems.Add(order);
            CurrentlySelectedMenuItems.Clear();
        }

        public void clearAllOrders()
        {
            OrderItems.Clear();
        }
    }
}