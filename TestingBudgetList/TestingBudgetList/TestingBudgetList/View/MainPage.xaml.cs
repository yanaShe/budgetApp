using Xamarin.Forms;
using TestingBudgetList.Data;
using TestingBudgetList.ViewModel;
using TestingBudgetList.Models;
using System.Collections.Generic;
using System.Collections;
using System;

namespace TestingBudgetList.View
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        
        public MainPage()
        {
            InitializeComponent();
            vm = new MainPageViewModel();
            CategoryList.HasUnevenRows = true;
            CategoryList.ItemsSource = vm.expanses;
        }

        public async void OnItemTapped(object o, ItemTappedEventArgs e)
        {

            var item = e.Item as Items;
            
            var cat = GenerateData.FindCategoryByItem(item.Item);
            //var message = string.Format("You selected item {0} with id {1} price {2} in Category {3}", item.Item, item.ItemId, item.Price.ToString(), cat);
            await Navigation.PushAsync(new AddItemPage(item,cat));
            //DisplayAlert("Hello!", message, "Ok");


        }

        public void OnCategoryTapped (object o, ItemTappedEventArgs e)
        {
            var items = e.Item as Exapnses;
            var listofItems = new List<string>();
            

            foreach (var item in items.Items)
            {
                listofItems.Add(item.Item);
            }

            var things = string.Join(",", listofItems);

            var title = string.Format("You selected {0} Category", items.Category);
            var message = string.Format("It contains the following items: {0}", things);
            DisplayAlert(title, message, "Ok");

        }

        public async void AddItemPage(object o, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
            
        }
    }
}
