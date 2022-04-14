using ProjektAvancerad.NET.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAvancerat.NET.API.Services
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployee(Employee empToAdd);
        Task<Employee> UpdateEmployee(Employee empToUpdate);
        Task<Employee> DeleteEmployee(Employee empToDelete);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetSingleEmployee(int id);
        Task<ICollection> GetEmployeeWithReports(int id);

    }
}
