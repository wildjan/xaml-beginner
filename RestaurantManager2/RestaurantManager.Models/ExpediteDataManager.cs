using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    class ExpediteDataManager : DataManager
    {
        public List<Order> OrderItems
        {
            get { return base.Repository.Orders; }
        }

        protected override void OnDataLoaded()
        {
            throw new NotImplementedException();
        }
    }
}
