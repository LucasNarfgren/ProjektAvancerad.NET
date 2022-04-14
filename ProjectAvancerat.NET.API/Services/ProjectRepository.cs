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
    public class ProjectRepository : IProjectRepository
    {
        private AvanceradDbContext Context;

        public ProjectRepository(AvanceradDbContext context)
        {
            this.Context = context;
        }

        public async Task<Project> AddProject(Project projectToAdd)
        {
            var project = await Context.Projects.AddAsync(projectToAdd);
            await Context.SaveChangesAsync();
            return project.Entity;
        }

        public async Task<Project> DeleteProject(Project projectToDelete)
        {
            var project = await Context.Projects.FirstOrDefaultAsync( p => p.ProjectId == projectToDelete.ProjectId);
            if (project != null)
            {
                Context.Projects.Remove(project);
                await Context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<IEnumerable<Project>> GetAllProjects()
        {
            return await Context.Projects.ToListAsync();
        }


        public async Task<ICollection> GetProjectWithEmployees(int id)
        {
            var result = (from proj in Context.EmployeeProjects
                          join emp in Context.Employees
                          on proj.EmployeeId equals emp.EmployeeId
                          join pro in Context.Projects
                          on proj.ProjectId equals pro.ProjectId
                          where pro.ProjectId == id
                          select new
                          {
                              ProjectID = proj.ProjectId,
                              ProjectName = pro.ProjectName,
                              EmployeeID = emp.EmployeeId,
                              Employee = emp.FirstName + " " + emp.LastName,
                              Salary = emp.Salary,
                              Adress = emp.Adress,
                              phoneNumber = emp.PhoneNumber
                             

                          }).ToListAsync();
            return await result;
        }

        public async Task<Project> GetSingleProject(int id)
        {
            return await Context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);

        }

        public async Task<Project> UpdateProject(Project projectToUpdate)
        {
            var result = await Context.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectToUpdate.ProjectId);
            if (result != null)
            {
                result.ProjectName = projectToUpdate.ProjectName;
                result.ProjectDescription = projectToUpdate.ProjectDescription;
                result.ProjectStartDate = projectToUpdate.ProjectStartDate;
                result.ProjectEndDate = projectToUpdate.ProjectEndDate;
                result.EstimatedPrice = projectToUpdate.EstimatedPrice;
                result.CustomerId = projectToUpdate.CustomerId;
                result.ProjectId = projectToUpdate.ProjectId;
                result.Completed = projectToUpdate.Completed;

                await Context.SaveChangesAsync();
            }
            return result;
        }
    }
}
