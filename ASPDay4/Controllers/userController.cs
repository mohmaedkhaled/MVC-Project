using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPDay4.Models;

namespace ASPDay4.Controllers
{
    public class userController : Controller
    {
        // GET: user
        ITIcontext db = new ITIcontext();
        public ActionResult Index()
        {
            if (Session["userid"] != null)
                return View(db.Users.ToList());
            else
                return RedirectToAction("login");
        }


        public ActionResult create()
        {
            List<department> departments = db.Departments.ToList();
            SelectList st = new SelectList(departments, "id", "name",2);
            ViewBag.dept = st;
            return View();
        }

        [HttpPost]
        public ActionResult create( user s)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(s);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
            {
                List<department> departments = db.Departments.ToList();
                SelectList st = new SelectList(departments, "id", "name");
                ViewBag.dept = st;
                return View();
            }
        
        }

            public ActionResult about()
        {

            return View();
        }

        public ActionResult edit( int id)
        {
            user s = db.Users.Where(n => n.id == id).SingleOrDefault();

            ViewBag.dept = new SelectList(db.Departments.ToList(), "id", "name", s.dept_id);

            return View(s);

        }
        [HttpPost]
        public ActionResult edit(user u)
        {
            //db.Entry(u).State = System.Data.Entity.EntityState.Modified;
            user us = db.Users.Where(n => n.id == u.id).SingleOrDefault();
            us.name = u.name;
            us.age = u.age;
            us.email = u.email;
            us.dept_id = u.dept_id;
            us.confirm_password = us.password;


            db.SaveChanges();


            return RedirectToAction("index");
        }


        public ActionResult login()
        {
            if (Request.Cookies["fullstack"] != null)
            {
                Session["userid"] =Request.Cookies["fullstack"].Values["id"];
                return RedirectToAction("profile");
            }
            return View();
        }
        [HttpPost]
        public ActionResult login( user u ,string remeberme)
        {
            user us = db.Users.Where(n => n.email == u.email && n.password == u.password).FirstOrDefault();
            if(us != null)
            {
                //login
                Session.Add("userid", us.id);
                if(remeberme == "true")
                {
                    HttpCookie co = new HttpCookie("fullstack");
                    co.Values.Add("id", us.id.ToString());
                    co.Expires = DateTime.Now.AddDays(15);
                    Response.Cookies.Add(co);


                }



                return RedirectToAction("profile");
            }
            else
            {
                //notlogin
                ViewBag.status = "invalid email or password";

                return View();
            }


        }

        public ActionResult profile()
        {
            int id = int.Parse( Session["userid"].ToString());
            user u = db.Users.Where(n => n.id == id).FirstOrDefault();


            return View(u);
        }
        public ActionResult logout()
        {
            Session["userid"] = null;
            HttpCookie c = new HttpCookie("fullstack");
            c.Expires = DateTime.Now.AddDays(-15);
            Response.Cookies.Add(c);

            return RedirectToAction("login");
        }




    }
    }