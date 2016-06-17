using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteBinding.Models
{
    public class SampleData
    {
        public SampleData()
        {
            this.People = new ObservableCollection<Person>()
            { 
                new Person() { ID = 0, Name = "Chris" },
                new Person() { ID = 1, Name = "Sage" },
                new Person() { ID = 2, Name = "Daren"  }
            };

            this.CurrentPerson = new Person();

            this.PeopleDB = new ObservableCollection<Person>();

            this.CurrentDBPerson = new Person();

            DB.CreateTableAsync<Person>();

            DB.ExecuteScalarAsync<int>("select count(*) from Person").ContinueWith((t) =>
            {
                Debug.WriteLine(string.Format("Found '{0}' person items.", t.Result));
                countPeople = t.Result;
            });

            if (countPeople >= 1)
            {
                //DBtoList();
                //DisplayDB();
            }
            else
            {
                //initPeopleCollection();
                //loadCollection();
            }

        }

        static string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
        static string fname = "peopleDB.sqlite";
        static string dbPath = Path.Combine(path, fname);
        static int countPeople;

        SQLiteAsyncConnection DB = new SQLiteAsyncConnection(dbPath);



        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();

        public Person CurrentPerson { get; set; }

        public ObservableCollection<Person> PeopleDB { get; set; } = new ObservableCollection<Person>();

        public Person CurrentDBPerson { get; set; }



    }
}
