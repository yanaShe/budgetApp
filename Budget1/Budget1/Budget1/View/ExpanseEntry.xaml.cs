using Budget1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Budget1.View
{
    public partial class ExpanseEntry : ContentPage
    {
        private int updatedID = 0;

        public ExpanseEntry(int Id)
        {
            InitializeComponent();
            var expanse = App.Database.GetExpanse(Id);
            Category.Text = expanse.Category;
            Thing.Text = expanse.Thing;
            Price.Text =expanse.Price.ToString();
            updatedID = Id;
        }

        public ExpanseEntry()
        {
            InitializeComponent();
        }

        public void OnSave(object o, EventArgs e)
        {
            Exapnses expanse = new Exapnses();
            expanse.Category = Category.Text;
            expanse.Thing = Thing.Text;
            expanse.Price = Int32.Parse(Price.Text);
            expanse.ID = updatedID;
            Clear();
            App.Database.SaveExpanse(expanse);
            Navigation.PushAsync(new MainPage());
        }

        private void Clear()
        {
            Category.Text = Thing.Text = Price.Text = String.Empty;
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
