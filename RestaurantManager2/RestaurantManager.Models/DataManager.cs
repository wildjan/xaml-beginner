using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RestaurantManager.ViewModels;

namespace RestaurantManager.ViewModels
{
    /// <summary>
    /// Abstract class notifies changes
    /// </summary>
    public abstract class DataManager : INotifyPropertyChanged
    {
        /// <summary>
        /// Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Propety Repository
        /// </summary>
        protected RestaurantContext Repository { get; private set; }

        /// <summary>
        /// Method that notifies change of property
        /// </summary>
        /// <param name="propertyName">Name of changed property</param>
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Class constructor
        /// </summary>
        public DataManager()
        {
            LoadData();
        }

        /// <summary>
        /// Method loads data
        /// </summary>
        async private void LoadData()
        {
            this.Repository = new RestaurantContext();
            await this.Repository.InitializeContextAsync();
            OnDataLoaded();
        }

        /// <summary>
        /// Method if data are loaded will be overrided
        /// </summary>
        protected abstract void OnDataLoaded();
    }
}
