using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        private Model.User _User;
        private  int _Id;
        public Profile()
        {
            InitializeComponent();
            _Id = int.Parse(Application.Current.Properties["UserId"].ToString());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _User = await App.Database.GetUserByIdAsync(_Id);
            NickNameEntry.Text = _User.NickName;
        }
        async void UpdateProfileButton_ClickedAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NickNameEntry.Text))
            {
                if (!string.IsNullOrWhiteSpace(OldPasswordEntry.Text))
                {
                    if (OldPasswordEntry.Text == _User.Password)
                    {
                        if (!string.IsNullOrWhiteSpace(NewPasswordConfirmEntry.Text) && !string.IsNullOrWhiteSpace(NewPasswordEntry.Text))
                        {
                            if (NewPasswordConfirmEntry.Text == NewPasswordEntry.Text)
                            {
                                _User.Password = NewPasswordConfirmEntry.Text;
                                NewPasswordEntryLabel.Text = "password has been updated";
                            }
                            else
                                NewPasswordConfirmEntryLabel.Text = "New confrim password does not match new password";
                        }
                    }
                    else
                        OldPasswordEntryLabel.Text = "please use correct old password";
                }
                else
                    OldPasswordEntryLabel.Text = "please use old password if you try too change it";

                _User.NickName = NickNameEntry.Text;
                NickNameEntryLabel.Text = "Nickname has been updated";
            }
            else
                NickNameEntryLabel.Text = "Please enter a nickname in";

            await App.Database.UpdateUserAsync(_User);

        }
    }
}