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
        private int _UserId;
        public CategoryPage()
        {
            InitializeComponent();
            _UserId = int.Parse(Application.Current.Properties["UserId"].ToString());
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            CategoryList.ItemsSource = await App.Database.GetCategoryAllByUserIdAsync(_UserId);
        }



        private void AddCategorieButton_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new CategoryAddPage());
        }

        async void CategoryDeleteButton_Clicked(object sender, EventArgs e)
        {
            string Id = ((ImageButton)sender).BindingContext.ToString();
            bool answer = await DisplayAlert("Deleting a Question?", "are you sure you want to do this", "Yes", "No");
            if (answer)
            {
                Model.Category category = await App.Database.GetCategorybyIdAsync(int.Parse(Id));
                if (category != null)
                {
                    await App.Database.DeleteCategoryAsync(category);

                    CategoryList.ItemsSource = await App.Database.GetCategoryAllByUserIdAsync(_UserId);
                }
            }
        }

        private void CategoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var categorie = (Model.Category) e.SelectedItem;

            int Id = categorie.Id;
            Navigation.PushAsync(new QuestionPage(Id));
        }

        private void CategoryEditButton_Clicked(object sender, EventArgs e)
        {
            string Id = ((ImageButton)sender).BindingContext.ToString();
            Navigation.PushAsync(new CategoryEditPage(int.Parse(Id)));
        }
    }
}