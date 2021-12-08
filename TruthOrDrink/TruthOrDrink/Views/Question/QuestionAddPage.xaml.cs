using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Question
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionAddPage : ContentPage
    {
        private int CategoryId;
        public QuestionAddPage(int id)
        {
            InitializeComponent();
            CategoryId = id;
        }

        private async void CreateQuestionButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QuestionEntry.Text))
            {
                await App.Database.InsertQuestionAsync(new Model.Question
                {
                    QuestionItem = QuestionEntry.Text,
                    Categoryid =  CategoryId,
                    Date = DateTime.Now,
                    Userid = int.Parse(Application.Current.Properties["UserId"].ToString())
                });
                QuestionEntry.Text = string.Empty;

                _ = Navigation.PopAsync();

            }
        }
    }
}