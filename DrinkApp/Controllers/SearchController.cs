using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrinkApp.DAL;

namespace DrinkApp.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
                return View();
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
           using (var db = new DrinkAppContext())
            {
                var drink = from d in db.Drinks
                            join dr in db.DrinkRecipes
                            on d.DrinkID equals dr.DrinkID
                            join i in db.Ingredients
                            on dr.IngredientID equals i.IngredientID
                            where (d.Name.Contains(search) || i.Name.Contains(search))
                            select d;

                return View(drink.ToList());
            }
        }
    }
}