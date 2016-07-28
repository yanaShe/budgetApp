using Budget1.Data;
using Budget1.Models;
using Budget1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Budget1
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;

        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
            BindingContext = vm;
        }

        public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var expanse = e.Item as Exapnses;

            if (e != null)
            {
                DisplayAlert("Yep", String.Format("You Selected: {0}, {1}", expanse.Category, expanse.Thing), "Ok");

            }
        }

    }
}
