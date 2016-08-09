using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingBudgetList.Models;
using Xamarin.Forms;

namespace TestingBudgetList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var expanses = new List<Exapnses>
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



            CategoryList.ItemsSource = expanses;
        }
    }
}
