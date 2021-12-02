using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Views.Category;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Question
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            QuestionList.ItemsSource = await App.Database.GetQuestionAllAsync();
        }



        private void AddQuestionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuestionAddPage());
        }

        async void QuestionDeleteButton_Clicked(object sender, EventArgs e)
        {
            string Id = ((ImageButton)sender).BindingContext.ToString();
            bool answer = await DisplayAlert("Deleting a Question?", "are you sure you want to do this", "Yes", "No");
            if (answer)
            {
                Model.Question question = await App.Database.GetQuestionbyIdAsync(int.Parse(Id));
                if (question != null)
                {
                    await App.Database.DeleteQuestionAsync(question);

                    QuestionList.ItemsSource = await App.Database.GetQuestionAllAsync();
                }
            }

        }

        private void QuestionEditButton_Clicked(object sender, EventArgs e)
        {
            string Id = ((ImageButton)sender).BindingContext.ToString();
            Navigation.PushAsync(new CategoryEditPage(int.Parse(Id)));
        }
    }
}