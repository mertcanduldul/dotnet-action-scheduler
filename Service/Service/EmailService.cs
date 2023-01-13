using System.Linq.Expressions;
using Core.Model;
using Core.Repository;
using Core.Service;

namespace Service.Service;

public class EmailService:IEmailService
{
    private readonly IEmailRepository _emailRepository;
    
    public EmailService(IEmailRepository emailRepository)
    {
        _emailRepository = emailRepository;
    }

    public Task<CN_EMAIL_QUEUE> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CN_EMAIL_QUEUE>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> AddAsync(CN_EMAIL_QUEUE entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(CN_EMAIL_QUEUE entity)
    {
        throw new NotImplementedException();
    }

    public IQueryable<CN_EMAIL_QUEUE> Where(Expression<Func<CN_EMAIL_QUEUE, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public async Task<ServicesResponse> SendEmailQueueAsync()
    {
        try
        {
            var sendMailqueue = await _emailRepository.Update();
            return new ServicesResponse()
            {
                IsSuccess = true,
                Message = "Email sent successfully",
                Status = "200"

            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<ServicesResponse> SendEmailQueueAsync(SendMailRequest email)
    {
        throw new NotImplementedException();
    }

    public async Task<ServicesResponse> SendEmailAsync(SendMailRequest request)
    {
        try
        {
            var email = new CN_EMAIL_QUEUE()
            {
                EMAIL_TO = request.EMAIL_TO,
                EMAIL_SUBJECT = request.EMAIL_SUBJECT,
                EMAIL_BODY = request.EMAIL_BODY,
                EMAIL_CC = request.EMAIL_CC,
                EMAIL_BCC = request.EMAIL_BCC,
            };

            var result = await _emailRepository.AddAsync(email);

            return new ServicesResponse()
            {
                IsSuccess = true,
                Message = "Email sent successfully",
                Status = "200"
            };
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public Task<List<CN_EMAIL_QUEUE>> GetEmailQueueAsync()
    {
        throw new NotImplementedException();
    }
}