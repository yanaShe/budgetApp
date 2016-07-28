using Budget1.Models;
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

        private static List<string> Things = new List<string> { "Dress", "Toy Truck", "Washing Machine", "Restaurant" };

        private static List<int> Prices = new List<int> { 20, 25, 300, 60 };


        public static async Task<List<Exapnses>> CreateExpanse()
        {
            List<Exapnses> expanses = new List<Exapnses>();

            for (int i = 0; i < 4; i++)
            {
                string category = Categories[i];
                string thing = Things[i];
                int price = Prices[i];
                Exapnses expanse = new Exapnses();

                expanse.Category = category;
                expanse.Thing = thing;
                expanse.Price = price;

                expanses.Add(expanse);
            }
            return expanses;
        }
    }
}
