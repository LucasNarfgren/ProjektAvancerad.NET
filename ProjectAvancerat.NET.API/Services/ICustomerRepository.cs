using ProjektAvancerad.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAvancerat.NET.API.Services
{
    public interface ICustomerRepository
    {
        Task<Customer> AddCustomer(Customer customerToAdd);
        Task<Customer> UpdateCustomer(Customer customerToUpdate);
        Task<Customer> DeleteCustomer(Customer customerToDelete);
        Task<Customer> GetSingleCustomer(int id);
        Task<IEnumerable<Customer>> GetAllCustomers();
    }
}
