using ProjektAvancerad.NET.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAvancerat.NET.API.Services
{
    public interface ITimeReportRepository
    {
        Task<TimeReport> AddTimeReport(TimeReport reportToAdd);
        Task<TimeReport> UpdateTimeReport(TimeReport reportToUpdate);
        Task<TimeReport> DeleteTimeReport(TimeReport reportToDelete);
        Task<TimeReport> GetSingleReport(int id);
        Task<ICollection> GetAllReports();
        Task<ICollection> GetHoursworked(int week);
    }
}
