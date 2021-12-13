using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        }

        private void AddPlayerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameUserAddPage(Gameplay.Id));
        }

        private async void PlayerDeleteButton_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Deleting a player?", "are you sure you want to do this", "Yes", "No");
            if (answer)
            {
                Debug.WriteLine("Answer: " + answer);
            }
        }

        private async void playButton_Clicked(object sender, EventArgs e)
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
                    List<Model.Question> Questions = await App.Database.GetQuestionAllbyIdAsync(Gameplay.Categoryid);
                    var count = Questions.Count() / players.Count();
                    int UserCounter = 0;
                    
                    foreach (var question in Questions)
                    {
                        var hahah = players.Count();
                        if (UserCounter > players.Count()-1)
                        {
                            _ = Navigation.PushAsync(new GamePage(Gameplay, null, question));
                            UserCounter = 0;
                        }
                        else
                        {
                            _ = Navigation.PushAsync(new GamePage(Gameplay, players[UserCounter], question));
                            UserCounter += 1;
                        }                        
                    }
                }
            }
            else
            {
                CategoryPickerLabel.Text = "Please Sellect an Category "; CategoryPickerLabel.IsVisible = true;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            App.Database.DeleteGame(Gameplay);
            // true or false to disable or enable the action
            return base.OnBackButtonPressed();
        }
    }
}