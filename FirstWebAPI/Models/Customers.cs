using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FirstWebAPI.Models
{
    public class Customers
    {
           
        [StringLength(10, ErrorMessage = "String Length Error Message for CustomerID")]
        public int CustomerID { get; set; }
        [Required,RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",ErrorMessage ="Invalid Email Format")]
        public string email{ get; set; }
        [Required,RegularExpression(@"^[0-9]{10}")]
        public string phoneNumber { get; set; }
    }
}
