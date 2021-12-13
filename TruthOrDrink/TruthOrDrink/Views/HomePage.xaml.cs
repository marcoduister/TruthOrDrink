using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Views.Game;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }


        private void PlayRedirectButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameCreatePage());
        }

        private void GameRulesRedirectButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameRules());
        }

        private void CategoryRedirectButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoryPage());
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
            Navigation.PushAsync(new MainPage());
        }

        private void ScoreboardRedirectButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Scoreboard());
        }

        private void Profilebutton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Profile());
        }

        private void DrinkGeneraterRedirectButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new cocktailGenerate());
        }
    }
}