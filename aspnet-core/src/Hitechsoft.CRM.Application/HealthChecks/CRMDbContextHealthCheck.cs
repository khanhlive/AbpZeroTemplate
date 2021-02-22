using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Hitechsoft.CRM.EntityFrameworkCore;

namespace Hitechsoft.CRM.HealthChecks
{
    public class CRMDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public CRMDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("CRMDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("CRMDbContext could not connect to database"));
        }
    }
}
