using DrinkApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DrinkApp.Controllers
{
    public class GetDrinkController : Controller
    {
        private DrinkAppContext Ctx = new DrinkAppContext();
        // GET: GetDrink
        public ActionResult Index()
        {
            var drinkList = Ctx.Drinks.ToList();
            Random random = new Random();
            int index = random.Next(drinkList.Count);

            return View(drinkList[index]);
        }

        // GET: GetDrink/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GetDrink/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GetDrink/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GetDrink/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GetDrink/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GetDrink/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GetDrink/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
