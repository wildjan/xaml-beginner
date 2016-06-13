using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteDemo.Models;

namespace SQLiteDemo.ViewModels
{
    class MainPageViewModel
    {
        public DelegateCommand<Person> AddToOrderCommand { get; private set; }
        public DelegateCommand<string> SubmitOrderCommand { get; private set; }


    }
}
