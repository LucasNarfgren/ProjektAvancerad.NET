using ProjektAvancerad.NET.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAvancerat.NET.API.Services
{
    public interface IProjectRepository
    {
        Task<Project> AddProject(Project projectToAdd);
        Task<Project> UpdateProject(Project projectToUpdate);
        Task<Project> DeleteProject(Project projectToDelete);
        Task<ICollection> GetProjectWithEmployees(int id);
        Task<IEnumerable<Project>> GetAllProjects();
        Task<Project> GetSingleProject(int id);
    }
}
