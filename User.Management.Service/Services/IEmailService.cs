using User.Management.Service.Models;

namespace User.Management.Service.Services
{
    public interface IEmailService
    {
        Task SendOtpEmailAsync(EmailData emailData);  // (Method definition)This will allow any class that implements IEmailService to define the SendOtpEmailAsync method.

    }
}
