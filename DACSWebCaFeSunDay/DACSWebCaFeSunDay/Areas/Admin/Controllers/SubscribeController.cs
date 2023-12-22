using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACSWebCaFeSunDay.Models;

namespace DACSWebCaFeSunDay.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    
    public class SubscribeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Subscribe
        public ActionResult Index()
        {
            var items = db.Subscribes.ToList();
            return View(items);
        }
    }
    
    
}