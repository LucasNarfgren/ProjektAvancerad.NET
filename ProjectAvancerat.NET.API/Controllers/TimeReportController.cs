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
    public class TimeReportController : ControllerBase
    {
        private ITimeReportRepository timerepo;
        public TimeReportController(ITimeReportRepository _timerepo)
        {
            timerepo = _timerepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleReport(int id)
        {
            return Ok(await timerepo.GetSingleReport(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(TimeReport reportToAdd )
        {
            try
            {
                if (reportToAdd == null)
                {
                    return BadRequest();
                }
                var createdProject = await timerepo.AddTimeReport(reportToAdd);
                return CreatedAtAction(nameof(GetSingleReport), new { id = createdProject.ProjectId }, createdProject);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add project to database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReport(int id, TimeReport report)
        {
            try
            {
                if (id != report.TimeReportId)
                {
                    return BadRequest($"report with ID {id} does not exist.");
                }
                var reportToUpdate = await timerepo.GetSingleReport(id);
                if (reportToUpdate == null)
                {
                    return NotFound($"Project with ID {id} was not found.");
                }
                return Ok(await timerepo.UpdateTimeReport(report));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update to database.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            try
            {
                var reportToDelete = await timerepo.GetSingleReport(id);
                if (reportToDelete == null)
                {
                    return NotFound($"Report with ID {id} was not found");
                }
                return Ok(await timerepo.DeleteTimeReport(reportToDelete));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete Report from database.");
            }
        }
        [HttpGet("week/{id}")]
        public async Task<IActionResult> GetHours(int id)
        {
            return Ok(await timerepo.GetHoursworked(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReports()
        {
            return Ok(await timerepo.GetAllReports());
        }
    }
}
