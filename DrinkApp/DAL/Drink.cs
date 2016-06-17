using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.DAL
{
    public class Drink
    {
        [Key]        
        public int DrinkID { get; set; }
        public string Name { get; set; }
        public string DrinkTaste { get; set; }
        public string DrinkType { get; set; }
        public int Complexity { get; set; }

    }
}
