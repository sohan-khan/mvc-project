using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc_project.Models;
using mvc_project.Models.viewmodel;
using PagedList;

namespace mvc_project.Controllers
{
    //[Authorize(Roles ="Admin")]
    [RoutePrefix("DeptwiseDoctor")]
    public class DeptwiseDoctorController : Controller
    {
        hosmsEntities db = new hosmsEntities();
        // GET: DeptwiseDoctor
        [AllowAnonymous]
        [Route("Index")]
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.CurrentFilter = searchString;

            var dw = from d in db.DeptwiseDoctors
                             select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                dw = dw.Where(x => x.Departments_.DeptName.ToLower().StartsWith(searchString.ToLower()));

            }
            switch (sortOrder)
            {
                case "name":
                    dw = dw.OrderBy(s => s.Departments_.DeptName);
                    break;

                default:  // Name ascending 
                    dw = dw.OrderByDescending(s => s.Departments_.DeptName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(dw.ToPagedList(pageNumber, pageSize));
            
           

        }

        // GET: DeptwiseDoctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //GET: DeptwiseDoctor/Create
        [Authorize]
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.departments = new SelectList(db.Departments_, "DepartmentId", "DeptName");
            ViewBag.doctors = new SelectList(db.Doctors_, "DoctorId", "Name");
            return View();
        }

        //POST: DeptwiseDoctor/Create/
       [HttpPost]
        public ActionResult Create(DeptwiseDoctorvm dw)
        {
            ViewBag.departments = new SelectList(db.Departments_, "DepartmentId", "DeptName");
            ViewBag.doctors = new SelectList(db.Doctors_, "DoctorId", "Name");

            if (ModelState.IsValid)
            {
                if (dw.Image != null)
                {
                    string filepath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(dw.Image.FileName));
                    dw.Image.SaveAs(Server.MapPath(filepath));
                    DeptwiseDoctor p = new DeptwiseDoctor
                    {

                        DepartmentId = dw.DepartmentId,
                        DoctorId = dw.DoctorId,
                        Designation = dw.Designation,
                        Institution = dw.Institution,
                        VisitFee = dw.VisitFee,
                        Picture = filepath

                    };
                    db.DeptwiseDoctors.Add(p);
                    db.SaveChanges();
                    return RedirectToAction("Index");


                }

            }
            
            return View();
        }

        //GET: DeptwiseDoctor/Edit/5
        [Authorize]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            
            ViewBag.departments = new SelectList(db.Departments_, "DepartmentId", "DeptName");
            ViewBag.doctors = new SelectList(db.Doctors_, "DoctorId", "Name");
            var dd = db.DeptwiseDoctors.Where(x => x.DeptwiseId == id).FirstOrDefault();
            Session["picture"] = dd.Picture;
            DeptwiseDoctorvm dvm = new DeptwiseDoctorvm()
            {
                DeptwiseId = dd.DeptwiseId,
                DepartmentId = dd.DepartmentId,
                DoctorId = dd.DoctorId,
                Designation =dd.Designation,
                Institution=dd.Institution,
                VisitFee=dd.VisitFee,
                Picture=dd.Picture
            };
            return View(dvm);
        }

        // POST: DeptwiseDoctor/Edit/5
        [HttpPost]
        public ActionResult Edit(DeptwiseDoctorvm dw)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.departments = new SelectList(db.Departments_, "DepartmentId", "DeptName");
                    ViewBag.doctors = new SelectList(db.Doctors_, "DoctorId", "Name");
                    string filepath = dw.Picture;
                    if (dw.Image != null)
                    {
                        filepath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(dw.Image.FileName));
                        dw.Image.SaveAs(Server.MapPath(filepath));
                        DeptwiseDoctor p = new DeptwiseDoctor
                        {
                            DeptwiseId = dw.DeptwiseId,
                            DepartmentId = dw.DepartmentId,
                            DoctorId = dw.DoctorId,
                            Designation = dw.Designation,
                            Institution = dw.Institution,
                            VisitFee = dw.VisitFee,
                            Picture = filepath

                        };
                        db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                        //return PartialView("_succes");
                    }
                    else
                    {
                        if (ModelState.IsValid) 
                        {

                            DeptwiseDoctor p = new DeptwiseDoctor
                            {
                                DeptwiseId = dw.DeptwiseId,
                                DepartmentId = dw.DepartmentId,
                                DoctorId = dw.DoctorId,
                                Designation = dw.Designation,
                                Institution = dw.Institution,
                                VisitFee = dw.VisitFee,
                                Picture = filepath

                            };


                            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();


                        };



                        return RedirectToAction("Index");
                    }


                }
            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: DeptwiseDoctor/Delete/5
        [Authorize]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var c = db.DeptwiseDoctors.Where(x => x.DeptwiseId == id).FirstOrDefault();
            return View(c);
        }

        // POST: DeptwiseDoctor/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult pDelete( int id)
        {

            DeptwiseDoctor c = db.DeptwiseDoctors.Where(x => x.DeptwiseId == id).FirstOrDefault();
            //string file_name = c.Picture;
            string path = Server.MapPath(c.Picture);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            db.DeptwiseDoctors.Remove(c);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
