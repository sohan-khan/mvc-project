using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mvc_project.Models;
using mvc_project.Models.viewmodel;

namespace mvc_project.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        hosmsEntities db = new hosmsEntities();
        // GET: Home
        [Route("~/")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int Id)
        {
           
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
           
            return View();
        }

        // POST: Home/Delete/5
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

       
        public ActionResult Register()
        {
            ViewBag.role = new SelectList(db.Roles, "RoleId", "Role1");
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register(UserInfo u)
        {
            ViewBag.role = new SelectList(db.Roles, "RoleId", "Role1");
            if (ModelState.IsValid)
            {
                
                UserInfo user = new UserInfo
                {
                    UserId = u.UserId,
                    Name = u.Name,
                    Email = u.Email,
                    Phone = u.Phone,
                    Password = u.Password,
                    Confirm_pass = u.Confirm_pass,
                    Role=u.Role
                };
                db.UserInfoes.Add(user);
                db.SaveChanges();
                return RedirectToAction("login", "home");
            }
            return View();
        }
     
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(UserInfo us)
        {
            var p = db.UserInfoes.Where(x => x.Name == us.Name && x.Password == us.Password).Count();
            if (p != 0)
            {
                FormsAuthentication.SetAuthCookie(us.Name, false);
                return RedirectToAction("Index", "Home");

            }


            else
            {
                TempData["msg"] = ("Invalid name or password");
                return View();
            }

        }
        [Route("Logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "Home");
        }

    }
}
