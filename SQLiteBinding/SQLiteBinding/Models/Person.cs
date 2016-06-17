using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteBinding.Models
{
    public class Person
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
