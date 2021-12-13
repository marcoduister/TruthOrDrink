using System;
using System.IO;
using TruthOrDrink.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TruthOrDrink.Views;

namespace TruthOrDrink
{
    public partial class App : Application
    {
        private static DataBase database;

        private static string DatabaseLocation = string.Empty;

        public static DataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataBase(DatabaseLocation);
                }
                return database;
            }
        }


        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        public App(string DBlocation)
        {
            InitializeComponent();
            DatabaseLocation = DBlocation;
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
