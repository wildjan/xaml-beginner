using SQLite;

namespace SQLiteBinding.Models
{
    public class Person
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
