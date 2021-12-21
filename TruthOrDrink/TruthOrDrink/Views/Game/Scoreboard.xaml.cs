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
    public partial class Scoreboard : ContentPage
    {
        public Scoreboard()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var winnerList = await App.Database.GetScoreboardAllAsync();
            if (winnerList.Count > 0)
            {
                WinnerList.ItemsSource = winnerList;
            }
            else
            {
                List<Model.Scoreboard> scoreboardList = new List<Model.Scoreboard>();
                Model.Scoreboard scoreboard = new Model.Scoreboard()
                {
                    PlayerName = "there are no winners yet!",
                };
                scoreboardList.Add(scoreboard);
                WinnerList.ItemsSource = scoreboardList;
            }
        }
    }
}