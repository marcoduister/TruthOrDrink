using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class cocktailGenerate : ContentPage
    {
        public cocktailGenerate()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NextDrink();
        }
        public void NextDrink()
        {
            CockTailsview.ItemsSource = (System.Collections.IEnumerable)API.GetCockTailsByrandom();
        }

        private void GenerateButton_Clicked(object sender, EventArgs e)
        {
            NextDrink();
        }
    }
}