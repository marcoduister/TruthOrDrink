using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TruthOrDrink.Views.Game
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Scoreboard : ContentPage
    {
        public Scoreboard()
        {
            InitializeComponent();
            FillList();
        }
        private void FillList()
        {
            var items = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                items.Add(string.Format("Winner {0}", i));
            }

            WinnerList.ItemsSource = items;

        }
    }
}