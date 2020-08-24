using CoctailBot.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoctailBot.Logics
{
    public class GetIngridients
    {
        /// <summary>
        /// Get real ingridients 
        /// </summary>
        /// <param name="reciep">CocktailRecipe</param>
        /// <returns>List real ingridients in coctail</returns>
        public async Task <List<string>> GetListIngridientsAsync(CocktailRecipe reciep) {
            List<string> baseingridients = new List<string>()
            {
                reciep.strIngredient1,
                reciep.strIngredient2,
                reciep.strIngredient3,
                reciep.strIngredient4,
                reciep.strIngredient5,
                reciep.strIngredient6,
                reciep.strIngredient7,                
                reciep.strIngredient8,
                reciep.strIngredient9,
                reciep.strIngredient10,
                reciep.strIngredient11,
                reciep.strIngredient12,
                reciep.strIngredient13,
                reciep.strIngredient14,
                reciep.strIngredient15
            } ;

            List<string> baseMeasure = new List<string>()
            {
                reciep.strMeasure1,
                reciep.strMeasure2,
                reciep.strMeasure3,
                reciep.strMeasure4,
                reciep.strMeasure5,
                reciep.strMeasure6,
                reciep.strMeasure7,
                reciep.strMeasure8,
                reciep.strMeasure9,
                reciep.strMeasure10,
                reciep.strMeasure11,
                reciep.strMeasure12,
                reciep.strMeasure13,
                reciep.strMeasure14,
                reciep.strMeasure15
            };

            var outingridients = new List<string>();
            await Task.Run(() =>
            {
                for (var i = 0; i < baseingridients.Count && i < baseMeasure.Count; i++) {
                    string ingridient = baseingridients[i];
                    string measure = baseMeasure[i];
                    if (ingridient!=null) {
                        outingridients.Add(ingridient.ToLower() + " " + measure);
                    }
                }             
            });

            return outingridients;
        }

    }
}