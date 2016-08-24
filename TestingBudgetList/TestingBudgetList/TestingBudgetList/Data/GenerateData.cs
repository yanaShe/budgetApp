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
        private static List<Exapnses> expanses = new List<Exapnses>
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
        public  GenerateData()
        {

        }
        public static List<Exapnses> NewData()
        {
            return expanses;
        } 

        public static List<Exapnses> AddItem( string category, string item, int price)
        {
            var items = new Items { Item = item, Price = price };

            if (expanses.Exists(x => x.Category == category))
            {
                foreach (var exp in expanses)
                {
                    if (exp.Category == category)
                        {
                            exp.Items.Add(items);
                        }
                    }
                }
           else
            {
                expanses.Add(new Exapnses
                {
                    Category = category,
                    Items = new List<Items>
                { new Items {Item = item, Price=price}}

                });
            }

            return expanses;
        }     
    }
}
