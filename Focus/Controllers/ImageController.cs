 using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Focus.Models;


namespace Focus.Controllers
{
    public class ImageController : Controller
    {
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