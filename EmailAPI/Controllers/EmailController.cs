using Core.Model;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Hangfire;

namespace EmailAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class EmailController : ControllerBase
{
    public IEmailService _emailService;
    
    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpGet]
    public string Get()
    {
        
        RecurringJob.AddOrUpdate(() => _emailService.SendEmailQueueAsync(), Cron.Minutely);
        
        return "EmailAPI Successfull Reached.";
    }

    [HttpPost]
    public async Task<ServicesResponse> SendEmail([FromBody] SendMailRequest request)
    {
        var response =await _emailService.SendEmailAsync(request);
        return response;
    }
}