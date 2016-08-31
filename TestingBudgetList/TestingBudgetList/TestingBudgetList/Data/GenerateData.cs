using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TestingBudgetList.Models;
using TestingBudgetList.Data;
using Xamarin.Forms;

namespace TestingBudgetList.Data
{
    public class GenerateData
    {
        //private static List<Exapnses> expen = new List<Exapnses>();

        //private static List<Exapnses> expanses = new List<Exapnses>
        //                    {
        //                        new Exapnses
        //                            {
        //                                Category = "Clothes",
        //                                Items = new List<Items>
        //                                             {
        //                                                 new Items {Item = "Short", Price=25},
        //                                                 new Items {Item = "Pants", Price=33}
        //                                             }
        //                            },
        //                        new Exapnses
        //                            {
        //                                Category = "Toys",
        //                                Items = new List<Items>
        //                                             {
        //                                                 new Items {Item = "Truck", Price=22},
        //                                                 new Items {Item ="Car", Price= 2}
        //                                             }
        //                            }
        //};

        public GenerateData()
        {
        }

        public static List<Exapnses> NewData()
        {
            var expanse = DependencyService.Get<ISerialization>().Deserialize();
            return expanse;
        } 

        public static void AddItem( string category, string item, int price, Guid id)
        {
            var expen = DependencyService.Get<ISerialization>().Deserialize();
            category = InitCap(category);
            item = InitCap(item);
            var items = new Items { ItemId = id, Item = item, Price = price };

            if (expen.Exists(x => x.Category == category))
            {
                foreach (var exp in expen)
                {
                    if (exp.Category == category)
                    {
                        var itemToRemove = exp.Items.SingleOrDefault(r => r.ItemId == id);
                        if (itemToRemove != null)
                            exp.Items.Remove(itemToRemove);
                        exp.Items.Add(items);
                    }
                }
            }
            else
            {
                expen.Add(new Exapnses
                {
                    Category = category,
                    Items = new List<Items>
                { new Items {ItemId=id, Item = item, Price=price}}

                });
            }
            DependencyService.Get<ISerialization>().SerializeObject(expen);
        }
 
        
        public static string FindCategoryByItem(string item)
        {
            var expanses = DependencyService.Get<ISerialization>().Deserialize();
            var answer = (from exp in expanses from it in exp.Items
                         where it.Item == item
                         select exp.Category).ToList();
            return answer[0].ToString();
        }


        private static string InitCap(string value)
        {
            char[] array = value.ToCharArray();

            for (int i = 1; i < array.Length; i++)
            {
                array[i] = char.ToLower(array[i]);
            }

            if (array.Length >= 1)
            {
                array[0] = char.ToUpper(array[0]);
            }

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    array[i] = char.ToUpper(array[i]);
                }
            }
            return new string(array);
        }

    }
}
