using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DrinkApp.DAL;
using DrinkApp.ViewModels;

namespace DrinkApp.Controllers
{

    [RoutePrefix("api/ingredient")]
    public class IngredientsApiController : ApiController
    {
        //Get a drinkinformation via id
        [HttpPost]
        [Route("PostDrinkId")]
        public DrinkViewModels PostDrinkId([FromBody]int id)
        {
            using (var db = new DrinkAppContext())
            {
                var dri = new DrinkRecipeViewModels();
                var drink = db.Drinks.Select(a => a).Where(b => b.DrinkID == id).FirstOrDefault();
                var drinkVM = new List<DrinkViewModels>();
                var x = (from dr in db.DrinkRecipes
                         join i in db.Ingredients
                         on dr.IngredientID equals i.IngredientID
                         where dr.DrinkID == id
                         select new DrinkRecipeViewModels
                         {
                             DrinkRecipeID = dr.DrinkRecipeID,
                             Amount = dr.Amount,
                             Order = dr.Order,
                             IngredientID = dr.IngredientID,
                             DrinkID = dr.DrinkID,
                             Name = i.Name
                         }).ToList();
                var drinkVMs = new DrinkViewModels();
                drinkVMs.DrinkID = drink.DrinkID;
                drinkVMs.Name = drink.Name;
                drinkVMs.DrinkTaste = drink.DrinkTaste;
                drinkVMs.DrinkType = drink.DrinkType;
                drinkVMs.Complexity = drink.Complexity;
                drinkVMs.DRI = x;
                return drinkVMs;
            }

        }
        //get ingredients order by name
        [HttpGet]
        [Route("GetIngredients")]
        public IEnumerable<Ingredient> Ingredients()
        {
            using (var db = new DrinkAppContext())
            {
                var l = db.Ingredients.OrderBy(x => x.Name).ToList();
                return l;

            }

        }

    }
}
