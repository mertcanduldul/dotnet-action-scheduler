using Core.Model;

namespace Core.Repository;

public interface IEmailRepository : IRepository<CN_EMAIL_QUEUE>
{
    Task<IEnumerable<string>> GetEmailByFromMail();
}