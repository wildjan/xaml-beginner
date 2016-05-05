using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager.UniversalWindows
{
    /// <summary>
    /// An Expedite page that expedite orders.
    /// </summary>
    public sealed partial class ExpeditePage : Page
    {
        public ExpeditePage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Event handler that navigates back to the MainPage
        /// </summary>
        /// <param name="sender">btnHomeExpedite</param>
        /// <param name="e">Click</param>
        private void btnHomeExpedite_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void btnClearAllOrders_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            Models.DataManager dataContext = (Models.DataManager)btn.DataContext;
            dataContext.clearAllOrders();
        }
    }
}
