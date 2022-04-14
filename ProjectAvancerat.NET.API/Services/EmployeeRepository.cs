using Microsoft.EntityFrameworkCore;
using ProjectAvancerat.NET.API.Model;
using ProjektAvancerad.NET.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAvancerat.NET.API.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AvanceradDbContext Context;

        public EmployeeRepository(AvanceradDbContext context)
        {
            this.Context = context;
        }

        public async Task<Employee> AddEmployee(Employee empToAdd)
        {
            var result = await Context.Employees.AddAsync(empToAdd);
            await Context.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Employee> DeleteEmployee(Employee empToDelete)
        {
            var result = await Context.Employees.FirstOrDefaultAsync(p => p.EmployeeId == empToDelete.EmployeeId);
            if (result != null)
            {
                Context.Employees.Remove(result);
                await Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await Context.Employees.ToListAsync();
        }

        public async Task<ICollection> GetEmployeeWithReports(int id)
        {
            var result = (from tim in Context.Timereports
                          join emp in Context.Employees
                          on tim.EmployeeId equals emp.EmployeeId
                          join pro in Context.Projects
                          on tim.ProjectId equals pro.ProjectId
                          select new
                          {
                              Employee = emp.FirstName + " " + emp.LastName,
                              TimeReport = tim.TimeReportId,
                              Project = pro.ProjectName,
                              hours = tim.WorkTime
                          }).ToListAsync();
            return await result;
        }

        public async Task<Employee> GetSingleEmployee(int id)
        {
            return await Context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public async Task<Employee> UpdateEmployee(Employee empToUpdate)
        {
            var result = await Context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == empToUpdate.EmployeeId);
            if (result != null)
            {
                result.FirstName = empToUpdate.FirstName;
                result.LastName = empToUpdate.LastName;
                result.PhoneNumber = empToUpdate.PhoneNumber;
                result.Adress = empToUpdate.Adress;
                result.Salary = empToUpdate.Salary;

                await Context.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
