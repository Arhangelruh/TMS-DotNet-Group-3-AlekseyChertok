using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoctailBot.Helpers
{
    public class Constants
    {/// <summary>
    /// Поиск по названию.
    /// </summary>
        public const string searchCocktailByname = "https://www.thecocktaildb.com/api/json/v1/1/search.php";
        /// <summary>
        /// Поиск по ингдиенту.
        /// </summary>
        public const string searchByIngredient = "https://www.thecocktaildb.com/api/json/v1/1/filter.php";
        /// <summary>
        /// Поиск по ID.
        /// </summary>
        public const string lookupFullCocktaildetailsById = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php";
        /// <summary>
        /// Произвольный коктель.
        /// </summary>
        public const string lookupaRandomCocktail = "https://www.thecocktaildb.com/api/json/v1/1/random.php";
        /// <summary>
        /// List the categories, ingredients or alcoholic filters
        /// </summary>
        public const string listCategories = "https://www.thecocktaildb.com/api/json/v1/1/list.php";
    }
}
