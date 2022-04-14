using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektAvancerad.NET.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5,ErrorMessage = "Project name needs to be between 5 and 25 characters.")]
        public string ProjectName { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Description cannot be more than 200 characters.")]
        public string ProjectDescription { get; set; }

        [Required]
        public DateTime ProjectStartDate { get; set; }

        public DateTime? ProjectEndDate { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EstimatedPrice { get; set; }

        public ICollection<Employee> _Employees { get; set; }

        public bool? Completed { get; set; }

    }
}
