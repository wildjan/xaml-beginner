using System.Threading.Tasks;
using SQLiteDemo.Models;

namespace SQLiteDemo.ViewModels
{
    public static class DataContextFactory
    {
        private static DataContext _dataContext;

        public static async Task<DataContext> GetDataContextAsync()
        {
            if (_dataContext == null)
            {
                _dataContext = new DataContext();
                await _dataContext.InitializeContextAsync();
            }

            return _dataContext;
        }
    }
}