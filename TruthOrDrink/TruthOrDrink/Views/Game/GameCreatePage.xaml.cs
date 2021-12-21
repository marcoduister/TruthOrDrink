using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameCreatePage : ContentPage
    {
        private Model.Game Gameplay = new Model.Game();
        private int _UserId;

        public GameCreatePage()
        {
            InitializeComponent();
            _UserId = int.Parse(Application.Current.Properties["UserId"].ToString());
            Gameplay.Userid = _UserId;
            App.Database.CreateGame(Gameplay);
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //List<Model.Game> haha = await App.Database.GetAllGames(_UserId);

            Categorypicker.ItemsSource = await App.Database.GetCategoryAllByUserIdAsync(_UserId);
            PlayerList.ItemsSource = await App.Database.GetPlayersByGameIdAsync(Gameplay.Id);
            var scoreboard = await App.Database.GetScoreboardByGameIdAsync(Gameplay.Id);
            if (scoreboard.Count() != 0)
            {
                await Navigation.PopAsync();
            }
        }


        private void AddPlayerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameUserAddPage(Gameplay.Id));
        }

        private async void PlayButton_Clicked(object sender, EventArgs e)
        {

            if ((Model.Category)Categorypicker.SelectedItem != null)
            {
                Model.Category Categorie = (Model.Category)Categorypicker.SelectedItem;
                Gameplay.Categoryid = Categorie.Id;
                List<Model.Player> players = (List<Model.Player>)PlayerList.ItemsSource;

                if (players.Count < 3)
                {
                    CategoryPickerLabel.Text = "Please add more players "; CategoryPickerLabel.IsVisible = true;
                }
                else
                {
                    await Navigation.PushAsync(new GamePage(Gameplay));
                }
            }
            else
            {
                CategoryPickerLabel.Text = "Please Sellect an Category "; CategoryPickerLabel.IsVisible = true;
            }
        }

        private async void DeletePlayerButton_Clicked(object sender, EventArgs e)
        {
            string Id = ((ImageButton)sender).BindingContext.ToString();
            bool answer = await DisplayAlert("Deleting a player?", "are you sure you want to do this", "Yes", "No");
            if (answer)
            {
                Model.Player Player = await App.Database.GetPlayerById(int.Parse(Id));
                if (Player != null)
                {
                    await App.Database.DeletePlayer(Player);

                    PlayerList.ItemsSource = await App.Database.GetPlayersByGameIdAsync(Gameplay.Id);
                }
            }
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            _ = App.Database.DeleteGame(Gameplay);
            _ = Navigation.PopAsync();
        }
    }
}