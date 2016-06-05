using System;
using System.Diagnostics;
using Windows.UI.Xaml.Data;

namespace RestaurantManager.Extensions
{
    public class DoNothingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            //Debug.WriteLine("DoNothingConverter:Convert-> " + value?.ToString());
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            //Debug.WriteLine("DoNothingConverter:ConvertBack<- " + value?.ToString());
            return value?.ToString();
        }
    }
}