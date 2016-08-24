using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingBudgetList.Models;
using Xamarin.Forms;
using TestingBudgetList.Data;

namespace TestingBudgetList.View
{
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
        }

        public void OnSave (object o, EventArgs e)
        {
            var category = Category.Text;
            var item = Item.Text;
            int price = Int32.Parse(Price.Text);
            GenerateData.AddItem(category, item, price);
            Clear();
            Navigation.PushAsync(new MainPage());       
            
            //Contact contact = new Contact();
            //contact.FirstName = FirstName.Text;
            //contact.LastName = LastName.Text;
            //contact.Email = Email.Text;
            //contact.Favorite = IsFavorite.IsToggled;
            //contact.ID = updateID;
            //Clear();
            //App.Database.SaveContact(contact);
            //Navigation.PushAsync(new MainPage());
        }

        public void OnCancel (object o, EventArgs e)
        {
            Clear();
        }

        private void OnReview(object o, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void Clear()
        {
            Category.Text = Item.Text = Price.Text = string.Empty;
        }
    }
}
