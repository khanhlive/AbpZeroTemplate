using System.Collections.Generic;

namespace Hitechsoft.CRM.Tenants.Dashboard.Dto
{
    public class GetMemberActivityOutput
    {
        public GetMemberActivityOutput(List<MemberActivity> memberActivities)
        {
            MemberActivities = memberActivities;
        }

        public List<MemberActivity> MemberActivities { get; set; }


    }
}