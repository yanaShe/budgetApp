using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingBudgetList.Models;
using TestingBudgetList.Data;

namespace TestingBudgetList.ViewModel
{
    class MainPageViewModel
    {
        public List<Exapnses> expanses { get; set; }
        
        public MainPageViewModel()
        {
            expanses = new List<Exapnses>();
            List<Exapnses> listofExpanses = GenerateData.NewData();
            expanses = listofExpanses;


        }

    }
}
