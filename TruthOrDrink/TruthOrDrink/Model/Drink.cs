﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDrink.Model
{
    public class Drink
    {
        public string StrDrink { get; set; }
        public object strDrinkThumb { get; set; }
        public string StrCategory { get; set; }
        public string AllIngrediants
        {
            get
            {
                return strIngredient1 + ", " + strIngredient2 + ", " + strIngredient3 + ", " + strIngredient4 + ", " + strIngredient4 + ", " +
                        strIngredient5 + ", " + strIngredient6 + ", " + strIngredient7 + ", " + strIngredient8 + ", " + strIngredient9 + ", " + strIngredient10 + ", " + strIngredient11 + ", " +
                        strIngredient12 + ", " + strIngredient13 + ", " + strIngredient14 + ", " + strIngredient5;
            }
        }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public string strIngredient8 { get; set; }
        public string strIngredient9 { get; set; }
        public string strIngredient10 { get; set; }
        public string strIngredient11 { get; set; }
        public string strIngredient12 { get; set; }
        public string strIngredient13 { get; set; }
        public string strIngredient14 { get; set; }


    }
}
