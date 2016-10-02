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
        private Color validColor = Color.Black;
        private Color inValidColor = Color.Red;
        private string title = "Error";
        private string cancel = "Ok";
        Guid updatedId = Guid.NewGuid();



        public AddItemPage()
        {
            InitializeComponent();
        }

        public AddItemPage(Items item, string cat)
        {
            InitializeComponent();
            Category.Text = cat;
            Item.Text = item.Item;
            Price.Text = item.Price.ToString();
            updatedId = item.ItemId;

            //LastName.Text = contact.LastName;
            //Email.Text = contact.Email;
            //IsFavorite.IsToggled = contact.Favorite;
            //updateID = id;
        }
        public void Category_TextChanged (object sender, TextChangedEventArgs e)
        {
            var newText = e.NewTextValue;
          
            if (!string.IsNullOrEmpty(Category.Text))
            {
                textbox.IsVisible = false;
            }
            else textbox.IsVisible = true;

        }

        public void Price_TextChanged(object sender, TextChangedEventArgs e)
        {
            var newText = e.NewTextValue;
            var price = 0;
            bool result = int.TryParse(Price.Text, out price);
           
            if (!result)
            {
                Price.TextColor = inValidColor;
                pricebox.IsVisible = true;
                pricebox.Text = "The price value must be a number";
            }

            else if (!string.IsNullOrEmpty(Price.Text))
            {
                pricebox.IsVisible = false;
                Price.TextColor = validColor;
            }
        }

        public void Item_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Item.Text))
            {
                itembox.IsVisible = false;
            }
            else itembox.IsVisible = true;
        }

        public void OnSave (object o, EventArgs e)
        {
            var category = Category.Text;
            var item = Item.Text;
            
            var price = 0;
            bool result = int.TryParse(Price.Text, out price);
            if (string.IsNullOrEmpty(item) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(Price.Text))
            {
                var message = string.Format("One or more of the values is missing. All values are required.");
                DisplayAlert(title, message, cancel);
                return;
            }
  
            if (!result)
            {
                var message = "The price value must be a number.";
                DisplayAlert(title, message, cancel);
                return;
            }
            
            GenerateData.AddItem(category, item, price, updatedId);
            Clear();
            Navigation.PushAsync(new MainPage());
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
