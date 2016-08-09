using Budget1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            var expanse = App.Database.GetExpanse(Id);
            var item = App.Database.GetItem(Id);
            Category.Text = expanse.Category;
            Item.Text = item.item;
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
            Exapnses expanse = new Exapnses();
            Items item = new Items();

            expanse.Category = Category.Text;
            item.Item = Item.Text;
            item.Price = Int32.Parse(Price.Text);
            expanse.ID = updatedID;
            item.Id = updatedIDItem;

            expanse.Items = new List<Items> { item };

            Clear();
            App.Database.SaveExpanse(expanse);
            App.Database.SaveItems(item);

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
