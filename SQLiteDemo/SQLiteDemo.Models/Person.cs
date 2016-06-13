using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Models
{
    public class Person
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
