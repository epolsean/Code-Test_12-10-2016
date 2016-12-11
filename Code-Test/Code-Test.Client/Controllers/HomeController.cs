using Code_Test.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_Test.Client.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Home(PriceCheckerModel PCModel)
        {
            return View(PCModel);
        }
        public PartialViewResult Calculator(PriceCheckerModel PCModel)
        {
            return PartialView(PCModel);
        }
        
        public RedirectToRouteResult Calculate(string product, string state, string quantity)
        {
            UpdateModel um = new UpdateModel();
            return RedirectToAction("Home", um.GetUpdatedModel(product, state, quantity));
        }
    }
}