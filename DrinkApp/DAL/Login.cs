using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkApp.DAL
{
    public class Login
    {
        [Key]
        public int LoginID { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }

        //Navigation foreign
        public virtual Person Persons { get; set; }
        public int PersonID { get; set; }

    }
}
