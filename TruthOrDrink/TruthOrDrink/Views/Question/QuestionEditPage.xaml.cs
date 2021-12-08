using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Question
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionEditPage : ContentPage
    {
        private Model.Question _Question;
        private int _Id;
        public QuestionEditPage(int Id)
        {
            InitializeComponent();
            _Id = Id;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _Question = await App.Database.GetQuestionbyIdAsync(_Id);
            QuestionNameEntry.Text = _Question.QuestionItem;
        }
        async void EditQuestionButton_ClickedAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QuestionNameEntry.Text))
            {
                _Question.QuestionItem = QuestionNameEntry.Text;
                await App.Database.UpdateQuestionAsync(_Question);

                QuestionNameEntry.Text = string.Empty;

                _ = Navigation.PopAsync();
            }
        }
    }
}