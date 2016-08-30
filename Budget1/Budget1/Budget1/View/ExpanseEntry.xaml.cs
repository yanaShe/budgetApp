using Budget1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Budget1.View
{
    public partial class ExpanseEntry : ContentPage
    {
        private int updatedID = 0;
        private int updatedIDItem = 0;

        public ExpanseEntry(int Id)
        {
            InitializeComponent();
            
            var item = App.Database.GetItem(Id);
            var cat = App.Database.GetCategory(Id);

            Category.Text = cat;
            Item.Text = item.Item;
            Price.Text = item.Price.ToString();
            updatedID = Id;
            updatedIDItem = Id;
        }

        public ExpanseEntry()
        {
            InitializeComponent();
        }

        public void OnSave(object o, EventArgs e)
        {
            Exapnses expanse = new Exapnses
            {
                Category = Category.Text
            };
            App.Database.SaveExpanse(expanse);

            Items item = new Items
            {
                Item = Item.Text,
                Price = Int32.Parse(Price.Text)
            };
            
            App.Database.SaveItems(item);

            App.Database.SaveAll(expanse, item);

            Clear();
            Navigation.PushAsync(new MainPage());
        }

        private void Clear()
        {
            Category.Text = Item.Text = Price.Text = String.Empty;
        }

        private void OnCancel(object o, EventArgs e)
        {
            Clear();
        }

        private void OnReview(object o, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void OnDelete(object o , EventArgs e)
        {
            App.Database.DeleteExpanse(updatedID);
            Clear();
        }
    }
}
