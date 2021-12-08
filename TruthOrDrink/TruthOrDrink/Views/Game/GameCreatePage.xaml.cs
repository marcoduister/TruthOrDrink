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
        public GameCreatePage()
        {
            InitializeComponent();
            FillList();
        }
        private void FillList()
        {
            var items = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                items.Add(string.Format("player {0}", i));
            }

            PlayerList.ItemsSource = items;

        }

        private void AddPlayerButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameUserAddPage());
        }

        private async void PlayerDeleteButton_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Deleting a player?", "are you sure you want to do this", "Yes", "No");
            if (answer)
            {
                Debug.WriteLine("Answer: " + answer);
            }
        }

        private void playButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());
        }
    }
}