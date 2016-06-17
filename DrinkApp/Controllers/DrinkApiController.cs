using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DrinkApp.ViewModels;
using DrinkApp.DAL;
using Newtonsoft.Json;

namespace DrinkApp.Controllers
{
    [RoutePrefix("api/drink")]
    public class DrinkApiController : ApiController
    {
        //GET drink with ingredienets
        [HttpGet]
        [Route("GetDrinks")]
        public IEnumerable<DrinkViewModels> Get()
        {
            using (var db = new DrinkAppContext())
            {

                var dri = new DrinkRecipeViewModels();
                var drinkVM = new List<DrinkViewModels>();
                var drinklist = db.Drinks.ToList();
                foreach (var item in drinklist)
                {


                    var x = (from dr in db.DrinkRecipes
                             join i in db.Ingredients
                             on dr.IngredientID equals i.IngredientID
                             where dr.DrinkID == item.DrinkID
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
                    drinkVMs.DrinkID = item.DrinkID;
                    drinkVMs.Name = item.Name;
                    drinkVMs.DrinkTaste = item.DrinkTaste;
                    drinkVMs.DrinkType = item.DrinkType;
                    drinkVMs.Complexity = item.Complexity;
                    drinkVMs.DRI = x;
                    drinkVM.Add(drinkVMs);
                }
                return drinkVM;
            }
        }


        //Get drinks with counter and procent matching
        [HttpPost]
        [Route("PostDrinkIngrediensCounter")]
        public IEnumerable<DrinkVMCounter> postDrinkWithCounter(List<Ingredient> il)
        {
            using (var db = new DrinkAppContext())
            {
                var drinkList = Get();
                var listcounter = new Dictionary<int, int>();
                var newl = new List<DrinkVMCounter>();
                for (int i = 0; i < il.Count(); i++)
                {
                    var x = (from d in db.Drinks.ToList()
                             join dr in db.DrinkRecipes.ToList()
                             on d.DrinkID equals dr.DrinkID
                             join ing in db.Ingredients.ToList()
                             on dr.IngredientID equals ing.IngredientID
                             where ing.Name == il[i].Name
                             select new DrinkVMCounter
                             {
                                 DrinkID = d.DrinkID,
                                 Name = d.Name,
                                 DrinkTaste = d.DrinkTaste,
                                 DrinkType = d.DrinkType,
                                 Complexity = d.Complexity,
                             }).ToList();
                    foreach (var item in x)
                    {
                        newl.Add(item);
                    }
                }
                var counts = newl.GroupBy(ax => ax.DrinkID).Select(y => new { key = y.Key, count = y.Count() });

                var newlist = new List<DrinkVMCounter>();
                foreach (var item in counts)
                {
                    var ilist = (from dr in db.DrinkRecipes
                                 join i in db.Ingredients
                                 on dr.IngredientID equals i.IngredientID
                                 where dr.DrinkID == item.key
                                 select i).Count();
                    var x = (from d in db.Drinks.ToList()

                             where d.DrinkID == item.key
                             select d).FirstOrDefault();
                    var l = new DrinkVMCounter();
                    l.Complexity = x.Complexity;

                    l.DrinkID = x.DrinkID;
                    l.Name = x.Name;
                    l.DrinkTaste = x.DrinkTaste;
                    l.DrinkType = x.DrinkType;
                    l.Complexity = x.Complexity;
                    l.Counter = item.count;
                    l.IngredientCount = ilist;
                    l.Procent = Math.Round(((double)item.count / (double)ilist) * 100, 0);

                    newlist.Add(l);
                }
                return newlist.OrderByDescending(x => x.Procent).ThenByDescending(x => x.Counter);
            }

        }
        //Get top 5 liked drinks
        [HttpGet]
        [Route("GetTopDrinks")]
        public List<DrinkCounter> GetTopDrinks()
        {

            using (var db = new DrinkAppContext())
            {
                var drinklikes = (from id in db.Drinks
                                  join likes in db.Likes on id.DrinkID equals likes.DrinkID
                                  group id by id into g
                                  orderby g.Count() descending

                                  select new { Id = g.Key, Count = g.Count() }).Take(5);

                var drinkCounterList = new List<DrinkCounter>();
                foreach (var item in drinklikes)
                {
                    var dl = new DrinkCounter();
                    dl.DrinkID = item.Id.DrinkID;
                    dl.Complexity = item.Id.Complexity;
                    dl.Counter = item.Count;
                    dl.DrinkTaste = item.Id.DrinkTaste;
                    dl.DrinkType = item.Id.DrinkType;
                    dl.Name = item.Id.Name;

                    drinkCounterList.Add(dl);
                }

                return drinkCounterList;
            }
        }


        //get drink types
        [HttpGet]
        [Route("GetTypes")]
        public List<string> GetTypes()
        {
            using (var db = new DrinkAppContext())
            {
                var l = new List<string>();
                var list = (from d in db.Drinks
                            orderby d.DrinkType
                            select new { d = d.DrinkType }).Distinct().ToList();


                foreach (var item in list)
                {
                    l.Add(item.d);
                }
                return l;
            }
        }
        //get drink tastes
        [HttpGet]
        [Route("GetTaste")]
        public List<string> GetTaste()
        {
            using (var db = new DrinkAppContext())
            {
                var l = new List<string>();
                var list = (from d in db.Drinks
                            orderby d.DrinkTaste
                            select new { d = d.DrinkTaste }).Distinct().ToList();


                foreach (var item in list)
                {
                    l.Add(item.d);
                }
                return l;
            }
        }

        //Get drinks on chosen taste and type
        [HttpPost]
        [Route("PostDrinkFilter")]
        public Drink PostDrinkFilter(List<string> li)
        {
            using (var db = new DrinkAppContext())
            {
                var taste = li[0];
                var type = li[1];

                var drinkList = (from d in db.Drinks
                                 where (string.IsNullOrEmpty(taste) ? true : d.DrinkTaste == taste) && (string.IsNullOrEmpty(type) ? true : d.DrinkType == type)
                                 select d).ToList();


                var drinkListr = drinkList;
                if (drinkList.Count > 0)
                {
                    Random random = new Random();
                    int index = random.Next(drinkListr.Count);
                    var randomDrink = drinkListr[index];
                    return randomDrink;
                }
                var ed = new Drink();
                return ed;
            }
        }
    }
}
