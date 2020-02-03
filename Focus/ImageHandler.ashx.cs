using Focus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Focus
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "Image/png";
            var param = context.Request.QueryString["id"];
            int id = 0;
            if (param != null && int.TryParse(param, out id))
            {
                byte[] image = null;
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    image = dc.MyImages.Where(a => a.Id.Equals(id)).FirstOrDefault().ImageData;
                }

                //Cache
                TimeSpan cacheTime = new TimeSpan(1, 0, 0);
                context.Response.Cache.VaryByParams["*"] = true;
                context.Response.Cache.SetExpires(DateTime.Now.Add(cacheTime));
                context.Response.Cache.SetMaxAge(cacheTime);
                context.Response.Cache.SetCacheability(HttpCacheability.Public);
                context.Response.BinaryWrite(image);
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}