using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_Test.Client.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Home()
        {
            return View();
        }

        public PartialViewResult Calculator()
        {
            return PartialView();
        }
    }
}