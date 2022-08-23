using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;
namespace mvc_project.Controllers
{
    [Authorize]
    [RoutePrefix("Maintenence")]
    public class MaintenenceController : Controller
    {
        hosmsEntities db = new hosmsEntities();
        // GET: Maintenence
        [Route("Index")]
        public ActionResult Index()
        {
            return View(db.Maintenence_Employees.ToList());
        }

        // GET: Maintenence/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Maintenence/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.admins = new SelectList(db.AdminPanels, "AdminId", "Name");
            return View();
        }

        // POST: Maintenence/Create
        [HttpPost]
        public ActionResult Create(Maintenence_Employee e)
        {
            if (ModelState.IsValid)
            {
                Maintenence_Employee ns = new Maintenence_Employee()
                {
                    Name = e.Name,
                    Phone = e.Phone,
                    Work_section=e.Work_section,
                    Salary = e.Salary,
                    AdminId = e.AdminId
                };
                db.Maintenence_Employees.Add(ns);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Maintenence/Edit/5
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            ViewBag.admins = new SelectList(db.AdminPanels, "AdminId", "Role");
            var c = db.Maintenence_Employees.Where(x => x.EmpId == id).FirstOrDefault();
            return View(c);
        }

        // POST: Maintenence/Edit/5
        [HttpPost]
        public ActionResult Edit(Maintenence_Employee e)
        {
            ViewBag.admins = new SelectList(db.AdminPanels, "AdminId", "Role");
            if (ModelState.IsValid)
            {
                Maintenence_Employee ns = new Maintenence_Employee()
                {
                    EmpId=e.EmpId,
                    Name = e.Name,
                    Phone = e.Phone,
                    Work_section = e.Work_section,
                    Salary = e.Salary,
                    AdminId = e.AdminId
                };

                db.Entry(ns).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
             
            }
            return RedirectToAction("Index");
        }

        // GET: Maintenence/Delete/5
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            Maintenence_Employee p = db.Maintenence_Employees.Find(id);
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

        // POST: Maintenence/Delete/5
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
