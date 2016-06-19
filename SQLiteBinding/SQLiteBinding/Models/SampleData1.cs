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
            this.people = new ObservableCollection<Person>()
            { 
                new Person() { ID = 0, Name = "Chris" },
                new Person() { ID = 1, Name = "Sage" },
                new Person() { ID = 2, Name = "Daren"  }
            };

            this.currentPerson = new Person();

            this.peopleDB = new ObservableCollection<Person>();

            this.currentDBPerson = new Person();

            Debug.WriteLine(path);

            DB.CreateTableAsync<Person>().ContinueWith((results) =>
            {
                Debug.WriteLine("Table people created!");
            });

            DB.ExecuteScalarAsync<int>("select count(*) from Person").ContinueWith((t) =>
            {
                Debug.WriteLine(string.Format("Found '{0}' person items.", t.Result));
                countPeople = t.Result;
            });



            if (countPeople >= 1)
            {
                DBtoList();
                DisplayDB();
            }
            else
            {
                loadCollection();
                DisplayDB();
            }
        }

        private async void DisplayDB()
        {
            List<Person> queryPeople = await DB.Table<Person>().ToListAsync();
            peopleDB.Clear();

            foreach (Person p in queryPeople)
            {
                peopleDB.Add(new Person() { ID = p.ID, Name = p.Name });
            }
        }

        private async void loadCollection()
        {
            foreach (Person insertPerson in people)
            {
                await DB.InsertAsync(insertPerson).ContinueWith((t) =>
                 {
                     Debug.WriteLine("New customer ID: {0}", insertPerson.ID);
                 });
            }
        }

        private async void DBtoList()
        {
            List<Person> queryPeople = await DB.Table<Person>().ToListAsync();
            people.Clear();

            foreach (Person p in queryPeople)
            {
                people.Add(new Person() { ID = p.ID, Name = p.Name });
            }
        }

        static string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
        static string fname = "peopleDB.sqlite";
        static string dbPath = Path.Combine(path, fname);

        SQLiteAsyncConnection DB = new SQLiteAsyncConnection(dbPath);

        private static int countPeople;

        public ObservableCollection<Person> people { get; set; } = new ObservableCollection<Person>();

        public Person currentPerson { get; set; }

        public ObservableCollection<Person> peopleDB { get; set; } = new ObservableCollection<Person>();

        public Person currentDBPerson { get; set; }

    }
}
