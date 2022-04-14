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
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository emprepo;
        public EmployeeController(IEmployeeRepository EmpRepo)
        {
            emprepo = EmpRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await emprepo.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleEmployee(int id)
        {
            return Ok(await emprepo.GetSingleEmployee(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employeetoAdd)
        {
            try
            {
                if (employeetoAdd == null)
                {
                    return BadRequest();
                }
                var createdEmployee = await emprepo.AddEmployee(employeetoAdd);
                return CreatedAtAction(nameof(GetAllEmployees), new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add employee to database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id , Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest($"Person with ID {id} does not exist.");
                }
                var employeeToUpdate = await emprepo.GetSingleEmployee(id);
                if (employeeToUpdate == null)
                {
                    return NotFound($"Employee with ID {id} was not found.");
                }
                return Ok(await emprepo.UpdateEmployee(employee));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update to database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await emprepo.GetSingleEmployee(id);
                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with ID {id} was not found");
                }
                return Ok(await emprepo.DeleteEmployee(employeeToDelete));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete person from database.");
            }
        }
        [HttpGet("report/{id}")]
        public async Task<IActionResult> GetEmployeewithReports(int id)
        {
            return Ok(await emprepo.GetEmployeeWithReports(id));
        }

    }
}
