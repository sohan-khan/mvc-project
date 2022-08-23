using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;

namespace mvc_project.Controllers
{
    [Authorize]
    [RoutePrefix("DoctorsSalary")]
    public class DoctorsSalaryController : Controller
    {
        hosmsEntities db = new hosmsEntities();
        // GET: DoctorsSalary
        [Route("Index")]
        public ActionResult Index()
        {
            return View(db.Doctors_Salaries.ToList());
        }

        // GET: DoctorsSalary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoctorsSalary/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.doctors = new SelectList(db.Doctors_, "DoctorId", "Name");
            return View();
        }

        // POST: DoctorsSalary/Create
        [HttpPost]
        public ActionResult Create(Doctors_Salary n)
        {
            if (ModelState.IsValid)
            {
                Doctors_Salary ns = new Doctors_Salary()
                {
                    VisitingDay = n.VisitingDay,
                    PayRate = n.PayRate,
                    TotalHour = n.TotalHour,
                    //ToatalPay = (n.TotalHour*n.ToatalPay),
                    DoctorId = n.DoctorId
                };
                db.Doctors_Salaries.Add(ns);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: DoctorsSalary/Edit/5
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            ViewBag.doctors = new SelectList(db.Doctors_, "DoctorId", "Name");
            var c = db.Doctors_Salaries.Where(x => x.DocsId == id).FirstOrDefault();
            return View(c);
        }

        // POST: DoctorsSalary/Edit/5
        [HttpPost]
        public ActionResult Edit(Doctors_Salary n)
        {
            ViewBag.doctors = new SelectList(db.Doctors_, "DoctorId", "Name");
            if (ModelState.IsValid)
            {
                Doctors_Salary ns = new Doctors_Salary()
                {
                    DocsId = n.DocsId,
                    VisitingDay = n.VisitingDay,
                    PayRate = n.PayRate,
                    TotalHour = n.TotalHour,
                    //ToatalPay = (n.TotalHour * n.ToatalPay),
                    DoctorId = n.DoctorId
                };
                db.Entry(ns).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: DoctorsSalary/Delete/5
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            Doctors_Salary p = db.Doctors_Salaries.Find(id);
            if (p != null)
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["delmsg"] = "<script>alert('Data deleted successfully')</script>";
                }
            }
            return RedirectToAction("Index");
        }

        // POST: DoctorsSalary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
