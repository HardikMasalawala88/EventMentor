using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DB.Constant
{
    public enum EventSlotType
    {
        Morning,
        Evening,
        FullDay,
        MultipleDay
    }
    public enum Status
    {
        Workpending,
        WorkOnProcess,
        WorkFinish
    }
    public enum Userrole
    {
        Admin,
        staff,
        operators,
        supervisor
    }

    public enum InquiryStatusType
    {
        InDiscussion,
        Reject,
        EventGenerated
    }
}
