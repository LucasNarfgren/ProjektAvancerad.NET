using Microsoft.EntityFrameworkCore;
using ProjektAvancerad.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAvancerat.NET.API.Model
{
    public class AvanceradDbContext : DbContext
    {
        public AvanceradDbContext(DbContextOptions<AvanceradDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeReport> Timereports { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Customers
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                CustomerName = "Tobias",
                CompanyName = "Qlok",
                CustomerEmail = "Tobias@Qlok.se",
                CustomerPhone = "0708090989"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                CustomerName = "Anas",
                CompanyName = "Qlok",
                CustomerEmail = "Anas@Qlok.se",
                CustomerPhone = "0907567623"
            });

            //EMPLOYEES
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Lucas",
                LastName = "Narfgren",
                Adress = "Hertings Allé 5A",
                PhoneNumber = "0707409223",
                Salary = 32300.00m
            });
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Johhny",
                LastName = "Karlsson",
                Adress = "Kalles Väg 36",
                PhoneNumber = "0709804567",
                Salary = 38500.00m
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Felix",
                LastName = "Jönsson",
                Adress = "Stor Gatan 13",
                PhoneNumber = "0908458712",
                Salary = 45500.00m
            });

            // PROJECTS
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectId = 1,
                ProjectName = "Avancerad.NET Projekt",
                ProjectDescription = "Skapa en application för tidsrapportering.",
                ProjectStartDate = new DateTime(2022, 04, 01),
                ProjectEndDate = new DateTime(2022, 04 , 10),
                CustomerId = 1,
                EstimatedPrice = 10000.00m,
                Completed = false,
                _Employees = new List<Employee>()
            });
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectId = 2,
                ProjectName = "Spel Projekt",
                ProjectDescription = "Skapa ett simpelt spel för försäljning.",
                ProjectStartDate = new DateTime(2022 , 02 , 01),
                ProjectEndDate = new DateTime(2022 , 04 , 01),
                CustomerId = 2,
                EstimatedPrice = 25000.00m,
                Completed = true,
                _Employees = new List<Employee>()
            });

            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 1,
                ProjectId = 1,
                DateOfRegistration = new DateTime(2022 , 04 , 06),
                Description = "Börjat skapa en grund för applicationen",
                EmployeeId = 1,
                WorkTime = 8.5m
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 2,
                ProjectId = 2,
                DateOfRegistration = new DateTime(2022 , 02 , 01),
                Description = "Börjat med projektet i form av planering",
                EmployeeId = 2,
                WorkTime = 4.5m
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 3,
                ProjectId = 2,
                DateOfRegistration = new DateTime(2022 , 02 , 01),
                Description = "Börjat med projektet i form av planering",
                EmployeeId = 3,
                WorkTime = 4.5m
            });
            modelBuilder.Entity<TimeReport>().HasData(new TimeReport
            {
                TimeReportId = 4,
                ProjectId = 2,
                DateOfRegistration = new DateTime(2022 , 02 , 02),
                Description = "Börjat skapa en grund för Spelet",
                EmployeeId = 3,
                WorkTime = 8.0m
            });

            modelBuilder.Entity<EmployeeProject>().HasData(new EmployeeProject
            {
                Id = 1,
                EmployeeId = 1,
                ProjectId = 1,
            });
            modelBuilder.Entity<EmployeeProject>().HasData(new EmployeeProject
            {
                Id = 2,
                EmployeeId = 2,
                ProjectId = 2,
            });
            modelBuilder.Entity<EmployeeProject>().HasData(new EmployeeProject
            {
                Id = 3,
                EmployeeId = 3,
                ProjectId = 2,
            });
        }

    }
}
