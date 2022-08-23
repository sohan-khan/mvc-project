using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;

namespace mvc_project.Controllers
{
    [Authorize]
    [RoutePrefix("Nurse")]
    public class NurseController : Controller
    {
        hosmsEntities db = new hosmsEntities();
        // GET: Nurse
        [Route("Index")]
        public ActionResult Index()
        {
            return View(db.Nurses.ToList());
        }

        // GET: Nurse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Nurse/Create
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.departments = new SelectList(db.Departments_, "DepartmentId", "DeptName");
            return View();
        }

        // POST: Nurse/Create
        [HttpPost]
        public ActionResult Create(Nurse n)
        {
            if (ModelState.IsValid)
            {
                Nurse ns = new Nurse()
                {
                    Name = n.Name,
                    Phone = n.Phone,
                    Salary = n.Salary,
                    DepartmentId = n.DepartmentId
                };
                db.Nurses.Add(ns);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Nurse/Edit/5
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            ViewBag.departments = new SelectList(db.Departments_, "DepartmentId", "DeptName");
            var c = db.Nurses.Where(x => x.NurseId == id).FirstOrDefault();
            return View(c);
        }

        // POST: Nurse/Edit/5
        [HttpPost]
        public ActionResult Edit(Nurse n)
        {
            ViewBag.departments = new SelectList(db.Departments_, "DepartmentId", "DeptName");
            if (ModelState.IsValid)
            {
                Nurse ns = new Nurse()
                {
                    NurseId=n.NurseId,
                    Name = n.Name,
                    Phone = n.Phone,
                    Salary = n.Salary,
                    DepartmentId = n.DepartmentId
                };
                db.Entry(ns).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Nurse/Delete/5
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            Nurse p = db.Nurses.Find(id);
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

        // POST: Nurse/Delete/5
        [HttpPost]
      
        public ActionResult Delete(Nurse n)
        {
            return View();
        }
    }
}
