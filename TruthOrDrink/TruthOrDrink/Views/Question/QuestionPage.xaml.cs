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
            FillList();
        }
        private void FillList()
        {
            var items = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                items.Add(string.Format("Question {0}", i));
            }

            QuestionList.ItemsSource = items;

        }

        private void AddQuestionButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuestionAddPage());
        }

        private async void QuestionDeleteButton_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Deleting a Question?", "are you sure you want to do this", "Yes", "No");
            if (answer)
            {
                Debug.WriteLine("Answer: " + answer);
            }
        }
    }
}