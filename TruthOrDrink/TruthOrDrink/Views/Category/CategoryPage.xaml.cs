using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Views.Category;
using TruthOrDrink.Views.Question;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
            FillList();
        }
        private void FillList()
        {
            var items = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                items.Add(string.Format("Category {0}", i));
            }

            CategoryList.ItemsSource = items;

        }


        private void AddCategorieButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CategoryAddPage());
        }

        private async void CategoryDeleteButton_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Deleting a Question?", "are you sure you want to do this", "Yes", "No");
            if (answer)
            {
                Debug.WriteLine("Answer: " + answer);
            }
            
        }

        private void CategoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new QuestionPage());
        }
    }
}