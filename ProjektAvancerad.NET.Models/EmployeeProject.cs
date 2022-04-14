using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektAvancerad.NET.Models
{
    public class EmployeeProject
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
