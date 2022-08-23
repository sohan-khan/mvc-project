using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;
namespace mvc_project.Controllers
{
   [RoutePrefix("Doctors")]
    public class DoctorsController : Controller
    {
        hosmsEntities db = new hosmsEntities();
        [Authorize]
        [Route("Index")]
        public ActionResult Index()
        {
            return View(db.Doctors_.ToList());
        }

        [Authorize]
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.patients = new SelectList(db.Patinets, "PatientId", "Name");
            return View();
        }


        [HttpPost]

        public ActionResult Create(Doctors_ ds)
        {
            ViewBag.patients = new SelectList(db.Patinets, "PatientId", "Name");

            Doctors_ d = new Doctors_()
            {
                DoctorId = ds.DoctorId,
                Name = ds.Name,
                PatientId = ds.PatientId
            };
            db.Doctors_.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            ViewBag.patients = new SelectList(db.Patinets, "PatientId", "Name");
            var c = db.Doctors_.Where(x => x.DoctorId == id).FirstOrDefault();
            return View(c);
        }
        [HttpPost]
        public ActionResult Edit(Doctors_ d)
        {
            ViewBag.patients = new SelectList(db.Patinets, "PatientId", "Name");
            Doctors_ ds = new Doctors_()
            {
                DoctorId = d.DoctorId,
                Name = d.Name,
                PatientId = d.PatientId
            };
            db.Entry(ds).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [Authorize]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            Doctors_ p = db.Doctors_.Find(id);
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
    }
}