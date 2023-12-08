// See https://aka.ms/new-console-template for more information

using LearnQuartz.simpleJob;

Console.WriteLine("Job Scheduler Demo");

await new JobEmailSchduler().SendEmail(new EmailSchedulerOptions()
{
    Id = "00100",
    TransactionName = "Sales Invoice",
    CustomerName = "Maryann Somkene",
    CustomerEmailAddress =  "somkenemaryann@gmail.com",
    TransactionData = "Sales Total => NGN 234,680"
});

// Send Mail to Alfred
await new JobEmailSchduler().SendEmail(new EmailSchedulerOptions()
{
    Id = "7002921",
    TransactionName = "Payment",
    CustomerName = "James Ikechukwu",
    CustomerEmailAddress =  "alfredcsdinc@gmail.com",
    TransactionData = "Subscription Due for : $345.45"
});

Console.ReadLine();
