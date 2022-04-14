using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAvancerat.NET.API.Services;
using ProjektAvancerad.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAvancerat.NET.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository custrepo;

        public CustomerController(ICustomerRepository repo)
        {
            custrepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            return Ok(await custrepo.GetAllCustomers());
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customertoadd)
        {
            try
            {
                if (customertoadd == null)
                {
                    return BadRequest();
                }
                var createdCustomer = await custrepo.AddCustomer(customertoadd);
                return CreatedAtAction(nameof(GetAllCustomers), new { id = createdCustomer.CustomerId }, createdCustomer);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add Customer to database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id , Customer customer)
        {
            try
            {
                if (id != customer.CustomerId)
                {
                    return BadRequest($"Customer with ID {id} does not exist.");
                }
                var customertoUpdate = await custrepo.UpdateCustomer(customer);
                if (customertoUpdate == null)
                {
                    return NotFound($"customer with id {id} was not found.");
                }
                return Ok(await custrepo.UpdateCustomer(customer));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update database.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customerToDelete = await custrepo.GetSingleCustomer(id);
                if (customerToDelete == null)
                {
                    return NotFound($"customer with id {id} was not found.");
                }
                return Ok(await custrepo.DeleteCustomer(customerToDelete));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Failed to delete customer from database.");
            }
        }

    }
}
