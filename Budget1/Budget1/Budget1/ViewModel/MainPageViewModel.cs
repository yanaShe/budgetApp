using Budget1.Data;
using Budget1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget1.ViewModel
{
    public class MainPageViewModel
    {
        public List<Exapnses> MyExpanses { get; set; }

        public MainPageViewModel()
        {
            MyExpanses = new List<Exapnses>();
            var listOfExapnses = new List<Exapnses>();
            listOfExapnses =  ExpansesGenerator.CreateExpanse();
            MyExpanses = listOfExapnses;
        }

    }
}
