using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DACSWebCaFeSunDay.Models.EF
{
    [Table("Wishlist")]
    public class Wishlist
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Product Product { get; set; }
    }
}