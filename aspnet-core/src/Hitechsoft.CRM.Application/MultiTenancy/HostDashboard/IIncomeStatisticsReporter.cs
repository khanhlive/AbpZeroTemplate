using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitechsoft.CRM.MultiTenancy.HostDashboard.Dto;

namespace Hitechsoft.CRM.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}