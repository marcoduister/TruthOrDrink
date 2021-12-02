using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        public GamePage()
        {
            InitializeComponent();
            PlayerName.Text = "Evie";
            PlayerScore.Text = "10";
        }

        private void GameTruthButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameJudgePage());
        }

        private void GameDrinkButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameJudgePage());
        }
    }
}