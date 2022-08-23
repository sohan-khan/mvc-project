using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;
using PagedList;

namespace mvc_project.Controllers
{
    [Authorize]
    [RoutePrefix(" Patient")]
    public class PatientController : Controller
    {
        hosmsEntities db = new hosmsEntities();
        // GET: Patient
        [Route("Index")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";


            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            ViewBag.CurrentFilter = searchString;

            var patinets = from d in db.Patinets
                             select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                patinets = patinets.Where(x => x.Name.ToLower().StartsWith(searchString.ToLower()));

            }
            switch (sortOrder)
            {
                case "name":
                    patinets = patinets.OrderBy(s => s.Name);
                    break;

                default:  // Name ascending 
                    patinets = patinets.OrderByDescending(s => s.Name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(patinets.ToPagedList(pageNumber, pageSize));
        }

    

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create(Patinet p,string Isadmitted)
        {

            if (ModelState.IsValid)
            {
                if (p.Isadmitted == true)
                {
                    p.Isadmitted = true;
                }
                else
                {
                    p.Isadmitted = false;
                }
                Patinet pn = new Patinet()
                {

                    Name = p.Name,
                    Email = p.Email,
                    VisitDate = p.VisitDate,
                    Fee = p.Fee,
                    Isadmitted = p.Isadmitted
                };
                db.Patinets.Add(pn);
                db.SaveChanges();
                return PartialView("_success");
            }
            else
            {
                return PartialView("_error");
            }
            
           
            
        }

        // GET: Patient/Edit/5
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            var p = db.Patinets.Where(x => x.PatientId == id).FirstOrDefault();
            return View(p);
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(Patinet p)
        {

            if (ModelState.IsValid)
            {
                if (p.Isadmitted == true)
                {
                    p.Isadmitted = true;
                }
                else
                {
                    p.Isadmitted = false;
                }
                Patinet pn = new Patinet()
                {
                    PatientId=p.PatientId,
                    Name = p.Name,
                    Email = p.Email,
                    VisitDate = p.VisitDate,
                    Fee = p.Fee,
                    Isadmitted = p.Isadmitted
                };
                db.Entry(pn).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                
            }
            return RedirectToAction("Index");

        }

        // GET: Patient/Delete/5
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            Patinet p = db.Patinets.Find(id);
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

        // POST: Patient/Delete/5
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
