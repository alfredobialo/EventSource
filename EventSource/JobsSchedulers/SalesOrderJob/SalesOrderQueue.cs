using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace EventSource.JobsSchedulers.SalesOrderJob
{
    public class SalesOrderQueue  : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            // Get Sales Order detail
            return null;
        }

        public async static Task<IScheduler> GetScheduler(string saleOrderId, string groupName = "salesOrder")
        {
            var res = new  StdSchedulerFactory();
            var result = await res.GetScheduler();
            return result;

        }
    }
    
}
