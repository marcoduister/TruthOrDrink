using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameUserAddPage : ContentPage
    {
        private int _GameId;
        private byte[] imageArray = null;
        public GameUserAddPage(int GameId)
        {
            _GameId = GameId;
            InitializeComponent();

        }

        private async void TakePhotoButton_Clicked(object sender, EventArgs e)
        {
            try
            {

                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    SaveToAlbum = true,
                    SaveMetaData = true,
                });

                if (photo != null)
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        Stream stream = photo.GetStream();
                        stream.CopyTo(memory);
                        imageArray = memory.ToArray();
                    }
                    ProfileImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }
        private void AddPlayerButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PlayerName.Text))
            {
                if (imageArray != null)// != null maken naar testen
                {
                    Model.Player NewPlayer = new Model.Player()
                    {
                        Playername = PlayerName.Text,
                        Gameid = _GameId,
                        Score = 0,
                        ProfileImage = imageArray
                    };
                    App.Database.InsertPlayers(NewPlayer);
                    _ = Navigation.PopAsync();
                }
                else
                {
                    ProfileImageLabel.Text = "Please Add profile image "; ProfileImageLabel.IsVisible = true;
                }

            }
            else
            {
                PlayerNameLabel.Text = "Please Enter A PlayerName"; PlayerNameLabel.IsVisible = true;
            }
        }
    }
}
