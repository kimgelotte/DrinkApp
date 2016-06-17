using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DrinkApp.DAL;

namespace DrinkApp.Controllers
{
    public class HomeController : Controller
    {
        DrinkAppContext Ctx = new DrinkAppContext();
        public ActionResult Index()
        {
            //Random drink
            var drinkList = Ctx.Drinks.ToList();
            Random random = new Random();
            int index = random.Next(drinkList.Count);
            var test = drinkList[index];
            return View(test);

            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TopDrinks()
        {
            return View();
        }

        public ActionResult MixNMatch()
        {
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Filter()
        {
            return View();
        }

    }
}