using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Укажите имя пользователя")]
        public string User { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactPhone { get; set; }
        public int? CarId { get; set; }
        public Car Car { get; set; }
    }
}
