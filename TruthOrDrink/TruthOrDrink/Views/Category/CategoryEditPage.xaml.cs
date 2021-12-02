using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Category
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryEditPage : ContentPage
    {
        private Model.Category _Category;
        private int _Id;
        public CategoryEditPage(int Id)
        {
            InitializeComponent();
            _Id = Id;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _Category = await App.Database.GetCategorybyIdAsync(_Id);
            CategoryNameEntry.Text = _Category.Name;
            DescriptionEntry.Text = _Category.Description;
        }

        async void EditCategoryButton_ClickedAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CategoryNameEntry.Text) && !string.IsNullOrWhiteSpace(DescriptionEntry.Text))
            {
                await App.Database.UpdateCategoryAsync(new Model.Category
                {
                    Id = _Id,
                    Name = CategoryNameEntry.Text,
                    Description = DescriptionEntry.Text,
                    Date = DateTime.Now,
                    Userid = 0
                }); 
                CategoryNameEntry.Text = string.Empty;
                DescriptionEntry.Text = string.Empty;


                _ = Navigation.PopAsync();

            }

        }
    }
}