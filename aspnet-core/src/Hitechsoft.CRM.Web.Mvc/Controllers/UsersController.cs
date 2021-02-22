using Abp.AspNetCore.Mvc.Authorization;
using Hitechsoft.CRM.Authorization;
using Hitechsoft.CRM.Storage;
using Abp.BackgroundJobs;
using Abp.Authorization;

namespace Hitechsoft.CRM.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}