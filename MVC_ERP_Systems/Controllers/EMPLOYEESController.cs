using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_ERP_Systems.Models;

namespace MVC_ERP_Systems.Controllers
{
    public class EmpModle
    {
        public List<EMPLOYEES> EMPLOYEES { get; set; }
        public int totalcount { get; set; }
    }

    public class EMPLOYEESController : Controller
    {
        private MEFDBEs db = new MEFDBEs();

        // GET: EMPLOYEES
        public ActionResult Index()
        {
            return View();
        }

        // GET: EMPLOYEES
        public ActionResult Pages()
        {
            return View();
        }


        public JsonResult GaetData(int? pageindex, int? pagesize)
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


        // GET: EMPLOYEES/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEES eMPLOYEES = db.EMPLOYEES.Find(id);
            if (eMPLOYEES == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEES);
        }

        // GET: EMPLOYEES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPLOYEES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMP_NO,EMPLOYEE_FIRST_NAME,EMPLOYEE_FATHER_NAME,EMPLOYEE_GRAND_NAME,EMPLOYEE_FAMILY_NAME,FULL_NAME,SOLDIER_NO,IDENTITY_NO,EMP_H_DATE,GENDER,PHONE,PROV_ID,DEPT_ID,DIV_ID,SECTION_ID,EMAIL,CREATION_USER_ID,CREATION_DATE")] EMPLOYEES eMPLOYEES)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEES.Add(eMPLOYEES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPLOYEES);
        }

        // GET: EMPLOYEES/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEES eMPLOYEES = db.EMPLOYEES.Find(id);
            if (eMPLOYEES == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEES);
        }

        // POST: EMPLOYEES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMP_NO,EMPLOYEE_FIRST_NAME,EMPLOYEE_FATHER_NAME,EMPLOYEE_GRAND_NAME,EMPLOYEE_FAMILY_NAME,FULL_NAME,SOLDIER_NO,IDENTITY_NO,EMP_H_DATE,GENDER,PHONE,PROV_ID,DEPT_ID,DIV_ID,SECTION_ID,EMAIL,CREATION_USER_ID,CREATION_DATE")] EMPLOYEES eMPLOYEES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPLOYEES);
        }

        // GET: EMPLOYEES/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEES eMPLOYEES = db.EMPLOYEES.Find(id);
            if (eMPLOYEES == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEES);
        }

        // POST: EMPLOYEES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            EMPLOYEES eMPLOYEES = db.EMPLOYEES.Find(id);
            db.EMPLOYEES.Remove(eMPLOYEES);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
