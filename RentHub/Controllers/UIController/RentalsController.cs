using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentHub.Controllers.UIController
{
    public class RentalsController : Controller
    {
        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }
    }
}