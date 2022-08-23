using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using mvc_project.Models;

namespace mvc_project.Controllers
{
    [Authorize]
   [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        hosmsEntities db = new hosmsEntities();
        // GET: Admin
        [Route("Index")]
        public ActionResult Index()
        {

            return View(db.AdminPanels.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(AdminPanel a)
        {
            if (ModelState.IsValid)
            {
                AdminPanel ns = new AdminPanel()
                {
                    Name = a.Name,
                    Role = a.Role
                 
                    
                };
                db.AdminPanels.Add(ns);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }

        // GET: Admin/Edit/5
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
           
            var c = db.AdminPanels.Where(x => x.AdminId == id).FirstOrDefault();
            return View(c);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(AdminPanel a)
        {
            if (ModelState.IsValid)
            {
                AdminPanel ns = new AdminPanel()
                {
                    AdminId = a.AdminId,
                    Name = a.Name,
                    Role = a.Role
                   
                };
                db.Entry(ns).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Admin/Delete/5
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            AdminPanel p = db.AdminPanels.Find(id);
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

        // POST: Admin/Delete/5
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
