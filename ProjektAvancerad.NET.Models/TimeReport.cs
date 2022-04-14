using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjektAvancerad.NET.Models
{
    public class TimeReport
    {
        [Key]
        public int TimeReportId { get; set; }
        
        [Required]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required]
        public DateTime DateOfRegistration { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal WorkTime { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

    }
}
