using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TruthOrDrink.Views;

namespace TruthOrDrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var Password = PasswordEntry.Text;
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(Password))
            {
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                
            }
        }
    }
}