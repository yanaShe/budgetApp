﻿using Budget1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget1.Data
{
    public class ExpansesGenerator
    {
        private static List<string> Categories = new List<string> { "Clothes", "Toys", "Appliances", "Food" };

        private static List<string> Items = new List<string> { "Dress", "Toy Truck", "Washing Machine", "Restaurant" };

        private static List<int> Prices = new List<int> { 20, 25, 300, 60 };


        public static List<Exapnses> CreateExpanse()
        {
            List<Exapnses> expanses = new List<Exapnses>();

            for (int i = 0; i < 4; i++)
            {
                string category = Categories[i];
                string thing = Items[i];
                int price = Prices[i];
                Exapnses expanse = new Exapnses();
                Items item = new Items();
                
                expanse.Category = category;
                item.Item = thing;
                item.Price = price;

                expanse.Items = new List<Items>
                {
                   item
                };

                expanses.Add(expanse);
            }
            return expanses;
        }
    }
}
