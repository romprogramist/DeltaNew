using Delta.Models;
using Delta.Models.Dtos;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Delta.Services.EmailService;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }
    
    public async Task SendEmailAsync(EmailDto request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config["EmailSettings:Username"]));
        
        var recipients = _config["EmailSettings:Recipients"]?.Split(";");
        
        if (recipients != null)
        {
            var recipientEmailList = new InternetAddressList();
            recipientEmailList.AddRange(recipients.Select(MailboxAddress.Parse));
            
            email.To.AddRange(recipientEmailList);
        
            email.Subject = request.Subject;
            if (!string.IsNullOrEmpty(request.Body))
            {
                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = request.Body
                };
            }
        
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["EmailSettings:Host"], int.Parse(_config["EmailSettings:Port"] ?? string.Empty));
            await smtp.AuthenticateAsync(_config["EmailSettings:Username"], _config["EmailSettings:Password"]);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
    }

    public string CreateBody(ApplicationModel application)
    {
        return
            $"<p>Имя: {application.Name}</p>" +
            $"<p>Телефон: {application.Phone}</p>" +
            $"<p>Источник: {application.UtmInfo}</p>";
    }
}