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

    public class TimeReportRepository : ITimeReportRepository
    {
        private AvanceradDbContext Context;
        public TimeReportRepository(AvanceradDbContext context)
        {
            this.Context = context;
        }


        public async Task<TimeReport> AddTimeReport(TimeReport reportToAdd)
        {
            var report = await Context.Timereports.AddAsync(reportToAdd);
            await Context.SaveChangesAsync();
            return report.Entity;
        }

        public async Task<TimeReport> DeleteTimeReport(TimeReport reportToDelete)
        {
            var report = await Context.Timereports.FirstOrDefaultAsync(t => t.TimeReportId == reportToDelete.TimeReportId);
            if (report != null)
            {
                Context.Timereports.Remove(report);
                await Context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<ICollection> GetAllReports()
        {
            return await Context.Timereports.ToListAsync();
        }

        
        public async Task<ICollection> GetHoursworked(int week)
        {
            var result = (from tim in Context.Timereports
                          join pro in Context.Projects
                          on tim.ProjectId equals pro.ProjectId
                          join emp in Context.Employees
                          on tim.EmployeeId equals emp.EmployeeId
                          where tim.week == week
                          select new
                          {
                              Project = pro.ProjectName,
                              TimeWorked = tim.WorkTime,
                              Description = tim.Description,
                              Employee = emp.FirstName + " " + emp.LastName,
                              Date = tim.DateOfRegistration
                              
                          }).ToListAsync();


            return await result;
        }

        public async Task<TimeReport> GetSingleReport(int id)
        {
            return await Context.Timereports.FirstOrDefaultAsync(t => t.TimeReportId == id);
        }

        public async Task<TimeReport> UpdateTimeReport(TimeReport reportToUpdate)
        {
            var report = await Context.Timereports.FirstOrDefaultAsync(t => t.TimeReportId == reportToUpdate.TimeReportId);
            if (report != null)
            {
                report.EmployeeId = reportToUpdate.EmployeeId;
                report.ProjectId = reportToUpdate.ProjectId;
                report.WorkTime = reportToUpdate.WorkTime;
                report.DateOfRegistration = reportToUpdate.DateOfRegistration;
                report.Description = reportToUpdate.Description;

                await Context.SaveChangesAsync();
            }
            return report;
        }
    }
}
