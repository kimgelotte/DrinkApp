using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.DAL
{
    public class DrinkAppContext : DbContext
    {
        public DrinkAppContext() : base("DrinkAppContext") //connstring name in web.config
        {
        }

        //DBSet to entities
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkRecipe> DrinkRecipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Person> Persons { get; set; }
        
    }
}
