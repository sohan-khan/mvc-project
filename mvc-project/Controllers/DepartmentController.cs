using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;

namespace mvc_project.Controllers
{   
   [RoutePrefix("Department")]
    public class DepartmentController : Controller
    {
        hosmsEntities db = new hosmsEntities();
        // GET: Department
        [AllowAnonymous]
        [Route("Index")]
        public ActionResult Index()
        {
            
            return View(db.Departments_.ToList());
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Department/Create
        [Authorize]
        [Route("Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Departments_ d)
        {
           
                if (ModelState.IsValid)
                {
                Departments_ de = new Departments_()
                {
                    DepartmentId = d.DepartmentId,
                    DeptName = d.DeptName
                };
                db.Departments_.Add(de);
                db.SaveChanges();
                
                }

                return RedirectToAction("Index");
          
           
            
        }

        // GET: Department/Edit/5
        [Authorize]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var c = db.Departments_.Where(x => x.DepartmentId == id).FirstOrDefault();
            return View(c);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(Departments_ d)
        {
            if (ModelState.IsValid)
            {
                Departments_ ns = new Departments_()
                {
                    DepartmentId = d.DepartmentId,
                   DeptName= d.DeptName,
                   

                };
                db.Entry(ns).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Department/Delete/5
        [Authorize]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            Departments_ p = db.Departments_.Find(id);
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

        // POST: Department/Delete/5
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
