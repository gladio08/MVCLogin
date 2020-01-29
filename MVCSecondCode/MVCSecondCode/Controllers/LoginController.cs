using MVCSecondCode.Hash;
using MVCSecondCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVCSecondCode.Controllers
{
    public class LoginController : Controller
    {
        ApplicationDbContext myContext = new ApplicationDbContext();
        // GET: Login
        public ActionResult Index()
        {
            var List2 = myContext.Login.ToList();
            return View(List2);
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            var List = myContext.Login.Find(id);
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(Login Logins)
        {
            try
            {
                // TODO: Add insert logic here
                Logins.Password = classHash.HashPassword(Logins.Password);
                myContext.Login.Add(Logins);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login Logins)
        {
            var check = myContext.Login.FirstOrDefault(a => a.Email.Equals(Logins.Email));
            bool test = classHash.ValidatePassword(Logins.Password, check.Password);
            if (test == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            var edit = myContext.Login.Find(id);
            return View(edit);
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Login Logins)
        {
            try
            {
                // TODO: Add update logic here
                var edit = myContext.Login.Find(id);
                edit.Email = Logins.Email;
                myContext.Entry(edit).State = System.Data.Entity.EntityState.Modified;
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            var delete = myContext.Login.Find(id);
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var delete = myContext.Login.Find(id);
                myContext.Login.Remove(delete);
                myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
