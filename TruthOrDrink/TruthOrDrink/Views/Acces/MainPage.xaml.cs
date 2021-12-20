using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TruthOrDrink.Views;
using TruthOrDrink.Views.Game;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TruthOrDrink.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();


        }
        public DateTime start = new DateTime();
        public bool counter = false;

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void RegisterRedirectButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistrationPage());
        }

        private void LoginRedirectButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}
