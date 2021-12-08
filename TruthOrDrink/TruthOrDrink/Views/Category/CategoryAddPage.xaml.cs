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
    public partial class CategoryAddPage : ContentPage
    {
        public CategoryAddPage()
        {
            InitializeComponent();
        }

         async void CreateCategoryButton_ClickedAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CategoryNameEntry.Text) && !string.IsNullOrWhiteSpace(DescriptionEntry.Text))
            {
                await App.Database.InsertCategoryAsync(new Model.Category
                {
                    Name = CategoryNameEntry.Text,
                    Description = DescriptionEntry.Text,
                    Date = DateTime.Now,
                    Userid = int.Parse(Application.Current.Properties["UserId"].ToString())
                }); 
                CategoryNameEntry.Text = string.Empty;
                DescriptionEntry.Text = string.Empty;


                _ = Navigation.PopAsync();

            }

        }
    }
}