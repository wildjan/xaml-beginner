using SQLite;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using System;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SQLiteSimple
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            SQLiteConnection DB = new SQLiteConnection("peopleDB.sqlite");

            DB.CreateTable<Person>();

            int countPeople = DB.Table<Person>().Count();

            // if the DB has information, start app with that data
            if (countPeople >= 1)
            {
                DBtoList();
                DisplayDB();
            }
            // if the DB is empty, initialize the collection and load that info
            else
            {
                initPeopleCollection();
                loadCollection();
            }
        }

        private void DBtoList()
        {
            throw new NotImplementedException();
        }

        private void DisplayDB()
        {
            throw new NotImplementedException();
        }

        private void loadCollection()
        {
            throw new NotImplementedException();
        }

        ObservableCollection<Person> people = new ObservableCollection<Person>();

        public class Person
        {
            [PrimaryKey]
            public int ID { get; set; }
            public string Name { get; set; }
        }

        private void initPeopleCollection()
        {
            people.Clear();

            people.Add(new Person() { ID = 0, Name = "Chris" });
            people.Add(new Person() { ID = 1, Name = "Sage" });
            people.Add(new Person() { ID = 2, Name = "Daren" });
        }
    }
}
