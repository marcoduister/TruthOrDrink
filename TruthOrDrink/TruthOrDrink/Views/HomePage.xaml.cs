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
    }
}