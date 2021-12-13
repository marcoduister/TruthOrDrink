using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        Model.Game _Game;
        Model.Player _Player;
        Model.Question _Question;
        public GamePage( Model.Game game , Model.Player player, Model.Question question)
        {
            InitializeComponent();
            _Game = game;
            _Player = player;
            _Question = question;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (_Player == null)
            {
                TypeQuestionLabel.Text = "Everyone";
                GameTruthButton.IsVisible = false;
                GameDrinkButton.IsVisible = false;
            }
            else
            {
                PlayerName.Text = _Player.Playername;
                PlayerScore.Text = _Player.Score.ToString();
                GameJudgeButton.IsVisible = false;
            }
            QuestionLabel.Text = _Question.QuestionItem;
        }

        private void GameTruthButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameJudgePage());
        }

        private void GameDrinkButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameJudgePage());
        }

        private void GameJudgeButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}