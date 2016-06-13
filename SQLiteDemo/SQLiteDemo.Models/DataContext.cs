using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Models
{
    public sealed class DataContext
    {
        ObservableCollection<Person> People = new ObservableCollection<Person>();

      public async Task InitializeContextAsync()
        {
            //DO NOT REMOVE: Simulates network congestion
            await Task.Delay(TimeSpan.FromSeconds(2.5d));

            this.People = new ObservableCollection<Person>
            {
                new Person { ID = 0, Name = "Chris"},
                new Person { ID = 1, Name = "Sage"},
                new Person { ID = 2, Name = "Daren"}
            };

            SQLiteAsyncConnection DB = new SQLiteAsyncConnection("peopleDB.sqlite");
        }
    }
}
