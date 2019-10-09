﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP229_301044056_Assign02.Models
{
    public class FakeRecipeRepository :IRecipeRepository
    {
        public IQueryable<Recipe> Recipes => new List<Recipe> {
                new Recipe { ID=301,Name = "Panna Cotta", Category="Desserts",Cuisine="Italian",Ingredients="Heavy cream, Unflavored gelatin, Milk , White Sugar, Vanilla extract",Instructions="Mix all ingredients in a pan and stir until boil in medium heat." },
                new Recipe { ID=101,Name = "Autumn Soup", Category="Appetizers",Cuisine="American",Ingredients="Butternut squash, Vegetable broth,Coconut oil, Curry powder, Honewycrisp apple, Onion, Almond Milk,Salt, Cinnamon",Instructions="Cook the squash with onion apple and almond milk. When softens, put to the food processor." },
                new Recipe { ID=201,Name = "Beef Taco", Category="Entrees",Cuisine="Mexican",Ingredients="Beef, Avocado, Tomatoes, Salt, Pepper, Cummin, Cilantro, Onion, Lemon, Tortillas",Instructions="Grill the beef seasoned with salt, pepper and cummin. Season the dice the tomatoes, onions and avocado with lemon, salt, pepper and cilantro. Put the toppings in the tortillas"} }.AsQueryable<Recipe>();
    }
}
