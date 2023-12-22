using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACSWebCaFeSunDay.Models
{
    public abstract class CommonAbstract
    {
        public string CreatedBy { get; set; }
        public DateTime Createddate { get; set; }
        public DateTime Modifierdate { get; set; }
        public string Modifiedby { get; set; }
    }
}