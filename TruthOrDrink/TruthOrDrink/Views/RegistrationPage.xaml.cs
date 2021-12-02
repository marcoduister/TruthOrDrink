using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            NickNameEntryLabel.IsVisible = EmailEntryLabel.IsVisible = PasswordconfirmEntryLabel.IsVisible = PasswordEntryLabel.IsVisible = false;
            string Email = EmailEntry.Text;
            string NickName = PasswordconfirmEntry.Text;
            string Password = PasswordEntry.Text;
            string PasswordConfirm = PasswordconfirmEntry.Text;

            if (!IsEmail(Email) || string.IsNullOrWhiteSpace(Email))
            {
                EmailEntryLabel.Text = "Please Check That You have Enterd A Valid Email Adress"; 
                EmailEntryLabel.IsVisible = true;
            }
            if (string.IsNullOrWhiteSpace(NickName))
            {
                NickNameEntryLabel.Text = "Please enter a Nickname"; NickNameEntryLabel.IsVisible = true;
            }
            if (string.IsNullOrWhiteSpace(Password))
            {
                PasswordEntryLabel.Text = "Please enter a Password"; PasswordEntryLabel.IsVisible = true;
            }
            if (string.IsNullOrWhiteSpace(PasswordConfirm))
            {
                PasswordconfirmEntryLabel.Text = "Please confirm Password"; PasswordconfirmEntryLabel.IsVisible = true;
            }
                

            if (!NickNameEntryLabel.IsVisible && !EmailEntryLabel.IsVisible && !PasswordconfirmEntryLabel.IsVisible && !PasswordEntryLabel.IsVisible)
            {
                NickNameEntryLabel.IsVisible = PasswordEntryLabel.IsVisible = false;
                if (Password == PasswordConfirm)
                {
                    var User = await App.Database.EmailExistAsync(Email);
                    if (User == null)
                    {
                        await App.Database.InsertUserAsync(new Model.User
                        {
                            Email = Email,
                            NickName = NickName,
                            Password = PasswordConfirm

                        });
                        EmailEntry.Text = string.Empty;
                        PasswordconfirmEntry.Text = string.Empty;
                        PasswordEntry.Text = string.Empty;
                        PasswordconfirmEntry.Text = string.Empty;

                        await Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        EmailEntryLabel.Text = "This email is already in Use Please use other one"; 
                        EmailEntryLabel.IsVisible = true;
                    }
                        
                }
                else
                {
                    PasswordconfirmEntryLabel.Text = "PasswordConfirm en Password do not match"; 
                    PasswordconfirmEntryLabel.IsVisible = true;
                }
                    
            }

        }

        private bool IsEmail(string Email)
        {

            try
            {
                if (Email == "" || Email == null)
                {
                    return false;
                }
                MailAddress email = new MailAddress(Email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}