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
    public class ProjectController : ControllerBase
    {
        private IProjectRepository prorepo;
        public ProjectController(IProjectRepository ProRepo)
        {
            prorepo = ProRepo;
        }

        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(await prorepo.GetAllProjects());
        }

        [HttpGet("projects/{id}")]
        public async Task<IActionResult> GetProjectWithEmployees(int id)
        {
            return Ok(await prorepo.GetProjectWithEmployees(id));
        }
        [HttpPost]
        public async Task<IActionResult> AddProject(Project projectToAdd)
        {
            try
            {
                if (projectToAdd == null)
                {
                    return BadRequest();
                }
                var createdProject = await prorepo.AddProject(projectToAdd);
                return CreatedAtAction(nameof(GetSingleProject), new { id = createdProject.ProjectId }, createdProject);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to add project to database.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleProject(int id)
        {
            return Ok(await prorepo.GetSingleProject(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, Project project)
        {
            try
            {
                if (id != project.ProjectId)
                {
                    return BadRequest($"Project with ID {id} does not exist.");
                }
                var projectToUpdate = await prorepo.GetSingleProject(id);
                if (projectToUpdate == null)
                {
                    return NotFound($"Project with ID {id} was not found.");
                }
                return Ok(await prorepo.UpdateProject(project));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to update to database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                var projectToDelete = await prorepo.GetSingleProject(id);
                if (projectToDelete == null)
                {
                    return NotFound($"project with ID {id} was not found");
                }
                return Ok(await prorepo.DeleteProject(projectToDelete));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to delete project from database.");
            }
        }
    }
}
