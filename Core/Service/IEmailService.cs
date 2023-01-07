using Core.Model;

namespace Core.Service;

public interface IEmailService : IService<CN_EMAIL_QUEUE>
{
    Task<ServicesResponse> SendEmailQueueAsync();
    Task<ServicesResponse> SendEmailAsync(SendMailRequest email);
    Task<List<CN_EMAIL_QUEUE>> GetEmailQueueAsync();
}