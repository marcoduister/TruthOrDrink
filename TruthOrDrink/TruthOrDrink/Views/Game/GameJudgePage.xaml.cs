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
    public partial class GameJudgePage : ContentPage
    {
        private Model.Game _Game;
        public GameJudgePage(Model.Game Game)
        {
            InitializeComponent();
            _Game = Game;

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            PlayerList.ItemsSource = await App.Database.GetPlayersByGameIdAsync(_Game.Id);
        }

        private async void PlayerList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Model.Player Player = (Model.Player)e.SelectedItem;
            Player.Score += 10;

            await App.Database.PlayerUpdate(Player);
            _ = Navigation.PopAsync();
        }
    }
}