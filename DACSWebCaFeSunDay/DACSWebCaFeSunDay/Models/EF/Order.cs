using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DACSWebCaFeSunDay.Models.EF
{
   
        [Table("Order")]
        public class Order:CommonAbstract
        {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage = "Tên khách hàng không để trống")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Số điện thoại không để trống")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Địa chỉ khổng để trống")]
        public string Address { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public int TypePayment { get; set; }
        public int DeliveryStatus { get; set; }
        public bool Cancelled { get; set; }
        public string CancelledMessage { get; set; }
        public string CustomerId { get; set; }
        public int Status { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
    }