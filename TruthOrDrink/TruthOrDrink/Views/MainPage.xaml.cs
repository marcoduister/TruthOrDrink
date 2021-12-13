using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Views;
using TruthOrDrink.Views.Game;
using Xamarin.Forms;

namespace TruthOrDrink.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

                InitializeComponent();
            
            
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

        private void tmp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage(null,null,null));
        }
    }
}
