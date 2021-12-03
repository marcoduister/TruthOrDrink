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
        public static DataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataBase(Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "TruthOrDrink.db3"));
                }
                return database;
            }
        }


        public App()
        {
            InitializeComponent();
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
