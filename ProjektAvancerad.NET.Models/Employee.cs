using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjektAvancerad.NET.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3,ErrorMessage = "Firstname must be between 3 and 30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 4,ErrorMessage = "Lastname must be between 4 and 50 characters.")]
        public string LastName { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }


    }
}
