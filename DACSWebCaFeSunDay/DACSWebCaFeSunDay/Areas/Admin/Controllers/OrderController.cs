using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DACSWebCaFeSunDay.Models;
using PagedList;
namespace DACSWebCaFeSunDay.Areas.Admin.Controllers
{
    /*[Authorize(Roles = "Admin")]*/
    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            var items = db.Orders.OrderByDescending(x => x.Createddate).ToList();

            if (page == null)
            {
                page = 1;
            }
            var pageNumber = page ?? 1;
            var pageSize = 10;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageNumber;
            return View(items.ToPagedList(pageNumber, pageSize));
        }



        public ActionResult View(int id)
        {
            var item = db.Orders.Find(id);
            return View(item);
        }

        public ActionResult Partial_SanPham(int id)
        {
            var items = db.OrderDetails.Where(x => x.OrderId == id).ToList();
            return PartialView(items);
        }



        [HttpPost]
        public ActionResult UpdateTT(int id, int trangthai)
        {
            var item = db.Orders.Find(id);
            if (item != null && !item.Cancelled)
            {
                db.Orders.Attach(item);
                item.TypePayment = trangthai;
                db.Entry(item).Property(x => x.TypePayment).IsModified = true;

                // Cập nhật số lượng sản phẩm
                if (trangthai == 2) //Đã thanh toán
                {
                    foreach (var orderDetail in item.OrderDetails)
                    {
                        var product = db.Products.Find(orderDetail.ProductId);
                        if (product != null)
                        {
                            product.Quantity -= orderDetail.Quantity;
                            db.Entry(product).State = EntityState.Modified;
                        }
                    }
                }

                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }
        [HttpPost]
        public ActionResult UpdateDeliveryStatus(int id, int deliveryStatus)
        {
            var item = db.Orders.Find(id);
            if (item != null && !item.Cancelled)
            {
                db.Orders.Attach(item);
                item.DeliveryStatus = deliveryStatus;
                db.Entry(item).Property(x => x.DeliveryStatus).IsModified = true;

              

                db.SaveChanges();
                return Json(new { message = "Success", Success = true });
            }
            return Json(new { message = "Unsuccess", Success = false });
        }
        [HttpPost]
        public ActionResult CancelOrder(int id)
        {
            var order = db.Orders.Find(id);

            if (order != null && !order.Cancelled)
            {
                if (order.TypePayment == 2) // Đã thanh toán
                {
                    // Cộng lại số lượng sản phẩm
                    foreach (var orderDetail in order.OrderDetails)
                    {
                        var product = db.Products.Find(orderDetail.ProductId);
                        if (product != null)
                        {
                            product.Quantity += orderDetail.Quantity;
                            db.Entry(product).State = EntityState.Modified;
                        }
                    }
                }

                // Cập nhật trạng thái hủy và thông báo
                order.Cancelled = true;
                order.CancelledMessage = "Đơn hàng này đã bị hủy , vui lòng liên hệ qua hỗ trợ để biết thêm chi tiết"; // Thêm thông báo chi tiết nếu cần
                db.Entry(order).Property(x => x.Cancelled).IsModified = true;
                db.Entry(order).Property(x => x.CancelledMessage).IsModified = true;

                db.SaveChanges();

                return Json(new { message = "Success", Success = true });
            }

            return Json(new { message = "Unsuccess", Success = false });
        }



        
        
    }
}