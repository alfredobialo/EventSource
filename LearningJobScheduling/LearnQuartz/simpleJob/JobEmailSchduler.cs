using Quartz;
using Quartz.Impl;

namespace LearnQuartz.simpleJob;

public class JobEmailSchduler
{
    public async Task SendEmail(EmailSchedulerOptions options)
    {
        string id = options.Id;
        string transactionType = options.TransactionName;
        string transactionData = options.TransactionData;
        string customerName = options.CustomerName;
        string customerEmail = options.CustomerEmailAddress;
        IJobDetail jobDetail = JobBuilder
            .Create<EmailSenderJob>()
            .WithIdentity(id, transactionType)
            .WithDescription("Email Sender Job")
            .UsingJobData(nameof(BasicConstants.TransactionType), transactionType)
            .UsingJobData(nameof(BasicConstants.TransactionData), transactionData)
            .UsingJobData(nameof(BasicConstants.TransactionId), id) 
            .UsingJobData(nameof(BasicConstants.CustomerName), customerName)
            .UsingJobData(nameof(BasicConstants.CustomerEmailAddress), customerEmail)
            .Build();
        
        IScheduler schduler = await StdSchedulerFactory.GetDefaultScheduler();
       
        // Create a Trigger and Associate with the Schduler
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity($"trigger-{id}","trigger-" + transactionType)
            .StartNow()
            .Build();

        await schduler.ScheduleJob(jobDetail, trigger);
        await schduler.StartDelayed(options.SendAtTime);

    } 
    
}

public record EmailSchedulerOptions
{
    public string Id { get; init; }
    public string TransactionName { get; init; }
    public string CustomerName { get; init; }
    public string CustomerEmailAddress { get; init; }
    public TimeSpan SendAtTime { get; init; } = TimeSpan.FromSeconds(2);
    public string TransactionData { get; init; }
}
