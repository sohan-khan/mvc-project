using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Transactions;
using System.Web.Mvc;
using mvc_project.Models;
using mvc_project.Models.viewmodel;
using System.Data.Entity;

namespace mvc_project.Controllers
{
    [RoutePrefix("Deptvm")]
    public class DeptvmController : Controller
    {
        hosmsEntities db = new hosmsEntities();

        // GET: Deptvm
        [AllowAnonymous]
        [Route("Index")]
        public ActionResult Index()
        {
            var dw = (from c in db.DeptwiseDoctors
                      join ca in db.Departments_ on c.DepartmentId equals ca.DepartmentId
                      join cp in db.Doctors_ on c.DoctorId equals cp.DoctorId
                      select new deptwisevm
                      {
                          DeptName = ca.DeptName,
                          Name = cp.Name,
                          Designation = c.Designation,
                          Institution = c.Institution,
                          VisitFee = c.VisitFee,
                          Picture = c.Picture
                      }).ToList();
            return View(dw);
        }

        // GET: Deptvm/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deptvm/Create
        [Authorize]
        [Route("Create")]
        public ActionResult Create()
        {
            ViewBag.departments = new SelectList(db.Departments_, " DepartmentId ", "DeptName");
            ViewBag.doctors = new SelectList(db.Doctors_, " DoctorId", "Name");
            return View();
        }

        // POST: Deptvm/Create
        [HttpPost]
        public ActionResult Create(deptwisevm dvm)
        {
            using (var context = new hosmsEntities())
            {
                using (DbContextTransaction dbtran = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            if (dvm.Image != null)
                            {
                                string filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(dvm.Image.FileName));
                                dvm.Image.SaveAs(Server.MapPath(filePath));
                                ViewBag.departments = new SelectList(db.Departments_, " DepartmentId ", "DeptName");
                                ViewBag.doctors = new SelectList(db.Doctors_, " DoctorId", "Name");

                                Departments_ de = new Departments_()
                                {
                                    DeptName = dvm.DeptName,
                                  

                                };
                                Doctors_ dc = new Doctors_()
                                {
                                    Name = dvm.Name
                                    
                                };


                                

                                DeptwiseDoctor dp = new DeptwiseDoctor()
                                {

                                    Designation = dvm.Designation,
                                    Institution = dvm.Institution,
                                    VisitFee = dvm.VisitFee,
                                    Picture = filePath,
                                    DepartmentId = dvm.DepartmentId,
                                    DoctorId = dvm.DoctorId

                                };

                                db.Departments_.Add(de);
                                db.DeptwiseDoctors.Add(dp);
                                db.Doctors_.Add(dc);
                                db.SaveChanges();
                                ViewBag.msg = "Data inserted Successfully";
                                //TempData["msg"] = "<script>alert('Data Inserted successfully')<script>";

                                return RedirectToAction("Index");

                            }

                        }
                        dbtran.Commit();
                    }
                    catch (Exception)
                    {
                        dbtran.Rollback();
                        //TempData["msg"] = "<script>alert('Data Insertion Failed')<script>"; ;
                        ViewBag.msg = "Data insertion Failed for one or more missing";
                      
                    }


                }
                return View();

            }
        }

        // GET: Deptvm/Edit/5
        //[Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            
            return View();
        }

        // POST: Deptvm/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deptvm/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Deptvm/Delete/5
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
