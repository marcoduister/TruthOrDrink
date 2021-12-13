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
            if (!string.IsNullOrWhiteSpace(CategoryNameEntry.Text))
            {
                if (!string.IsNullOrWhiteSpace(DescriptionEntry.Text))
                {
                    _Category.Name = CategoryNameEntry.Text;
                    _Category.Description = DescriptionEntry.Text;

                    await App.Database.UpdateCategoryAsync(_Category);

                    CategoryNameEntry.Text = string.Empty;
                    DescriptionEntry.Text = string.Empty;

                    _ = Navigation.PopAsync();
                }
                else
                {
                    DescriptionEntryLabel.Text = "Please enter Desription"; DescriptionEntryLabel.IsVisible = true;
                }
            }
            else
            {
                CategoryNameEntryLabel.Text = "Please enter categorie name"; CategoryNameEntryLabel.IsVisible = true;
            }
        }
    }
}