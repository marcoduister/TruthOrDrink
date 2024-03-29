﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TruthOrDrink.Model;

namespace TruthOrDrink.Data
{
    class API
    {
        public async static Task<IList<Drink>> GetCockTailsByrandom()
        {
            IList<Drink> cocktail;

            var link = Cocktail.GeneratedUrlByRandom();

            using (HttpClient cl = new HttpClient())
            {
                var response = await cl.GetAsync(link);
                var json = await response.Content.ReadAsStringAsync();
                var cocktailResponse = JsonConvert.DeserializeObject<DrinkList>(json);

                cocktail = (List<Drink>)cocktailResponse.drinks;
            }

            return cocktail;
        }
    }
}
