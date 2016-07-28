﻿using Budget1.Data;
using Budget1.Models;
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
        public List<Exapnses> MyExpanses { get; set; }
        public MainPage()
        {
            Init();
            InitializeComponent();
        }

        private async Task Init()
        {
            MyExpanses = new List<Exapnses>();

            var listOfExapnses = new List<Exapnses>();
            listOfExapnses = await ExpansesGenerator.CreateExpanse();
            MyExpanses = listOfExapnses;
            BindingContext = this;
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
