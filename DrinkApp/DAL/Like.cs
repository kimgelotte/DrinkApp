using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.DAL
{
    public class Like
    {
        [Key]
        public int LikeID { get; set; }

        //Navigate foreign
        public virtual Person Persons { get; set; }
        public int PersonID { get; set; }
        public virtual Drink Drinks { get; set; }
        public int DrinkID { get; set; }

    }
}
