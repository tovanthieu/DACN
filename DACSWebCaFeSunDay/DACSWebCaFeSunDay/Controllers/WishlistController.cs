using DACSWebCaFeSunDay.Models;
using DACSWebCaFeSunDay.Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI;
using PagedList;

namespace DACSWebCaFeSunDay.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Wishlist
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Wishlist> items = db.Wishlists.Where(x => x.UserName == User.Identity.Name).OrderByDescending(x => x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostWishList(int ProductId)
        {
            if (Request.IsAuthenticated == false)
            {
                return Json(new { Success = false, Message = "Xin hãy đăng nhập" });
            }
            var checkItem = db.Wishlists.FirstOrDefault(x => x.ProductId == ProductId && x.UserName == User.Identity.Name);
            if (checkItem != null)
            {
                return Json(new { Success = false, Message = "Sản phẫm đã được thêm vào danh sách yêu thích" });
            }
            var item = new Wishlist();
            item.ProductId = ProductId;
            item.UserName = User.Identity.Name;
            item.CreatedDate = DateTime.Now;
            db.Wishlists.Add(item);
            db.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostDeleteWishList(int ProductId)
        {
            var checkItem = db.Wishlists.FirstOrDefault(x => x.ProductId == ProductId && x.UserName == User.Identity.Name);
            if (checkItem != null)
            {
                db.Wishlists.Remove(checkItem);
                db.SaveChanges();
                return Json(new { Success = true, Message = "Xóa sản phẩm thành công" });
            }
            return Json(new { Success = false, Message = "Xóa sản phẩm thất bại" });
        }
    
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}