using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_ERP_Systems.Models;

namespace MVC_ERP_Systems.Controllers
{
    public class HomeController : Controller
    {
        MEFDBEs db;

        public HomeController()
        {
            db = new MEFDBEs();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(db.EMPLOYEES);
        }
    }
}