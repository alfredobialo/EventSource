using System.Net.Mail;

namespace LearnQuartz.components;

public interface IEmailSender
{
    Task<bool> SendMail(MailMessage mailMessage);
}

class EmailSender : IEmailSender
{
    public Task<bool> SendMail(MailMessage mailMessage)
    {
        string mailInfo = $"Sending Mail to : {mailMessage.To.FirstOrDefault()}" + 
            $"From : {mailMessage.From?.DisplayName} ({mailMessage.From?.Address})" +
        $"\nSubject : {mailMessage.Subject}" +
            $"\nMail Body : {mailMessage.Body}\n";
        
         Console.ResetColor();   
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("==================Send Email===================");
        
        Console.WriteLine(mailInfo);
        
        Console.WriteLine("==================End Email===================");
        Console.ResetColor();
        return Task.FromResult(true);
    }
}
