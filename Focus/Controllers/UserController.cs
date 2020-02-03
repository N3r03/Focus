using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Focus.Models;

namespace Focus.Controllers
{
    public class UserController : Controller
    {
        NewdbEntities db = new NewdbEntities();

        // GET: User
     
        public ActionResult Registration()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registration(Reg r)
        {
            db.Regs.Add(r);
            db.SaveChanges();

            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Reg r)
        {
            var l = db.Regs.Where(a => a.username.Equals(r.username) && a.password.Equals(r.password)).FirstOrDefault();
            if (l!=null)
            {
                return RedirectToAction("Index","User");
            }
            else
            {
                return RedirectToAction("Login","User");
            }
            return View();
        }

        public ActionResult Menu()
        {

            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }
        public ActionResult List()
        {
            List<MyImage> all = new List<MyImage>();
            //MyDatabaseEntities is our datacontext
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                all = dc.MyImages.ToList();
            }

            return View(all);
            
        }
        
    }
}
