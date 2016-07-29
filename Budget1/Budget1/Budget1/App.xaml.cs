using Budget1.Data;
using Budget1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Budget1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ExpanseEntry());
        }

        static ExpansesDatabase database;
        public static ExpansesDatabase Database {
            get{
                if (database==null)
                {
                    database = new ExpansesDatabase();
                }
                return database;
            }
        }


    
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
