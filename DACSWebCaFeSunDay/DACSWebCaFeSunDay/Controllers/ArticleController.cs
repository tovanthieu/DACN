using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACSWebCaFeSunDay.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace DACSWebCaFeSunDay.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string alias)
        {
            var item=db.Posts.FirstOrDefault(x=>x.Alias == alias);
            return View(item);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}