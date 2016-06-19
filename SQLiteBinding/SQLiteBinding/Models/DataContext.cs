using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteBinding.Models
{
    public sealed class DataContext
    {
        public ObservableCollection<Person> people { get; set; }
        public ObservableCollection<Person> peopleDB { get; set; }
        PeopleDB _db;

        public async Task InitializeContextAsync()
        {
            //DO NOT REMOVE: Simulates network congestion
            await Task.Delay(TimeSpan.FromSeconds(2.5d));

            this.people = new ObservableCollection<Person>()
            {
                new Person() { ID = 0, Name = "Chris" },
                new Person() { ID = 1, Name = "Sage" },
                new Person() { ID = 2, Name = "Daren"  }
            };

            var path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var fname = "peopleDB.sqlite";
            var dbPath = Path.Combine(path, fname);
            _db = new PeopleDB(dbPath);

            this.peopleDB = new ObservableCollection<Person>();

            List<Person> queryPeople = await _db.Table<Person>().ToListAsync();
            this.peopleDB.Clear();

            foreach (Person p in queryPeople)
            {
                this.peopleDB.Add(new Person() { ID = p.ID, Name = p.Name });
            }
        }
    }
}
