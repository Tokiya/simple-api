using People.Api.Models.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace People.Api.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            var key = Guid.NewGuid().ToString("N");
            InMemoryRepository.AddKey(key);
            return key;
        }


        public ActionResult Reset()
        {
            InMemoryRepository.Reset();
            return View();
        }
    }
}
