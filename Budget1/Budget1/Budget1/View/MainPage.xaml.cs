﻿using Budget1.Data;
using Budget1.Models;
using Budget1.View;
using Budget1.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Budget1
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var expanse = e.Item as Items;
            Navigation.PushAsync(new ExpanseEntry(expanse.Id));
            
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CategoryList.ItemsSource = App.Database.GetExpanses();
            //ItemList.ItemSource = App.Database.GetItems();


        }

        protected void OnNewEntry(object o, EventArgs e)
        {
            var rootPage = new NavigationPage(new ExpanseEntry());
            Button button = (Button) o;
            button.Navigation.PushAsync(rootPage);
        }

    }
}

