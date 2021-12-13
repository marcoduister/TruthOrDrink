using System;
using System.Collections.Generic;
using System.Text;
using TruthOrDrink.Helpers;

namespace TruthOrDrink.Model
{
    public class Cocktail
    {
        public static string GeneratedUrlByName(string Name)
        {
            return string.Format(Constants.CocktailByname, Name);
        }

        public static string GeneratedUrlByIngrediant(string Ingrediant)
        {
            return string.Format(Constants.CocktailbyIngrediant, Ingrediant);
        }

        public static string GeneratedUrlByRandom()
        {
            return Constants.CochtailByRandom;
        }

    }
}
