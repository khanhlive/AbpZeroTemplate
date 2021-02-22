using System;
using Abp.Notifications;
using Hitechsoft.CRM.Dto;

namespace Hitechsoft.CRM.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}