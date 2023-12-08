using System.Net.Mail;
using LearnQuartz.components;
using Quartz;

namespace LearnQuartz.simpleJob;

/// <summary>
/// Send Email to Customer based on certain Conditions /  Business Rules
/// </summary>
public class EmailSenderJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        IJobDetail jobDetail = context.JobDetail;
        JobDataMap jobData = jobDetail.JobDataMap;
        // We expect to send customer Emails of their Invoices
        // Interested Product and Services we Offer 
        // and Also Reminder of OutStanding Payments
        
        /*This Values are read from the jobDetail KEY/Group also
         More Contextual data are retrieved from the JobDetail JobMap object: eg OrderId, Payment Id etc*/
        
        string transactionType = jobData[nameof(BasicConstants.TransactionType)]?.ToString() ?? "Invoice";
        string transactionId = jobData[nameof(BasicConstants.TransactionId)]?.ToString() ?? "00001";
        string transactionData = jobData[nameof(BasicConstants.TransactionData)]?.ToString() ?? "NGN 340,000";
        
        string customerName = jobData[nameof(BasicConstants.CustomerName)]?.ToString() ?? "James Okoye",
             customerEmailAddress =jobData[nameof(BasicConstants.CustomerEmailAddress)]?.ToString() ?? "jameokoye@gmail.com";
        
        MailMessage mm = new MailMessage(
            new MailAddress("info@effectiv-biz-accounting.ng","Alfred Obialo"),
            new MailAddress(customerEmailAddress,customerName));

        mm.Subject = $"{transactionType} #{transactionId} Details";
        mm.Body = $"Hi {customerName}, hope this mail meet you well? Here is your {transactionType} Details: For " +
            $"#{transactionId},  {transactionData}. Please treat as urgent to Enable us serve you better." +
            $"\n\n\n" +
            $"Thanks, Alfred Obialo ";

        IEmailSender emailSender = new EmailSender();
        var result = await emailSender.SendMail(mm);


    }
}

public enum BasicConstants
{
    CustomerName,
    CustomerEmailAddress,
    TransactionType,
    TransactionData,
    TransactionId,
    EmailType,
       
}
