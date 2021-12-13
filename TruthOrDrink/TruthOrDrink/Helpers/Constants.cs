using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Helpers
{
    class Constants
    {
        public const string CocktailByname = "https://www.thecocktaildb.com/api/json/v1/1/search.php?s={0}";
        public const string CochtailByRandom = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
        public const string CocktailbyIngrediant = "https://www.thecocktaildb.com/api/json/v1/1/search.php?i={0}";


            //Search cocktail by name
            //www.thecocktaildb.com/api/json/v1/1/search.php? s = margarita

            //Search ingredient by name
            //www.thecocktaildb.com/api/json/v1/1/search.php? i = vodka

            //Lookup a random cocktail
            //www.thecocktaildb.com/api/json/v1/1/random.php

    }
}
