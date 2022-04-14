using Microsoft.EntityFrameworkCore;
using ProjectAvancerat.NET.API.Model;
using ProjektAvancerad.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAvancerat.NET.API.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private AvanceradDbContext Context;

        public CustomerRepository(AvanceradDbContext context)
        {
            this.Context = context;
        }

        public async Task<Customer> AddCustomer(Customer customerToAdd)
        {
            var result = await Context.Customers.AddAsync(customerToAdd);
            await Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> DeleteCustomer(Customer customerToDelete)
        {
            var result = await Context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerToDelete.CustomerId);
            if (result != null)
            {
                Context.Customers.Remove(result);
                await Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await Context.Customers.ToListAsync();
        }

        public async Task<Customer> GetSingleCustomer(int id)
        {
            var result = await Context.Customers.FirstOrDefaultAsync( c => c.CustomerId == id);
            return result;
        }

        public async Task<Customer> UpdateCustomer(Customer customerToUpdate)
        {
            var result = await Context.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerToUpdate.CustomerId);
            if (result != null)
            {
                result.CustomerName = customerToUpdate.CustomerName;
                result.CustomerPhone = customerToUpdate.CustomerPhone;
                result.CustomerEmail = customerToUpdate.CustomerEmail;
                result.CompanyName = customerToUpdate.CompanyName;

                await Context.SaveChangesAsync();
            }
            return result;
        }
    }
}
