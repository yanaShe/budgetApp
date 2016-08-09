using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingBudgetList.Models;

namespace TestingBudgetList.Data
{
    public class GenerateData
    {
        public GenerateData()
        {
            List<Exapnses> expanses = new List<Exapnses>
                            {
                                new Exapnses
                                    {
                                        Category = "Clothes",
                                        Items = new List<Items>
                                                     {
                                                         new Items {Item = "Short", Price=25},
                                                         new Items {Item = "Pants", Price=33}
                                                     }
                                    },
                                new Exapnses
                                    {
                                        Category = "Toys",
                                        Items = new List<Items>
                                                     {
                                                         new Items {Item = "Truck", Price=22},
                                                         new Items {Item ="Car", Price= 2}
                                                     }
                                    }
        };

        }              
    }
}
