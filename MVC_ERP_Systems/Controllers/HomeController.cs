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

        public class EmpModle
        {
            public List<EMPLOYEES> EMPLOYEES { get; set; }
            public int totalcount { get; set; }
        }

        public HomeController()
        {
            db = new MEFDBEs();
        }

        public JsonResult get_data(int? pageindex, int? pagesize)
        {
            EmpModle EmpModle1 = new EmpModle();

            EmpModle1.EMPLOYEES = db.EMPLOYEES.OrderBy(emp => emp.EMP_NO)
                //.Where(emp => emp.FULL_NAME.Contains(SearchText) || emp.EMP_NO.ToString() == SearchText)
                .Skip((pageindex ?? 0) * 10)
                .Take(pagesize ?? 5)
                .ToList();

            EmpModle1.totalcount = db.EMPLOYEES.OrderBy(emp => emp.EMP_NO)
                //.Where(emp => emp.FULL_NAME.Contains(SearchText) || emp.EMP_NO.ToString() == SearchText)
                .Count();

            return Json(EmpModle1, JsonRequestBehavior.AllowGet);
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(db.EMPLOYEES);
        }
    }
}