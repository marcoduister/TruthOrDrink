using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        Model.Game _Game;
        List<Model.Player> _Player = new List<Player>();
        List<Model.Question> _Question = new List<Model.Question>();

        int playercounter = 0;
        int Player_id = 0;
        int Current_Question = 0;

        public GamePage(Model.Game game)
        {
            InitializeComponent();
            _Game = game;

        }
        public DateTime start = new DateTime();
        public bool counter = false;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Accelerometer.IsMonitoring)
                return;

            Accelerometer.ReadingChanged += Accelerometer_Readingchanged;
            Accelerometer.Start(SensorSpeed.UI);
            Reloud();
        }
        private void Accelerometer_Readingchanged(object sender,AccelerometerChangedEventArgs e)
        {
            var X = e.Reading.Acceleration.X;
            var Y = e.Reading.Acceleration.Y;
            var Z = e.Reading.Acceleration.Z;

            if (-0.5000000 >= X && -0.7000000 <= X || 0.7000000 >= X && 0.5000000 <= X)
            {
                if (start == new DateTime())
                {
                    start = DateTime.Now;
                }
                else
                {
                    if (!counter)
                    {
                        if ((start - DateTime.Now).TotalSeconds <= -30)
                        {
                            if (-0.5000000 >= X && -0.7000000 <= X)
                            {
                                GameTruthButton_Clicked(null, null);
                            }
                            else
                            {
                                GameDrinkButton_Clicked(null, null);
                            }
                            counter = true;
                        }
                        else
                        {
                            TiltCounter.Text = "Sec " + Math.Round((DateTime.Now - start).TotalSeconds, 0);
                        }
                    }
                    else
                    {
                        counter = false;
                        start = new DateTime();
                        TiltCounter.Text = "Sec 0";
                    }
                }
            }
            else
            {
                counter = false;
                start = new DateTime();
            }
        }
        protected override void OnDisappearing()
        {
            if (!Accelerometer.IsMonitoring)
                return;

            Accelerometer.ReadingChanged -= Accelerometer_Readingchanged;
            Accelerometer.Stop();
            base.OnDisappearing();
        }


        private async void Reloud()
        {
            _Player = await App.Database.GetPlayersByGameIdAsync(_Game.Id);
            _Question = await App.Database.GetQuestionAllbyIdAsync(_Game.Categoryid);

            if (playercounter > _Player.Count() - 1)
            {
                WhoIsLabel.Text = "Everyone";
                PlayerScore.IsVisible = false;
                GameJudgeButton.IsVisible = true;
                GameTruthButton.IsVisible = false;
                GameDrinkButton.IsVisible = false;

                playercounter = 0;
            }
            else
            {
                GameJudgeButton.IsVisible = false;
                GameTruthButton.IsVisible = true;
                GameDrinkButton.IsVisible = true;
                PlayerScore.IsVisible = true;
                WhoIsLabel.Text = _Player[playercounter].Playername;
                PlayerScore.Text = _Player[playercounter].Score.ToString();
                Player_id = _Player[playercounter].Id;
                playercounter += 1;
            }
            if (Current_Question < _Question.Count())
            {
                QuestionLabel.Text = _Question[Current_Question].QuestionItem;

                Current_Question += 1;
            }
            else
            {
                var Winner = _Player.First(e=>e.Score == _Player.Max(a => a.Score));
                await DisplayAlert("Winner!!!", "the winnar is '"+Winner.Playername + "'  is", "OK");

                await App.Database.inserScoreboard(Winner);

                _ = Navigation.PopAsync();
            }

        }

        private async void GameTruthButton_Clicked(object sender, EventArgs e)
        {
            Model.Player player = _Player.Where(a=>a.Id == Player_id).First();
            player.Score += 10;
            await App.Database.PlayerUpdate(player);
            Reloud();
        }

        private void GameDrinkButton_Clicked(object sender, EventArgs e)
        {
            Reloud();
        }

        private async void GameJudgeButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new GameJudgePage(_Game));
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("Stopping game", "are you sure you want to do this", "Yes", "No"))
            {
                base.OnBackButtonPressed();
                await App.Database.DeleteGame(_Game);

                for (var counter = 1; counter < 2; counter++)
                {
                    Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
                }
                await Navigation.PopAsync();

            }
        }
    }
}