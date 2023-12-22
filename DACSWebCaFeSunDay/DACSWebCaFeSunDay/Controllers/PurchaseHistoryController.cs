using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DACSWebCaFeSunDay.Models;
using Microsoft.AspNet.Identity;
using PagedList;

namespace DACSWebCaFeSunDay.Controllers
{
    public class PurchaseHistoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: PurchaseHistory
        public ActionResult Index(int? page)
        {

            string userId = User.Identity.GetUserId();
            var orders = db.Orders
                .Include("OrderDetails.Product")
                .Where(o => o.CustomerId == userId)
                .OrderByDescending(o => o.Createddate)
                .ToList();

            int pageSize = 5;
            int pageIndex = page ?? 1;
            var pagedList = orders.ToPagedList(pageIndex, pageSize);

            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return View(pagedList);
        }
    }
}