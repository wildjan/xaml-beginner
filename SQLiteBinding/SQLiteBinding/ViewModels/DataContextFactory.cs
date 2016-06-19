using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteBinding.Models;

namespace SQLiteBinding.ViewModels
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
