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

        /// <summary>
        /// Deserializes the data from xml
        /// </summary>
        /// <returns>List of expanses</returns>
        public static List<Exapnses> NewData()
        {
            var expanse = DependencyService.Get<ISerialization>().Deserialize();
            return expanse;
        } 

        /// <summary>
        /// Adds Item to the list of expanses
        /// </summary>
        /// <param name="category">The category of the item</param>
        /// <param name="item">The name of the item</param>
        /// <param name="price">The price of the item</param>
        /// <param name="id">Guid</param>
        public static void AddItem( string category, string item, int price, Guid id)
        {
            var expen = DependencyService.Get<ISerialization>().Deserialize();
            category = InitCap(category);
            item = InitCap(item);
            var items = new Items { ItemId = id, Item = item, Price = price };

            if (expen.Exists(x => x.Category == category))
            {
                AddToExistingCategory(category, id, expen, items);
            }
            else
            {
                AddToNewCategory(category,items, expen);
            }
            DependencyService.Get<ISerialization>().SerializeObject(expen);
        }

        private static void AddToNewCategory(string category, Items items, List<Exapnses> expen)
        {
            expen.Add(new Exapnses
            {
                Category = category,
                Items = new List<Items>
                {items}
            });
        }
        private static void AddToExistingCategory(string category, Guid id, List<Exapnses> expen, Items items)
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

        /// <summary>
        /// Finds the Category of the item
        /// </summary>
        /// <param name="item"> The item name</param>
        /// <returns>The category name in string</returns>
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
