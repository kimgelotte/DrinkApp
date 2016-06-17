using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.DAL
{
    public class DrinkRecipe
    {
        [Key]
        public int DrinkRecipeID { get; set; }
        public string Amount { get; set; }
        public string Order { get; set; }

        //Navigate foreign

        public virtual Ingredient Ingredients { get; set; }
        public int IngredientID { get; set; }
        public virtual Drink Drinks { get; set; }
        public int DrinkID { get; set; }

    }
}
