using CoreFramework.Mailing;
using Hangfire;
using Ordering.Application.Services.OrderLogService;
using Ordering.Hangfire.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Hangfire;

public static class RunRecurringJobs
{
    [Obsolete]
    public async static void RunJobs()
    {
       

        RecurringJob.RemoveIfExists("DailyOrderLog");

        RecurringJob.AddOrUpdate<IDailyLogService>("DailyOrderLog", x =>
              x.SendLogs(), Cron.Daily(17,1), TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time"));
    }
 
}
