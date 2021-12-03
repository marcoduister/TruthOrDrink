using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TruthOrDrink.Views;

namespace TruthOrDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            ValidateLabel.IsVisible = false;
            var email = EmailEntry.Text;
            var Password = PasswordEntry.Text;
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(Password))
            {
                var User = await App.Database.GetUserAsync(email, Password);
                if (User != null)
                {
                    Application.Current.Properties.Clear();
                    Application.Current.Properties["Email"] = email;
                    Application.Current.Properties["UserId"] = User.Id;
                    await Navigation.PushAsync(new HomePage());
                }
                else
                {
                    ValidateLabel.Text = "please check your credentials!";
                    ValidateLabel.IsVisible = true;
                }
            }
            else
            {
                ValidateLabel.Text = "please fill in all Text fields";
                ValidateLabel.IsVisible = true;
            }
        }
    }
}