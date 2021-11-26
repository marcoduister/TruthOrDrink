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
        public QuestionAddPage()
        {
            InitializeComponent();
        }

        private void CreateQuestionButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}