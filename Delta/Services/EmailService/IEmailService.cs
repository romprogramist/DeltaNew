using Delta.Models;
using Delta.Models.Dtos;

namespace Delta.Services.EmailService;

public interface IEmailService
{
    Task SendEmailAsync(EmailDto request);
    string CreateBody(ApplicationModel application);
}