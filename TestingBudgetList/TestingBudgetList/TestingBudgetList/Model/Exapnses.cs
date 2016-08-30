
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingBudgetList.Models
{
    public class Exapnses
    {
        public string Category { get; set; }
        public List<Items> Items { get; set; }

    }

    public class Items
    {
        public Guid ItemId { get; set; }
        public string Item { get; set; }
        public int Price { get; set; }
    }
   
}
