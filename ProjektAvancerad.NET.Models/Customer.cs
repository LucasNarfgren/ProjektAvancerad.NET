using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjektAvancerad.NET.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public string? CompanyName { get; set; }

        [Required]
        public string CustomerPhone { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

    }
}
