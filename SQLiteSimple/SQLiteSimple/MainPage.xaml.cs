using SQLite;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;

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


            var path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var fname = "peopleDB.sqlite";
            var dbPath = Path.Combine(path, fname);

            SQLiteAsyncConnection DB = new SQLiteAsyncConnection(dbPath);

            DB.CreateTableAsync<Person>();

            DB.ExecuteScalarAsync<int>("select count(*) from Person").ContinueWith((t) =>
            {
                Debug.WriteLine(string.Format("Found '{0}' person items.", t.Result));
                int countPeople = t.Result;
            });
        }
    }

    public class Person
        {
            [PrimaryKey]
            public int ID { get; set; }
            public string Name { get; set; }
        }

    public class PeopleViewModel
    {
        public PeopleViewModel()
        {
            People.Add(new Person() { ID = 0, Name = "Chris" });
            People.Add(new Person() { ID = 1, Name = "Sage" });
            People.Add(new Person() { ID = 2, Name = "Daren" });
        }

        public ObservableCollection<Person> People { get; set; } = new ObservableCollection<Person>();

        public Person CurrentPerson { get; set; }

        public ObservableCollection<Person> PeopleDB { get; set; } = new ObservableCollection<Person>();

        public Person CurrentDBPerson { get; set; }


    }

}
