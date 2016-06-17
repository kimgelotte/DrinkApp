using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DrinkApp.Controllers
{
    public class MasterController : ApiController
    {
        public string Get()
        {
            return "Hellow!!";
        }
    }
}
