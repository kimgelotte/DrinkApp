using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DrinkApp.DAL;
namespace DrinkApp.ViewModels
{
    /// <summary>
    /// Drink Model view variants
    /// </summary>
    public class DrinkViewModels
    {
        public int DrinkID { get; set; }
        public string Name { get; set; }
        public string DrinkTaste { get; set; }
        public string DrinkType { get; set; }
        public int Complexity { get; set; }
        public List<DrinkRecipeViewModels> DRI { get; set; }
       

    }
    public class DrinkRecipeViewModels
    {

        public int DrinkRecipeID { get; set; }
        public string Amount { get; set; }
        public string Order { get; set; }
        public int IngredientID { get; set; }
        public int DrinkID { get; set; }
        public string Name { get; set; }
    }

    public class DrinkCounter
    {
        public int DrinkID { get; set; }
        public string Name { get; set; }
        public string DrinkTaste { get; set; }
        public string DrinkType { get; set; }
        public int Complexity { get; set; }
        public int Counter { get; set; }
    }

    public class DrinkVMCounter
    {

        public int DrinkID { get; set; }
        public string Name { get; set; }
        public string DrinkTaste { get; set; }
        public string DrinkType { get; set; }
        public int Complexity { get; set; }
        public int Counter { get; set; }
        public int IngredientCount { get; set; }
        public double Procent { get; set; }
    }



}